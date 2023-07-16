namespace AutoMoreira.Core.Dto
{
    public class ModeloDTO
    {
        public int ModeloId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome do Modelo")]
        public string ModeloNome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Marca Id")]
        public int MarcaId { get; set; }
        public MarcaDTO Marca { get; set; }
    }
}
