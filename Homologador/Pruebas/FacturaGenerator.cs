using System;
using System.Collections.Generic;
using System.Linq;
using FacturacionElectronica.GeneradorXml.Entity;
using FacturacionElectronica.GeneradorXml.Entity.Details;
using FacturacionElectronica.GeneradorXml.Entity.Misc;
using FacturacionElectronica.GeneradorXml.Enums;
using Gs.Ubl.v2.Sac;
using Homologador.Model;

namespace Homologador.Pruebas
{
    public class FacturaGenerator
    {
        private string _tipoDoc;
        private int _lines;
        private GrupoPrueba _grupo;
        private Company _company;

        public FacturaGenerator ToCompany(Company company)
        {
            _company = company;
            return this;
        }

        public FacturaGenerator ForGroup(GrupoPrueba group)
        {
            _grupo = group;
            return this;
        }

        public FacturaGenerator ForDoc(string tipo)
        {
            _tipoDoc = tipo;
            return this;
        }

        public FacturaGenerator WithLines(int lines)
        {
            _lines = lines;
            return this;
        }

        public void Build()
        {
            var head = GetHead();
            SetClient(head);
            Calculator(head);
            LoadTotal(head);
        }

        private InvoiceHeader GetHead()
        {
            var header = new InvoiceHeader
            {
                TipoDocumento = _tipoDoc == "03" ? TipoDocumentoElectronico.Boleta : TipoDocumentoElectronico.Factura,
                SerieDocumento = GetSerie(),
                CorrelativoDocumento = new Random().Next(1, 1000).ToString(),
                FechaEmision = DateTime.Now.Date,
                RucEmisor = _company.Ruc,
                NombreRazonSocialEmisor = _company.RazonSocial,
                NombreComercialEmisor = _company.NombreComercial,
                TipoDocumentoIdentidadEmisor = TipoDocumentoIdentidad.RegistroUnicoContribuyentes,
                CodigoMoneda = _grupo == GrupoPrueba.OtrasMonedas ? "USD" : "PEN",
                DetallesDocumento = new List<InvoiceDetail>(_lines),
                DireccionEmisor = GetDireccion()
            };

            foreach (var item in Enumerable.Range(1, _lines))
            {
                header.DetallesDocumento.Add(new InvoiceDetail
                {
                    CodigoProducto = "PROD00" + item,
                    Cantidad = 1,
                    DescripcionProducto = "PRODUCTO PRUEBA " + item,
                    PrecioUnitario = 100,
                    UnidadMedida = "NIU"
                });
            }
            return header;
        }

        private void SetClient(InvoiceHeader header)
        {

            if (_tipoDoc == "03")
            {
                header.TipoDocumentoIdentidadCliente = TipoDocumentoIdentidad.DocumentoNacionalIdentidad;
                header.NroDocCliente = "33445566";
                header.NombreRazonSocialCliente = "ANONIMO";
            }
            else
            {
                header.TipoDocumentoIdentidadCliente = TipoDocumentoIdentidad.RegistroUnicoContribuyentes;
                header.NroDocCliente = "20100070970";
                header.NombreRazonSocialCliente = "EMPRESA ANÓNIMA";
            }
        }

