namespace AutoMoreira.Core.Domains
{
    public class Contacto
    {
        public int ContactoId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Mensagem { get; private set; }
        public DateTime DataHora { get; private set; }

    }
}
