using System;
using System.Linq;
using System.Net;
using System.Text;

namespace Homologador.Fe.Auth
{
    /// <summary>
    /// Class for Auth in Sunat.
    /// </summary>
    public static class RucAuth
    {

        #region Export
        /// <summary>
        /// Valida si las credenciales son las correctas.
        /// </summary>
        /// <param name="ruc">Ruc del contribuyente.</param>
        /// <param name="user">Usuario del contribuyente.</param>
        /// <param name="password">Contraseña del contribuyente.</param>
        /// <returns>true si la credencil es válida</returns>
        public static bool Validate(string ruc, string user, string password)
        {
            if (string.IsNullOrEmpty(ruc) || ruc.Length != 11)
            {
                throw new ArgumentException("Ruc debe tener 11 digitos.");
            }
            if (string.IsNullOrEmpty(user) ||
                string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Ningun campo debe estar vacio.");
            }
            return ValidateInternal(ruc, user, password);
        }

        #endregion

        #region Private

        private static bool ValidateInternal(string ruc, string user, string pass)
        {
            var content = $"tipo=2&dni=&username={ruc}{user}&password={pass}&captcha=&params=%2A%26%2A%26%2Fcl-ti-itmenu%2FMenuInternet.htm%26b64d26a8b5af091923b23b6407a1c1db41e733a6&exe=";
            var bytes = Encoding.ASCII.GetBytes(content);
            var req = (HttpWebRequest)WebRequest.Create(Properties.Resources.Auth);
            req.AllowAutoRedirect = false;
            req.CookieContainer = new CookieContainer();
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bytes.Length;
            using (var writer = req.GetRequestStream())
            {
                writer.Write(bytes, 0, bytes.Length);
            }
            var resp = (HttpWebResponse)req.GetResponse();
            if (resp.StatusCode == HttpStatusCode.NotFound)
                throw new Exception("No se pudo conectar a SUNAT.");
            return resp.Headers.AllKeys.Contains("Location");
        }
        #endregion

    }
}
