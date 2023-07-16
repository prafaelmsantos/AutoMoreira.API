namespace AutoMoreira.Core.Domains
{
    public class Veiculo
    {
        public int VeiculoId { get; private set; }

        public int MarcaId { get; private set; }
        public virtual Marca Marca { get; private set; }

        public int ModeloId { get; private set; }
        public virtual Modelo Modelo { get; private set; }
        public string Versao { get; private set; }
        public COMBUSTIVEL Combustivel { get; private set; }
        public double Preco { get; private set; }
        public int Ano { get; private set; }
        public string Cor { get; private set; }
        public int NumeroPortas { get; private set; }
        public string Transmissao { get; private set; }
        public int Cilindrada { get; private set; }
        public int Potencia { get; private set; }
        public string Observacoes { get; private set; }
        public string ImagemURL { get; private set; }
        public bool Novidade { get; private set; }

        public Veiculo(){}

        public Veiculo(int veiculoId, int marcaId, int modeloId, string versao, COMBUSTIVEL combustivel, 
            double preco, int ano, string cor, int numeroPortas, string transmissao, int cilindrada, int potencia, 
            string observacoes, string imagemURL, bool novidade)
        {
            VeiculoId = veiculoId;
            MarcaId = marcaId;
            ModeloId = modeloId;
            Versao = versao;
            Combustivel = combustivel;
            Preco = preco;
            Ano = ano;
            Cor = cor;
            NumeroPortas = numeroPortas;
            Transmissao = transmissao;
            Cilindrada = cilindrada;
            Potencia = potencia;
            Observacoes = observacoes;
            ImagemURL = imagemURL;
            Novidade = novidade;
        }
    }
}
