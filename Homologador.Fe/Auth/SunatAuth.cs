using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Homologador.Fe.Auth
{
    public class SunatAuth
    {
        private readonly string _ruc;
        private readonly string _user;
        private readonly string _password;

        private readonly CookieContainer _cookies = new CookieContainer();

        public SunatAuth(string ruc, string user, string password)
        {
            _ruc = ruc;
            _user = user;
            _password = password;
        }

        /// <summary>
        /// Logins this instance.
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> Login()
        {


            using (var client = GetClient())
            {
                var content = new FormUrlEncodedContent(new []
                {
                    new KeyValuePair<string, string>("username", _ruc + _user), 
                    new KeyValuePair<string, string>("password", _password), 
                    new KeyValuePair<string, string>("captcha", string.Empty), 
                    new KeyValuePair<string, string>("params", "*&*&/cl-ti-itmenu/MenuInternet.htm&b64d26a8b5af091923b23b6407a1c1db41e733a6"), 
                    new KeyValuePair<string, string>("exe", string.Empty) 
                });


                var r = await client.PostAsync("https://e-menu.sunat.gob.pe/cl-ti-itmenu/AutenticaMenuInternet.htm", content);
                //if (r.Headers.Contains("Location"))
                if (r.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Gets the solicitudes.
        /// </summary>
        /// <example>
        /// Response:
        /// {"items":[{"estado":"En proceso-Set de pruebas","fecnot":"","numsol":"3050825980023","compro":" Factura, Boleta","fecpre":"11\/05\/2017"},{"estado":"No aprobada","fecnot":"27\/03\/2017","numsol":"3021701500023","compro":" Factura, Boleta","fecpre":"27\/02\/2017"}],"identifier":"numsol"}
        /// </example>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> GetSolicitudes()
        {
            await SetUrl();
            using (var client = GetClient())
            {
                var r = await client.GetAsync("https://ww1.sunat.gob.pe/cl-ti-itconestsol/Consulta.htm?accion=consultaTodasSolicitudes&numRUC=" + _ruc +"&indTipoContrib=0");
                if (!r.IsSuccessStatusCode) return null;

                return await r.Content.ReadAsStringAsync();
            }    
        }

        public async Task<string> GetPruebas(string numProceso)
        {
            using (var client = GetClient())
            {
                var content = new FormUrlEncodedContent(new []
                {
                    new KeyValuePair<string, string>("accion", "mostrarDashboard"),
                    new KeyValuePair<string, string>("numProceso", numProceso),
                    new KeyValuePair<string, string>("numRUC", _ruc)
                });
                var r = await client.PostAsync("https://ww1.sunat.gob.pe/cl-ti-itconestsol/Consulta.htm", content);
                if (!r.IsSuccessStatusCode) return null;

                return await r.Content.ReadAsStringAsync();
            }
        }

        private HttpClient GetClient()
        {
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                CookieContainer = _cookies
            };
            var client = new HttpClient(handler);
            return client;
        }

        private async Task SetUrl()
        {
            using (var client = GetClient())
            {
                 var r = await client.GetAsync("https://e-menu.sunat.gob.pe/cl-ti-itmenu/MenuInternet.htm?action=execute&code=11.9.3.1.1&s=ww1");
                var heads = r.Headers;
            }
        }
    }
}
