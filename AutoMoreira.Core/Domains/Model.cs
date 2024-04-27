namespace AutoMoreira.Core.Domains
{
    public class Model : EntityBase
    {
        public string Name { get; private set; } = null!;
        public int MarkId { get; private set; }

        public virtual Mark Mark { get; private set; } = null!;

        public virtual ICollection<Vehicle> Vehicles { get; private set; }

        public Model()
        {
            Vehicles = new List<Vehicle>();
        }

        public Model(string name, int markId)
        {
            name.ThrowIfNull(() => throw new Exception(DomainResource.ModelNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            markId.Throw(() => throw new Exception(DomainResource.MarkIdNeedsToBeSpecifiedException))
              .IfNegativeOrZero();

            Name = name;
            MarkId = markId;
            Vehicles = new List<Vehicle>();
        }

        public Model(int id, string name, int markId)
        {
            id.Throw(() => throw new Exception(DomainResource.ModelIdNeedsToBeSpecifiedException))
              .IfNegativeOrZero();        

            name.ThrowIfNull(() => throw new Exception(DomainResource.MarkNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            markId.Throw(() => throw new Exception(DomainResource.MarkIdNeedsToBeSpecifiedException))
             .IfNegativeOrZero();

            Id = id;
            Name = name;
            MarkId = markId;
            Vehicles = new List<Vehicle>();
        }

        public void UpdateModel(string name, int markId)
        {
            name.ThrowIfNull(() => throw new Exception(DomainResource.ModelNameNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            markId.Throw(() => throw new Exception(DomainResource.MarkIdNeedsToBeSpecifiedException))
              .IfNegativeOrZero();

            Name = name;
            MarkId = markId;
        }
    }
}
