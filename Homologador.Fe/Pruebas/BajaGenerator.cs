using System;
using System.Collections.Generic;
using System.Linq;
using FacturacionElectronica.GeneradorXml.Entity;
using FacturacionElectronica.GeneradorXml.Entity.Details;
using FacturacionElectronica.GeneradorXml.Enums;
using Homologador.Fe.Model;

namespace Homologador.Fe.Pruebas
{
    public class BajaGenerator
    {
        private int _lines;
        private Company _company;

        public BajaGenerator ToCompany(Company company)
        {
            _company = company;
            return this;
        }
        public BajaGenerator WithLines(int lines)
        {
            _lines = lines;
            return this;
        }

        public VoidedHeader Build()
        {
            var head = new VoidedHeader
            {
                TipoDocumentoIdentidadEmisor = TipoDocumentoIdentidad.RegistroUnicoContribuyentes,
                RucEmisor = _company.Ruc,
                FechaEmision = DateTime.Now.Date,
                NombreRazonSocialEmisor = _company.RazonSocial,
                NombreComercialEmisor = _company.NombreComercial,
                CorrelativoArchivo = new Random().Next(1, 100).ToString("D3"),
                DetallesDocumento = new List<VoidedDetail>(_lines)
            };

            foreach (var item in Enumerable.Range(1, _lines))
            {
                head.DetallesDocumento.Add(new VoidedDetail
                {
                    TipoDocumento = TipoDocumentoElectronico.Factura,
                    SerieDocumento = "F001",
                    CorrelativoDocumento = item.ToString(),
                    Motivo = "ERROR EN SISTEMA"
                });
            }

            return head;
        }
    }
}
