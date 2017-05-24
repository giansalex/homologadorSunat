using System;
using System.Security.Cryptography.X509Certificates;
using FacturacionElectronica.GeneradorXml;
using FacturacionElectronica.GeneradorXml.Entity;
using FacturacionElectronica.GeneradorXml.Res;
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
            var result = new OperationResult();
            var res = _xmlGenerator.GeneraDocumentoInvoice(ref result, venta);
            return new XmlResult
            {
                Success = result.Success,
                Description = result.Error,
                Path = res.FileName,
                Content = res.Content,
                Code = result.Success ? null : CodeStatus.ConErrores
            };
        }

        private XmlResult XmlForVentaInternal(DebitNoteHeader venta)
        {
            var result = new OperationResult();
            var res = _xmlGenerator.GenerarDocumentoDebitNote(ref result, venta);
            return new XmlResult
            {
                Success = result.Success,
                Description = result.Error,
                Path = res.FileName,
                Content = res.Content,
                Code = result.Success ? null : CodeStatus.ConErrores
            };
        }

        private XmlResult XmlForVentaInternal(CreditNoteHeader venta)
        {
            var result = new OperationResult();
            var res = _xmlGenerator.GenerarDocumentoCreditNote(ref result, venta);
            return new XmlResult
            {
                Success = result.Success,
                Description = result.Error,
                Path = res.FileName,
                Content = res.Content,
                Code = result.Success ? null : CodeStatus.ConErrores
            };
        }
        private XmlResult XmlForaResumenInternal(SummaryHeader header)
        {
            var result = new OperationResult();
            var res = _xmlGenerator.GenerarDocumentoSummary(ref result, header);

            return new XmlResult
            {
                Success = result.Success,
                Description = result.Error,
                Path = res.FileName,
                Content = res.Content,
                Code = result.Success ? null : CodeStatus.ConErrores
            };
        }
        private XmlResult XmlForBajaInternal(VoidedHeader baja)
        {
            var result = new OperationResult();
            var res = _xmlGenerator.GenerarDocumentoVoided(ref result, baja);
            return new XmlResult
            {
                Success = result.Success,
                Description = result.Error,
                Path = res.FileName,
                Content = res.Content,
                Code = result.Success ? null : CodeStatus.ConErrores
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
