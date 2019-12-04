using System;
using System.Collections.Generic;

namespace DatabaseMultiThreadedApplication.database
{
    public partial class Books
    {
        public Books()
        {
            Person = new HashSet<Person>();
        }

        public int Bookid { get; set; }
        public string Bookname { get; set; }
        public int? Libraryid { get; set; }

        public Library Library { get; set; }
        public ICollection<Person> Person { get; set; }
    }
}
