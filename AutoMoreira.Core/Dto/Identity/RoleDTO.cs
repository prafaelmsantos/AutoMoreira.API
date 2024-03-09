namespace AutoMoreira.Core.Dto.Identity
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDefault { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
