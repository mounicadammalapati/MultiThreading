using System;
using System.Collections.Generic;

namespace TwoThreadsApplication.dbmodels
{
    public partial class State
    {
        public State()
        {
            Shelter = new HashSet<Shelter>();
        }

        public int Stateid { get; set; }
        public string Statename { get; set; }
        public DateTime? Lastupdate { get; set; }

        public ICollection<Shelter> Shelter { get; set; }
    }
}
