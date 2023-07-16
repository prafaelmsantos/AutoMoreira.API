namespace AutoMoreira.Core.Dto
{
    public class VeiculoDTO
    {
        public int VeiculoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Marca Id")]
        public int MarcaId { get; set; }
        public MarcaDTO Marca { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Modelo Id")]
        public int ModeloId { get; set; }
        public ModeloDTO Modelo { get; set; }
        public string Versao { get; set; }
        public string Combustivel { get; set; }

        //[Range(1, 120000, ErrorMessage = "{0} tem de ser maior que 1 e menor que 1000000")]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        public int Ano { get; set; }

        public string Cor { get; set; }
        public int NumeroPortas { get; set; }
        public string Transmissao { get; set; }
        public int Cilindrada { get; set; }
        public int Potencia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!"),
        Display(Name = "Observações"),
        MaxLength(50, ErrorMessage = "O campo {0} deve ter no maximo 100 caracteres")]
        public string Observacoes { get; set; }

        [RegularExpression(@".*\.(png|bmp|gif|jpe?g)$", ErrorMessage = "Não é uma imagem válida! (.png, .bmp, .gif, .jpeg, .jpg)")]
        public string ImagemURL { get; set; }

        [DefaultValue(false)]
        public bool Novidade { get; set; }

    }
}
