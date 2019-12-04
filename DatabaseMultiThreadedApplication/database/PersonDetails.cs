using System;
using System.Collections.Generic;

namespace DatabaseMultiThreadedApplication.database
{
    public partial class PersonDetails
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string BookName { get; set; }
        public string LibraryName { get; set; }
        public DateTime? Createddate { get; set; }
    }
}
