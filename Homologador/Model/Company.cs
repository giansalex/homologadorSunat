namespace Homologador.Model
{
    public class Company
    {
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public CompanyAddress Address { get; set; }
    }
}
