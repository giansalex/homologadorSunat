using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Homologador.Fe.Auth
{
    public class SunatAuth
    {
        protected readonly string Ruc;
        private readonly string _user;
        private readonly string _password;

        private CookieContainer _cookies;
        private string _location;

        protected SunatAuth(string ruc, string user, string clave)
        {
            
            Ruc = ruc;
            _user = user;
            _password = clave;
        }

        protected HttpClient CreatClient()
        {
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false,
                CookieContainer = _cookies,
                
            };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.ExpectContinue = false;
            return client;
        }

        public void Login()
        {
            _location = Properties.Resources.Auth;
            _cookies = new CookieContainer();
            Send(new NameValueCollection
            {
                {"tipo", "2" },
                {"dni", "" },
                {"username", Ruc + _user},
                {"password", _password},
                {"captcha", ""},
                {"params", "*&*&/cl-ti-itmenu/MenuInternet.htm&b64d26a8b5af091923b23b6407a1c1db41e733a6"},
                {"exe", ""},
            });
            _location = Properties.Resources.OpcionMenu; // Change menu for proveedor
            Send();
        }
        private void Send(NameValueCollection data = null)
        {
            while (true)
            {
                var http = (HttpWebRequest)WebRequest.Create(_location);
                http.AllowAutoRedirect = false;
                http.CookieContainer = _cookies;
                http.ServicePoint.Expect100Continue = false;
                if (data != null)
                {
                    http.ServerCertificateValidationCallback = delegate { return true; };
                    http.Method = "POST";
                    http.ContentType = "application/x-www-form-urlencoded";
                    var postData = GetData(data);
                    http.ContentLength = postData.Length;
                    WriteData(http, postData);
                }
                else
                    http.Method = "GET";
                if (Output((HttpWebResponse)http.GetResponse()))
                {
                    data = null;
                    continue;
                }
                break;
            }
        }

        private byte[] GetData(NameValueCollection objs)
        {
            var concat = string.Empty;
            var content = string.Empty;
            for (var i = 0; i < objs.Count; i++)
            {
                var value = Uri.EscapeDataString(objs[i]);
                content += concat + objs.GetKey(i) + "=" + value;
                concat = "&";
            }
            var data = Encoding.ASCII.GetBytes(content);
            return data;
        }

        private void WriteData(WebRequest req, byte[] data)
        {
            using (var stream = req.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }

        private bool SetLocation(HttpWebResponse resp)
        {
            var heads = resp.Headers;
            for (var i = 0; i < heads.Count; i++)
            {
                var key = heads.GetKey(i);
                if (key != "Location") continue;
                _location = heads[i];
                var prevDomain = resp.ResponseUri.Host;
                var url = new Uri(_location);
                var newDomain = url.Host;
                if (prevDomain != newDomain)
                    foreach (Cookie cookie in resp.Cookies)
                        _cookies.Add(url, cookie);
                return true;
            }
            return false;
        }

        private bool Output(HttpWebResponse resp)
        {
            var st = resp.GetResponseStream();
            try
            {
                if (st != null)
                    using (var wr = new StreamReader(st))
                    {
                        wr.Read();
                    }
            }
            catch
            {
                // ignored
            }

            return SetLocation(resp);
        }

    }
}
