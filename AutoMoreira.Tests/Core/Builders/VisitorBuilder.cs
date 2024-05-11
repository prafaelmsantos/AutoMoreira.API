namespace AutoMoreira.Tests.Core.Builders
{
    public class VisitorBuilder
    {
        private static readonly Faker data = new("en");

        public static Visitor Visitor()
        {
            return new();
        }
        public static VisitorDTO VisitorDTO()
        {
            return new()
            {
                Year = data.Date.RecentDateOnly().Year,
                Month = (MONTH)data.Date.RecentDateOnly().Month,
                Value = data.Random.Int(1)
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
