namespace Homologador
{
    public class Caso
    {
        public int Grupo { get; set; }
        public string Codigo { get; set; }
        public string  Descripcion { get; set; }
        public string Documento { get; set; }
        public int Lines { get; set; }
        public string Estado { get; set; }
        public bool HasNotaCredit { get; set; }
        public bool HasNotaDebit { get; set; }
    }
}
