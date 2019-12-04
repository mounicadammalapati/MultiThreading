using System;
using System.Collections.Generic;

namespace DatabaseMultiThreadedApplication.database
{
    public partial class Library
    {
        public Library()
        {
            Books = new HashSet<Books>();
        }

        public int Libraryid { get; set; }
        public string Libraryname { get; set; }
        public string Librarylocation { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
