namespace AutoMoreira.Core.Dto
{
    public class ModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MarkId { get; set; }
        public MarkDTO Mark { get; set; }
    }
}
