using System;
using System.Collections.Generic;
using System.Linq;
using FacturacionElectronica.GeneradorXml.Entity;
using FacturacionElectronica.GeneradorXml.Entity.Details;
using FacturacionElectronica.GeneradorXml.Entity.Misc;
using FacturacionElectronica.GeneradorXml.Enums;
using Homologador.Model;

namespace Homologador.Fe.Pruebas
{
    public class ResumenGenerator
    {
        private int _lines;
        private Company _company;

        public ResumenGenerator ToCompany(Company company)
        {
            _company = company;
            return this;
        }

        public ResumenGenerator WithLines(int lines)
        {
            _lines = lines;
            return this;
        }

        public SummaryHeader Build()
        {
            var head = new SummaryHeader()
            {
                TipoDocumentoIdentidadEmisor = TipoDocumentoIdentidad.RegistroUnicoContribuyentes,
                RucEmisor = _company.Ruc,
                FechaEmision = DateTime.Now.Date,
                NombreRazonSocialEmisor = _company.RazonSocial,
                NombreComercialEmisor = _company.NombreComercial,
                CorrelativoArchivo = new Random().Next(1, 100).ToString("D3"),
                CodigoMoneda = "PEN"
            };

            foreach (var item in Enumerable.Range(1, _lines))
            {
                head.DetallesDocumento.Add(new SummaryDetail
                {
                    TipoDocumento = TipoDocumentoElectronico.Boleta,
                    TipoDocumentoIdentidadCliente = TipoDocumentoIdentidad.DocumentoNacionalIdentidad,
                    NroDocCliente = "99887766",
                    SerieDocumento = "B00" + item,
                    NroCorrelativoInicial = "456",
                    NroCorrelativoFinal = "764",
                    Importe = new List<TotalImporteType>
                    {
                        new TotalImporteType
                        {
                            TipoImporte = TipoValorVenta.Gravado,
                            Monto = 98232.00M,
                        },
                        new TotalImporteType
                        {
                            TipoImporte = TipoValorVenta.Exonerado,
                            Monto = 20,
                        },
                        new TotalImporteType
                        {
                            TipoImporte = TipoValorVenta.Inafecto,
                            Monto = 232,
                        }
                    },
                    OtroImporte = new List<TotalImporteExtType>
                    {
                        new TotalImporteExtType
                        {
                            Indicador = true,
                            Monto = 5
                        }
                    },
                    Impuesto = new List<TotalImpuestosType>
                    {
                        new TotalImpuestosType
                        {
                            Monto = 17681.76M,
                            TipoTributo = TipoTributo.IGV_VAT
                        },
                        new TotalImpuestosType
                        {
                            Monto = 1200,
                            TipoTributo = TipoTributo.OTROS_OTH
                        }
                    }
                });
            }

            return head;
        }
    }
}
