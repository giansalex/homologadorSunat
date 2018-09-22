using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Homologador.Fe.Auth
{
    public class SunatApi : SunatAuth
    {
        public SunatApi(string ruc, string user, string password)
            : base(ruc, user, password)
        {
        }

        /// <summary>
        /// Gets the solicitudes.
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> GetSolicitudes()
        {
            using (var client = CreatClient())
            {
                var r = await client.GetAsync(UriProvider.UriConsult + "?accion=consultaTodasSolicitudes&numRUC=" + Ruc +"&indTipoContrib=" + (UriProvider.IsProveedor ? "1" : "0")); // tipoContrib=1 for proveedor
                if (!r.IsSuccessStatusCode) return null;
                
                return await r.Content.ReadAsStringAsync();
            }    
        }

        public async Task<string> GetPruebas(string numProceso)
        {
            using (var client = CreatClient())
            {
                var content = new FormUrlEncodedContent(new []
                {
                    new KeyValuePair<string, string>("accion", "consultarEtapa"),
                    new KeyValuePair<string, string>("numProceso", numProceso),
                    new KeyValuePair<string, string>("numEtapa", "2")
                });
                var r = await client.PostAsync(UriProvider.UriConsult, content);
                if (!r.IsSuccessStatusCode) return null;

                return await r.Content.ReadAsStringAsync();
            }
        }

    }
}
