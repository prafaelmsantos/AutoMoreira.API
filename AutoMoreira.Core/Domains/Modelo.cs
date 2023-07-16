namespace AutoMoreira.Core.Domains
{
    public class Modelo
    {
        public int ModeloId { get; private set; }
        public string ModeloNome { get; private set; }
        public int MarcaId { get; private set; }

        public virtual Marca Marca { get; private set; }


        private readonly List<Veiculo> _veiculos;
        public virtual ICollection<Veiculo> Veiculos => _veiculos;

        public Modelo(){}

        public Modelo(int modeloId, string modeloNome, int marcaId)
        {
            ModeloId = modeloId;
            ModeloNome = modeloNome;
            MarcaId = marcaId;

            _veiculos = new List<Veiculo>();
        }
    }
}
