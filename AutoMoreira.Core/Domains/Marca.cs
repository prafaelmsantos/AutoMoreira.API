namespace AutoMoreira.Core.Domains
{
    public class Marca
    {
        public int MarcaId { get; private set; }
        public string MarcaNome { get; private set; }

        private readonly List<Modelo> _modelos;
        public virtual ICollection<Modelo> Modelos => _modelos;

        private readonly List<Veiculo> _veiculos;
        public virtual ICollection<Veiculo> Veiculos => _veiculos;

        public Marca(){ }

        public Marca(int marcaId, string marcaNome)
        {
            MarcaId = marcaId;
            MarcaNome = marcaNome;

            _modelos = new List<Modelo>();
            _veiculos = new List<Veiculo>();
        }
    }
}
