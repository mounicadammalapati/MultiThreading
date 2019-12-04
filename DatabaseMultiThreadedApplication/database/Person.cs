using System;
using System.Collections.Generic;

namespace DatabaseMultiThreadedApplication.database
{
    public partial class Person
    {
        public int Personid { get; set; }
        public string PersonName { get; set; }
        public int? Bookid { get; set; }

        public Books Book { get; set; }
    }
}
