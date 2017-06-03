using System;
using System.Collections.Generic;
using System.Linq;
using FacturacionElectronica.GeneradorXml.Entity;
using FacturacionElectronica.GeneradorXml.Entity.Details;
using FacturacionElectronica.GeneradorXml.Entity.Misc;
using FacturacionElectronica.GeneradorXml.Enums;
using Homologador.Fe.Model;

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
            var head = new SummaryHeader
            {
                TipoDocumentoIdentidadEmisor = TipoDocumentoIdentidad.RegistroUnicoContribuyentes,
                RucEmisor = _company.Ruc,
                FechaEmision = DateTime.Now.Date,
                NombreRazonSocialEmisor = _company.RazonSocial,
                NombreComercialEmisor = _company.NombreComercial,
                CorrelativoArchivo = new Random().Next(1, 100).ToString("D3"),
                CodigoMoneda = "PEN",
                DetallesDocumento = new List<SummaryDetail>(_lines)
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
                            Monto = 100M,
                        },
                        new TotalImporteType
                        {
                            TipoImporte = TipoValorVenta.Exonerado,
                            Monto = 100M,
                        },
                        new TotalImporteType
                        {
                            TipoImporte = TipoValorVenta.Inafecto,
                            Monto = 0M,
                        }
                    },
                    OtroImporte = new List<TotalImporteExtType>
                    {
                        new TotalImporteExtType
                        {
                            Indicador = true,
                            Monto = 0M
                        }
                    },
                    Impuesto = new List<TotalImpuestosType>
                    {
                        new TotalImpuestosType
                        {
                            Monto = 100M,
                            TipoTributo = TipoTributo.IGV_VAT
                        },
                        new TotalImpuestosType
                        {
                            Monto = 100M,
                            TipoTributo = TipoTributo.ISC_EXC
                        }
                    }
                });
            }

            return head;
        }
    }
}
