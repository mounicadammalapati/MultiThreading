using System;
using System.Collections.Generic;

namespace TwoThreadsApplication.dbmodels
{
    public partial class Shelter
    {
        public Shelter()
        {
            Petshelter = new HashSet<Petshelter>();
        }

        public int Shelterid { get; set; }
        public string Sheltername { get; set; }
        public int? Stateid { get; set; }
        public DateTime? Lastupdated { get; set; }

        public State State { get; set; }
        public ICollection<Petshelter> Petshelter { get; set; }
    }
}
