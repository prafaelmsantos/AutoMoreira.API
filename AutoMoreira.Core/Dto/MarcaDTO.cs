namespace AutoMoreira.Core.Dto
{
    public class MarcaDTO
    {
        [Key]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome da Marca")]
        public string MarcaNome { get; set; }
    }
}
