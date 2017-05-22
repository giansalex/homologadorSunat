using System;
using FacturacionElectronica.GeneradorXml.Entity;
using FacturacionElectronica.GeneradorXml.Entity.Details;
using FacturacionElectronica.GeneradorXml.Enums;

namespace Homologador.Pruebas
{
    public class NotaGenerator
    {
        private InvoiceHeader _invoice;
        public NotaGenerator From(InvoiceHeader invoice)
        {
            _invoice = invoice;
            return this;
        }

        public CreditNoteHeader BuildNcr()
        {
            var baseNote = GetBase();
            return new CreditNoteHeader(baseNote)
            {
                TipoNota = TipoNotaCreditoElectronica.AnulacionErrorRuc
            };
        }

        public DebitNoteHeader BuildNdb()
        {
            var baseNote = GetBase();
            return new DebitNoteHeader(baseNote)
            {
                TipoNota = TipoNotaDebitoElectronica.AumentoEnElValor
            };
        }

        private NotasBase<InvoiceDetail> GetBase()
        {
            var baseNote = new NotasBase<InvoiceDetail>
            {
                SerieDocumento = _invoice.SerieDocumento,
                CorrelativoDocumento = new Random().Next(1, 1000).ToString(),
                FechaEmision = _invoice.FechaEmision,
                TipoDocumentoIdentidadEmisor = _invoice.TipoDocumentoIdentidadEmisor,
                RucEmisor = _invoice.RucEmisor,
                NombreRazonSocialEmisor = _invoice.NombreRazonSocialEmisor,
                NombreComercialEmisor = _invoice.NombreComercialEmisor,
                NroDocCliente = _invoice.NroDocCliente,
                TipoDocumentoIdentidadCliente = _invoice.TipoDocumentoIdentidadCliente,
                NombreRazonSocialCliente = _invoice.NombreRazonSocialCliente,
                DocumentoRef = $"{_invoice.SerieDocumento}-{_invoice.CorrelativoDocumento}",
                TipoDocRef = _invoice.TipoDocumento,
                Motivo = "MOTIVO DESCONOCIDO",
                CodigoMoneda = _invoice.CodigoMoneda,
                Total = _invoice.TotalVenta,
                TotalTributosAdicionales = _invoice.TotalTributosAdicionales,
                DireccionEmisor = _invoice.DireccionEmisor,
                Impuesto = _invoice.Impuesto,
                DetallesDocumento = _invoice.DetallesDocumento
            };
            return baseNote;
        }
    }
}
