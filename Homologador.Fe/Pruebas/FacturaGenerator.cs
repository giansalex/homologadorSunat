using System;
using System.Collections.Generic;
using System.Linq;
using FacturacionElectronica.GeneradorXml.Entity;
using FacturacionElectronica.GeneradorXml.Entity.Details;
using FacturacionElectronica.GeneradorXml.Entity.Misc;
using FacturacionElectronica.GeneradorXml.Enums;
using Gs.Ubl.v2.Cac;
using Gs.Ubl.v2.Sac;
using Gs.Ubl.v2.Udt;
using Homologador.Fe.Model;
using Homologador.Fe.Properties;

namespace Homologador.Fe.Pruebas
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

        public InvoiceHeader Build()
        {
            var head = GetHead();
            SetClient(head);
            Calculator(head);
            LoadTotal(head);
            LoadExtraHeadsAndLegends(head);
            return head;
        }

        private InvoiceHeader GetHead()
        {
            var header = new InvoiceHeader
            {
                TipoDocumento = _tipoDoc == "03" ? TipoDocumentoElectronico.Boleta : TipoDocumentoElectronico.Factura,
                SerieDocumento = GetSerie(),
                CorrelativoDocumento = GenCorrelativo(),
                FechaEmision = DateTime.Now.Date,
                RucEmisor = _company.Ruc,
                NombreRazonSocialEmisor = _company.RazonSocial,
                NombreComercialEmisor = _company.NombreComercial,
                TipoDocumentoIdentidadEmisor = TipoDocumentoIdentidad.RegistroUnicoContribuyentes,
                CodigoMoneda = _grupo == GrupoPrueba.OtrasMonedas ? "USD" : "PEN",
                DetallesDocumento = new List<InvoiceDetail>(_lines),
                Impuesto = new List<TotalImpuestosType>(),
                DireccionEmisor = GetDireccion(),
                Compra = "000023"
            };

            SetCustomBodyByGroup(header);

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
                header.TipoDocumentoIdentidadCliente = _grupo == GrupoPrueba.ComercioExterior 
                    ? TipoDocumentoIdentidad.NoDomiciliado 
                    : TipoDocumentoIdentidad.RegistroUnicoContribuyentes;
                header.NroDocCliente = "20100070970";
                header.NombreRazonSocialCliente = "SUPER COMPANY";
            }
        }

        private string GetSerie()
        {
            var isBol = _tipoDoc == "03";
            var prefix = isBol ? "B" : "F";
            var serie = isBol ? "BB" : "FF";
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
                case GrupoPrueba.Detraccciones:
                    num = "60";
                    break;
                case GrupoPrueba.ComercioExterior:
                    num = "70";
                    break;
                case GrupoPrueba.FacturaGuia:
                    num = "80";
                    break;
                case GrupoPrueba.DatosNoTributarios:
                    num = "90";
                    break;
                case GrupoPrueba.Anticipos:
                    serie = prefix;
                    num = "100";
                    break;
                case GrupoPrueba.RegulacionAnticipos:
                    serie = prefix;
                    num = "110";
                    break;
                case GrupoPrueba.EmisorItinerante:
                    serie = prefix;
                    num = "100";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(num), Resources.MsgSerieNotFound);
            }
            return serie + num;
        }

        private void SetCustomBodyByGroup(InvoiceHeader head)
        {
            switch (_grupo)
            {
                case GrupoPrueba.Anticipos:
                    head.TipoOperacion = TipoOperacion.VentaInternaAnticipos;
                    break;
                case GrupoPrueba.EmisorItinerante:
                    head.TipoOperacion = TipoOperacion.VentaItinerante;
                    head.GuiaRemisionReferencia = new List<GuiaRemisionType>
                    {
                        new GuiaRemisionType
                        {
                            IdTipoGuiaRemision = "09",
                            NumeroGuiaRemision = "T001-1"
                        }
                    };
                    break;
                case GrupoPrueba.RegulacionAnticipos:
                    head.TotalAnticipos = 10;
                    head.Anticipos = new List<AnticipoType>
                    {
                        new AnticipoType
                        {
                            MontoAnticipo = head.TotalAnticipos.Value,
                            NroDocumentRel = "F001-1",
                            RucEmisorDoc = head.RucEmisor,
                            TipoDocRel = DocRelTributario.FacturaAnticipos
                        }
                    }; 
                    break;
            }
        }
        private TipoAfectacionIgv GetTipoIgv()
        {
            switch (_grupo)
            {
                case GrupoPrueba.Gratuita:
                    return TipoAfectacionIgv.GravadoRetiro;
                case GrupoPrueba.InafectaExonerada:
                    return TipoAfectacionIgv.InafectoOperacionOnerosa;
                case GrupoPrueba.ComercioExterior:
                    return TipoAfectacionIgv.Exportacion;
                default:
                    return TipoAfectacionIgv.GravadoOperacionOnerosa;
            }
        }

        private void Calculator(InvoiceHeader header)
        {
            var tipIgv = GetTipoIgv();
            var sum = 0M;
            foreach (var detail in header.DetallesDocumento)
            {
                detail.ValorVenta = detail.Cantidad * detail.PrecioUnitario;
                var isc = 0M;

                detail.Impuesto = new List<TotalImpuestosType>();
                if (_grupo == GrupoPrueba.ConIsc)
                {
                    isc = 0.17M * detail.PrecioUnitario * detail.Cantidad;
                    detail.Impuesto.Add(new TotalImpuestosType
                    {
                        TipoIsc = TipoSistemaIsc.SistemValor,
                        TipoTributo = TipoTributo.ISC_EXC,
                        Monto =  isc// 17% ISC
                    });
                }


                detail.Impuesto.Add(new TotalImpuestosType
                {
                    Monto = tipIgv == TipoAfectacionIgv.GravadoOperacionOnerosa ? (detail.ValorVenta + isc) * 0.18M : 0,
                    TipoAfectacion = tipIgv,
                    TipoTributo = TipoTributo.IGV_VAT
                });

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
                case TipoAfectacionIgv.Exportacion:
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
            var mtoGrav = 0M;
            foreach (var adicional in head.TotalTributosAdicionales)
            {
                switch (adicional.Id)
                {
                    case OtrosConceptosTributarios.TotalVentaOperacionesGravadas:
                        mtoGrav += adicional.MontoPagable;
                        goto case OtrosConceptosTributarios.TotalVentaOperacionesExoneradas;
                    case OtrosConceptosTributarios.TotalVentaOperacionesExoneradas:
                    case OtrosConceptosTributarios.TotalVentaOperacionesInafectas:
                        subTotal += adicional.MontoPagable;
                        break;
                }
            }
            if (_grupo == GrupoPrueba.DescuentoGlobal)
            {
                head.DescuentoGlobal = 5; //TODO:  Se aplica a los Grav,Inaf,Exon.
            }

            var isc = 0M;
            if (_grupo == GrupoPrueba.ConIsc)
            {
                isc = subTotal * 0.17M;
                head.Impuesto.Add(new TotalImpuestosType
                {
                    TipoTributo = TipoTributo.ISC_EXC,
                    Monto = isc
                });
            }

            var igv = (mtoGrav + isc - head.DescuentoGlobal)* 0.18M;
            head.Impuesto.Add(new TotalImpuestosType
            {
                TipoTributo = TipoTributo.IGV_VAT,
                Monto = Math.Round(igv, 2, MidpointRounding.AwayFromZero)
            });

            head.TotalVenta = Math.Round(subTotal + igv + isc, 2, MidpointRounding.AwayFromZero);
            head.InfoAddicional = new List<AdditionalPropertyType>
            {
                new AdditionalPropertyType
                {
                    ID = "1000",
                    Value = "MONTO EN LETRAS"
                }
            };
        }

        private void LoadExtraHeadsAndLegends(InvoiceHeader head)
        {
            switch (_grupo)
            {
                case GrupoPrueba.Gratuita:
                    head.InfoAddicional.Add(new AdditionalPropertyType
                    {
                        ID = "1002",
                        Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE"
                    });
                    break;
                case GrupoPrueba.ConPercepcion:
                    var val = head.TotalVenta * 0.02M; // 2% percepcion
                    head.TotalTributosAdicionales.Add(new TotalTributosType
                    {
                        Id = OtrosConceptosTributarios.Percepciones,
                        MontoPagable = val,
                        MontoTotal = head.TotalVenta + val
                    });
                    head.InfoAddicional.Add(new AdditionalPropertyType
                    {
                        ID = "2000",
                        Value = "COMPROBANTE DE PERCEPCION"
                    });
                    break;
                case GrupoPrueba.Detraccciones:
                    head.TotalTributosAdicionales.Add(new TotalTributosType
                    {
                        Id = OtrosConceptosTributarios.Detracciones,
                        MontoPagable = head.TotalVenta * 0.09M,// 9% detraccion
                        Porcentaje = 9.00M
                    });
                    head.InfoAddicional.AddRange(new[]{
                        new AdditionalPropertyType
                        {
                            ID = "3000",
                            Value = "004"
                        },
                        new AdditionalPropertyType
                        {
                            ID = "3001",
                            Value = "192-99982-1"
                        }
                    });
                    break;
                case GrupoPrueba.FacturaGuia:
                    head.GuiaEmbebida = new SUNATEmbededDespatchAdviceType
                    {
                        DeliveryAddress = new AddressType
                        {
                            ID = "150102",
                            StreetName = "AV. REPUBLICA DE ARGENTINA N? 2976 URB",
                            CitySubdivisionName = "LIMA 01",
                            CityName = "LIMA",
                            CountrySubentity = "LIMA",
                            District = "LIMA",
                            Country = new CountryType
                            {
                                IdentificationCode = "PE"
                            }
                        },
                        OriginAddress = new AddressType
                        {
                            ID = "150121",
                            StreetName = "AV. REPUBLICA DE ARGENTINA N? 2976 URB",
                            CitySubdivisionName = "LIMA 01",
                            CityName = "LIMA",
                            CountrySubentity = "LIMA",
                            District = "LIMA",
                            Country = new CountryType
                            {
                                IdentificationCode = "PE"
                            }
                        },
                        SUNATCarrierParty = new SUNATCarrierPartyType
                        {
                            CustomerAssignedAccountID = "20123456789",
                            AdditionalAccountID = new IdentifierType[] { "6" },
                        },
                        DriverParty = new DriverPartyType
                        {
                            Party = new PartyType
                            {
                                PartyIdentification = new PartyIdentificationType[] { "1111111111" }
                            }
                        },
                        SUNATRoadTransport = new []
                        {
                            new SUNATRoadTransportType
                            {
                                LicensePlateID   = "B9Y-778",
                                TransportAuthorizationCode = "1",
                                BrandName = "Scania"
                            }
                        },
                        TransportModeCode = "01",
                        GrossWeightMeasure = new MeasureType
                        {
                            unitCode = "KGM",
                            Value = 10.00M
                        }
                    };
                    break;
                case GrupoPrueba.EmisorItinerante:
                    head.InfoAddicional.AddRange(new []
                    {
                        new AdditionalPropertyType
                        {
                            ID = "2005", // Segun catalogo
                            Value = "Venta realizada por emisor itinerante"
                        },
                        new AdditionalPropertyType
                        {
                            ID = "3000", // Segun personal de SUNAT y necesario para homologacion PSE.
                            Value = "Venta realizada por emisor itinerante"
                        }
                    });
                    break;
            }

        }

        /// <summary>
        /// Gens the correlativo.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string GenCorrelativo()
        {
            var ticks = DateTime.Now.Ticks.ToString();
            return ticks.Substring(ticks.Length - 8, 8);
            //return new Random().Next(1, 100000).ToString();
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
