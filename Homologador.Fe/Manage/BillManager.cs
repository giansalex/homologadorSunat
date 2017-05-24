using System.IO;
using FacturacionElectronica.GeneradorXml.Entity;
using FacturacionElectronica.Homologacion;
using FacturacionElectronica.Homologacion.Res;
using Homologador.Fe.Model;

namespace Homologador.Fe.Manage
{
    /// <summary>
    /// Class VentaManager (Controla el envio de documento electronicos).
    /// </summary>
    public class BillManager
    {
        private readonly XmlManager _xmlGenerator;
        private readonly SunatManager _wsManager;
        /// <summary>
        /// Initializes a new instance of the <see cref="BillManager"/> class.
        /// </summary>
        /// <param name="company">The company.</param>
        public BillManager(Company company)
        {
            _xmlGenerator = new XmlManager(company);
            var config = new SolConfig
            {
                Ruc = company.Ruc,
                Usuario = company.User,
                Clave = company.Clave,
                Service = ServiceSunatType.Homologacion
            };
            _wsManager = new SunatManager(config);
        }

        #region Export
        /// <summary>
        /// Sends the specified venta.
        /// </summary>
        /// <param name="debit">The debit.</param>
        /// <returns>BillResult.</returns>
        public BillResult Send(DebitNoteHeader debit)
        {
            var xmlRes = _xmlGenerator.ToXml(debit);
            if (!xmlRes.Success) return xmlRes;
            
            return SendDoc(xmlRes.Path, xmlRes.Content);
        }

        /// <summary>
        /// Sends the specified venta.
        /// </summary>
        /// <param name="credit">The credit.</param>
        /// <returns>BillResult.</returns>
        public BillResult Send(CreditNoteHeader credit)
        {
            var xmlRes = _xmlGenerator.ToXml(credit);
            if (!xmlRes.Success) return xmlRes;

            return SendDoc(xmlRes.Path, xmlRes.Content);
        }


        /// <summary>
        /// Sends the specified venta.
        /// </summary>
        /// <param name="venta">The venta.</param>
        /// <returns>BillResult.</returns>
        public BillResult Send(InvoiceHeader venta)
        {
            var xmlRes = _xmlGenerator.ToXml(venta);
            if (!xmlRes.Success) return xmlRes;

            return SendDoc(xmlRes.Path, xmlRes.Content);
        }

        /// <summary>
        /// Sends the specified resumen.
        /// </summary>
        /// <param name="resumen">The resumen.</param>
        /// <returns>BillResult.</returns>
        public BillResult Send(SummaryHeader resumen)
        {
            var xmlRes = _xmlGenerator.ToXml(resumen);
            if (!xmlRes.Success) return xmlRes;

            return SendSumm(xmlRes.Path, xmlRes.Content);
        }


        /// <summary>
        /// Sends the specified baja.
        /// </summary>
        /// <param name="baja">The baja.</param>
        /// <returns>BillResult.</returns>
        public BillResult Send(VoidedHeader baja)
        {
            var xmlRes = _xmlGenerator.ToXml(baja);
            if (!xmlRes.Success) return xmlRes;
            return SendSumm(xmlRes.Path, xmlRes.Content);
        } 
        #endregion

        private WsResult SendDoc(string xmlfile, byte[] content)
        {
            var res = _wsManager.SendDocument(xmlfile, content);
            return FromSunatResponse(res, xmlfile);
        }
        private WsResult SendSumm(string xmlPath, byte[] content)
        {
            var res = _wsManager.SendSummary(xmlPath, content);
            var result = new WsResult
            {
                Success = res.Success
            };
            if (res.Success)
            {
                result.Code = CodeStatus.EnviadoPorProcesar;
                result.Description = res.Ticket;
            }
            else
            {
                result.Code = CodeStatus.ConErrores;
                result.Description = $"{res.Error.Code} - {res.Error.Description}";
            }
            return result;
        }

        private WsResult FromSunatResponse(SunatResponse response, string xmlPath)
        {
            var res = new WsResult
            {
                Success = response.Success
            };

            if (res.Success)
            {
                var app = response.ApplicationResponse;
                res.Description = app.Descripcion;
                res.ContentZipCdr = response.ContentZip;
                res.Code = app.Codigo.Equals("0")
                    ? (app.Notas.Length == 0 ? CodeStatus.EnviadoAceptado : CodeStatus.EnviadoAceptadoConObs)
                    : CodeStatus.Rechazado;
            }
            else
            {
                res.Description = $"{response.Error.Code} - {response.Error.Description}";
                res.Code = CodeStatus.ConErrores;
            }

            return res;
        }
    }
}
