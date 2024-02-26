namespace AutoMoreira.Core.Dto
{
    public class ModelDTO : EntityBaseDTO
    {
        public string Name { get; set; } = null!;

        public int MarkId { get; set; }
        public MarkDTO? Mark { get; set; }
    }
}
