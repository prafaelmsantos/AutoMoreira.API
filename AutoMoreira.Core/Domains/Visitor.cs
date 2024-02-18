namespace AutoMoreira.Core.Domains
{
    public class Visitor : EntityBase
    {
        public int Year { get; private set; }
        public MONTH Month { get; private set; }
        public int Value { get; private set; }

        public Visitor() { }

        public Visitor(MONTH month)
        {
            Year = DateTime.Now.Year;
            Month = month;
            Value = 1;
        }

        public void SetValue()
        {
            Value++;
        }


    }
}
