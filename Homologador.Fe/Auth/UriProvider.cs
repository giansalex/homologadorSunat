using System.Collections.Generic;
using Homologador.Fe.Properties;

namespace Homologador.Fe.Auth
{
    /// <summary>
    /// Class UriProvider.
    /// </summary>
    public static class UriProvider
    {
        private static bool _isProveedor;
        private static readonly Dictionary<string, string> Urls = new Dictionary<string, string>(3)
        {
            {"Consulta", "" },
            {"Menu", "" }
        };

        /// <summary>
        /// Gets or sets a value indicating whether this instance is proveedor.
        /// </summary>
        /// <value><c>true</c> if this instance is proveedor; otherwise, <c>false</c>.</value>
        public static bool IsProveedor
        {
            set
            {
                _isProveedor = value;
                if (_isProveedor)
                {
                    Urls["Consulta"] = Resources.UriConsultProveedor;
                    Urls["Menu"] = Resources.OpcionMenuProveedor;
                }
                else
                {
                    Urls["Consulta"] = Resources.UriConsulta;
                    Urls["Menu"] = Resources.OpcionMenu;
                }
            }
            get { return _isProveedor; }
        }

        /// <summary>
        /// Gets the URI consult.
        /// </summary>
        /// <value>The URI consult.</value>
        public static string UriConsult => Urls["Consulta"];
        /// <summary>
        /// Gets the URI menu.
        /// </summary>
        /// <value>The URI menu.</value>
        public static string UriMenu => Urls["Menu"];
    }
}