        private string GetSerie()
        {
            string serie = _tipoDoc == "03" ? "BB" : "FF";
            string num;
            switch (_grupo)
            {
                case GrupoPrueba.Gravada:
                    num = "11";
                    break;
                case GrupoPrueba.InafectaExonerada:
                    num = "12";
                    break;
                case GrupoPrueba.Gratuita:
                    num = "13";
                    break;
                case GrupoPrueba.DescuentoGlobal:
                    num = "14";
                    break;
                case GrupoPrueba.ConIsc:
                    num = "30";
                    break;
                case GrupoPrueba.ConPercepcion:
                    num = "40";
                    break;
                case GrupoPrueba.OtrasMonedas:
                    num = "50";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return serie + num;
        }

        private TipoAfectacionIgv GetTipoIgv()
        {
            switch (_grupo)
            {
                case GrupoPrueba.Gratuita:
                    return TipoAfectacionIgv.GravadoRetiro;
                case GrupoPrueba.InafectaExonerada:
                    return TipoAfectacionIgv.InafectoOperacionOnerosa;
                default:
                    return TipoAfectacionIgv.InafectoOperacionOnerosa;
            }
        }

        private void Calculator(InvoiceHeader header)
        {
            var tipIgv = GetTipoIgv();
            var sum = 0M;
            foreach (var detail in header.DetallesDocumento)
            {
                detail.ValorVenta = detail.Cantidad * detail.PrecioUnitario;
                detail.Impuesto = new List<TotalImpuestosType>
                {
                    new TotalImpuestosType
                    {
                        Monto = tipIgv == TipoAfectacionIgv.GravadoOperacionOnerosa ? detail.ValorVenta * 1.18M : 0,
                        TipoAfectacion = tipIgv,
                        TipoTributo = TipoTributo.IGV_VAT
                    }
                };
                detail.PrecioAlternativos = new List<PrecioItemType>
                {
                    new PrecioItemType
                    {
                        Monto = _grupo == GrupoPrueba.Gratuita ? 0 : detail.PrecioUnitario * 1.18M,
                        TipoDePrecio = TipoPrecioVenta.PrecioUnitario
                    }
                };

                if (_grupo == GrupoPrueba.Gratuita)
                    detail.PrecioAlternativos.Add(new PrecioItemType
                    {
                        Monto = detail.PrecioUnitario,
                        TipoDePrecio = TipoPrecioVenta.ValorReferencial
                    });
                sum += detail.ValorVenta;
            }
            header.TotalTributosAdicionales = new List<TotalTributosType>
            {
                new TotalTributosType
                {
                    Id = GetOtrosConceptos(tipIgv) ,
                    MontoPagable = sum
                }
            };
        }

        private OtrosConceptosTributarios GetOtrosConceptos(TipoAfectacionIgv igv)
        {
            switch (igv)
            {
                case TipoAfectacionIgv.InafectoOperacionOnerosa:
                    return OtrosConceptosTributarios.TotalVentaOperacionesInafectas;
                case TipoAfectacionIgv.GravadoRetiro:
                    return OtrosConceptosTributarios.TotalVentaOperacionesGratuitas;
                default:
                    return OtrosConceptosTributarios.TotalVentaOperacionesGravadas;
            }
        }

        private void LoadTotal(InvoiceHeader head)
        {
            var subTotal = 0M;
            foreach (var adicional in head.TotalTributosAdicionales)
            {
                switch (adicional.Id)
                {
                    case OtrosConceptosTributarios.TotalVentaOperacionesGravadas:
                    case OtrosConceptosTributarios.TotalVentaOperacionesExoneradas:
                    case OtrosConceptosTributarios.TotalVentaOperacionesInafectas:
                        subTotal += adicional.MontoPagable;
                        break;
                }
            }
            if (_grupo == GrupoPrueba.DescuentoGlobal)
            {
                head.DescuentoGlobal = 5;
            }

            var igv = (subTotal - head.DescuentoGlobal)* 1.18M;
            head.Impuesto = new List<TotalImpuestosType>
            {
                new TotalImpuestosType
                {
                    TipoTributo = TipoTributo.IGV_VAT,
                    Monto = Math.Round(igv, 2, MidpointRounding.AwayFromZero)
                }
            };
            head.TotalVenta = Math.Round(subTotal + igv, 2, MidpointRounding.AwayFromZero);
            head.InfoAddicional = new List<AdditionalPropertyType>
            {
                new AdditionalPropertyType
                {
                    ID = "1000",
                    Value = "MONTO EN LETRAS"
                }
            };

            if (_grupo == GrupoPrueba.Gratuita)
                head.InfoAddicional.Add(new AdditionalPropertyType
                {
                    ID = "1002",
                    Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE"
                });
        }

        private DireccionType GetDireccion()
        {
            var adr = _company.Address;
            return new DireccionType
            {
                CodigoUbigueo = adr.Ubigueo,
                Departamento = adr.Departamento,
                Direccion = adr.Direccion,
                Distrito = adr.Distrito,
                Provincia = adr.Provincia,
                Zona = adr.Urbanizacion,
                CodigoPais = "PE"
            };
        }
    }
}
