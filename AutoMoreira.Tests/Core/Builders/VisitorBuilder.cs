namespace AutoMoreira.Tests.Core.Builders
{
    public class VisitorBuilder
    {
        private static readonly Faker _data = new("en");

        public static Visitor Visitor()
        {
            return new();
        }
        public static VisitorDTO VisitorDTO()
        {
            return new() {
                Year = _data.Date.RecentDateOnly().Year,
                Month = (MONTH)_data.Date.RecentDateOnly().Month,
                Value = _data.Random.Int(1)
            };
        }
        public static VisitorDTO VisitorDTO(Visitor visitor)
        {
            return new()
            {
                Year = visitor.Year,
                Month = visitor.Month,
                Value = visitor.Value
            };
        }      
    }
}
