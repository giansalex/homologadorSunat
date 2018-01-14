using System;
using System.Security.Cryptography.X509Certificates;
using FacturacionElectronica.GeneradorXml;
using FacturacionElectronica.GeneradorXml.Entity;
using Homologador.Fe.Model;

namespace Homologador.Fe.Manage
{
    /// <summary>
    /// Class XmlManager (Generador de Archivos XML firmados desde db models).
    /// </summary>
    public class XmlManager
    {
        private readonly XmlDocGenerator _xmlGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlManager"/> class.
        /// </summary>
        /// <param name="company">The company.</param>
        public XmlManager(Company company)
        {
            var cert = new X509Certificate2(company.Certified.Content, company.Certified.Password);
            _xmlGenerator = new XmlDocGenerator(cert);
        }

        #region Export
        /// <summary>
        /// XMLs for venta (Include FAC, BOL, NCR, NDB).
        /// </summary>
        /// <param name="venta">The venta.</param>
        /// <returns>XmlResult.</returns>
        public XmlResult ToXml(InvoiceHeader venta)
        {
            try
            {
                return XmlForVentaInternal(venta);
            }
            catch (Exception e)
            {
                return ForException(e);
            }
        }

        /// <summary>
        /// XMLs for venta (Include FAC, BOL, NCR, NDB).
        /// </summary>
        /// <param name="venta">The venta.</param>
        /// <returns>XmlResult.</returns>
        public XmlResult ToXml(CreditNoteHeader venta)
        {
            try
            {
                return XmlForVentaInternal(venta);
            }
            catch (Exception e)
            {
                return ForException(e);
            }
        }

        /// <summary>
        /// XMLs for venta (Include FAC, BOL, NCR, NDB).
        /// </summary>
        /// <param name="venta">The venta.</param>
        /// <returns>XmlResult.</returns>
        public XmlResult ToXml(DebitNoteHeader venta)
        {
            try
            {
                return XmlForVentaInternal(venta);
            }
            catch (Exception e)
            {
                return ForException(e);
            }
        }

        /// <summary>
        /// XMLs for resumen.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <returns>XmlResult.</returns>
        public XmlResult ToXml(SummaryHeader header)
        {
            try
            {
                return XmlForaResumenInternal(header);
            }
            catch (Exception e)
            {
                return ForException(e);
            }
        }

        /// <summary>
        /// XMLs for baja.
        /// </summary>
        /// <param name="baja">The baja.</param>
        /// <returns>XmlResult.</returns>
        public XmlResult ToXml(VoidedHeader baja)
        {
            try
            {
                return XmlForBajaInternal(baja);
            }
            catch (Exception e)
            {
                return ForException(e);
            }
        } 
        #endregion

        private XmlResult XmlForVentaInternal(InvoiceHeader venta)
        {
            var res = _xmlGenerator.GeneraDocumentoInvoice(venta);
            return new XmlResult
            {
                Success = res.Success,
                Description = res.Error,
                Path = res.FileName,
                Content = res.Content,
                Code = res.Success ? null : CodeStatus.ConErrores
            };
        }

        private XmlResult XmlForVentaInternal(DebitNoteHeader venta)
        {
            var res = _xmlGenerator.GenerarDocumentoDebitNote(venta);
            return new XmlResult
            {
                Success = res.Success,
                Description = res.Error,
                Path = res.FileName,
                Content = res.Content,
                Code = res.Success ? null : CodeStatus.ConErrores
            };
        }

        private XmlResult XmlForVentaInternal(CreditNoteHeader venta)
        {
            var res = _xmlGenerator.GenerarDocumentoCreditNote(venta);
            return new XmlResult
            {
                Success = res.Success,
                Description = res.Error,
                Path = res.FileName,
                Content = res.Content,
                Code = res.Success ? null : CodeStatus.ConErrores
            };
        }
        private XmlResult XmlForaResumenInternal(SummaryHeader header)
        {
            var res = _xmlGenerator.GenerarDocumentoSummary(header, true);

            return new XmlResult
            {
                Success = res.Success,
                Description = res.Error,
                Path = res.FileName,
                Content = res.Content,
                Code = res.Success ? null : CodeStatus.ConErrores
            };
        }
        private XmlResult XmlForBajaInternal(VoidedHeader baja)
        {
            var res = _xmlGenerator.GenerarDocumentoVoided(baja);
            return new XmlResult
            {
                Success = res.Success,
                Description = res.Error,
                Path = res.FileName,
                Content = res.Content,
                Code = res.Success ? null : CodeStatus.ConErrores
            };
        }

        private XmlResult ForException(Exception e)
        {
            return new XmlResult
            {
                Success = false,
                Description = e.Message,
                Code = CodeStatus.ConErrores
            };
        }
    }
}
