/*
 * Codigos Validos
  [
    {"id":"01","nombre":"Por Enviar"},
    {"id":"02","nombre":"Con Errores"},
    {"id":"03","nombre":"Enviado y Aceptado SUNAT"},
    {"id":"04","nombre":"Enviado y Aceptado SUNAT con Obs."},
    {"id":"05","nombre":"Enviado y Anulado por SUNAT"},
    {"id":"06","nombre":"Enviado a SUNAT Por Procesar"},
    {"id":"07","nombre":"Enviado a SUNAT Procesando"},
    {"id":"08","nombre":"Rechazado por SUNAT"}
    {"id":"09","nombre":"Error en consulta ticket"}
  ]
 */
namespace Homologador.Fe.Manage
{
    public class BillResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BillResult"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        public string Description { get; set; }
        public string Code { get; set; }
    }

    public class XmlResult : BillResult
    {
        public string Path { get; set; }
        public byte[] Content { get; set; }
    }

    public class WsResult : BillResult
    {
        /// <summary>
        /// Gets or sets the content Zip CDR.
        /// </summary>
        /// <value>The content CDR.</value>
        public byte[] ContentZipCdr { get; set; }

        public byte[] XmlContent { get; set; }
    }
    
    public sealed class CodeStatus
    {
        public const string PorEnviar = "01";
        public const string ConErrores = "02";
        public const string EnviadoAceptado = "03";
        public const string EnviadoAceptadoConObs = "04";
        public const string EnviadoAnulado = "05";
        public const string EnviadoPorProcesar = "06";
        public const string EnviadoProcesando = "07";
        public const string Rechazado = "08";
        /// <summary>
        /// Error al consultar el Ticket, valido para resumen y bajas.
        /// </summary>
        public const string ErrorStatusTicket = "09";
    }
}
