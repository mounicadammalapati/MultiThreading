using System;
using System.Collections.Generic;

namespace TwoThreadsApplication.dbmodels
{
    public partial class Petshelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ShelterId { get; set; }
        public DateTime? Lastupdated { get; set; }

        public Shelter Shelter { get; set; }
    }
}
