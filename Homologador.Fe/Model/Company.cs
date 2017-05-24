using Homologador.Model;

namespace Homologador.Fe.Model
{
    public class Company
    {
        public string Ruc { get; set; }
        public string User { get; set; }
        public string Clave { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public CompanyAddress Address { get; set; }
        public Certified Certified { get; set; }
    }
}
