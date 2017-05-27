using System;
using FacturacionElectronica.GeneradorXml.Enums;
using Homologador.Fe.Model;
using Homologador.Fe.Pruebas;
using Homologador.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homologador.Fe.Tests.Pruebas
{
    [TestClass]
    public class BajaGeneratorTests
    {
        private readonly BajaGenerator _generator = new BajaGenerator();

        [TestInitialize]
        public void InitCompany()
        {
            var company = new Company
            {
                Ruc = "20123457843",
                RazonSocial = "Empresa S.A.C",
                NombreComercial = "Empresa",
                Address = new CompanyAddress
                {
                    Ubigueo = "010101",
                    Direccion = "Av las gardenias",
                    Departamento = "LIMA",
                    Provincia = "LIMA",
                    Distrito = "PUEBLO LIBRE",
                    Urbanizacion = "ESMERALDAS"
                }
            };
            _generator.ToCompany(company);

        }

        [TestMethod]
        public void BuildWith_5Lines_Test()
        {

            var voided = _generator
                        .WithLines(5)
                        .Build();

            Assert.IsNotNull(voided);
            Assert.IsTrue(voided.TipoDocumentoIdentidadEmisor == TipoDocumentoIdentidad.RegistroUnicoContribuyentes);
            Assert.IsTrue(voided.FechaEmision > DateTime.Now.Subtract(TimeSpan.FromDays(5)));
            Assert.IsTrue(voided.DetallesDocumento.Count == 5);

        }

        [TestMethod]
        public void BuildWith_2Lines_Test()
        {

            var voided = _generator
                .WithLines(2)
                .Build();

            Assert.IsNotNull(voided);
            Assert.IsTrue(voided.TipoDocumentoIdentidadEmisor == TipoDocumentoIdentidad.RegistroUnicoContribuyentes);
            Assert.IsTrue(voided.FechaEmision > DateTime.Now.Subtract(TimeSpan.FromDays(5)));
            Assert.IsTrue(voided.DetallesDocumento.Count == 2);

        }
    }
}