﻿namespace AutoMoreira.Core.Domains
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
            Name = name;
            MarkId = markId;
            Vehicles = new List<Vehicle>();

        }

        public Model(int id, string name, int markId)
        {
            Id = id;
            Name = name;
            MarkId = markId;
            Vehicles = new List<Vehicle>();
        }

        public void UpdateModel(string name, int markId)
        {
            Name = name;
            MarkId = markId;
        }
    }
}
