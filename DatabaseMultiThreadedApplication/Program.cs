using System;
using System.Linq;
using System.Collections;
using DatabaseMultiThreadedApplication.database;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DatabaseMultiThreadedApplication
{
  public  class Program
    {
      
        public static void InsertLibrary()
        {
            //librarydbContext db = new librarydbContext();
            //int i = 0;
            //Console.WriteLine("start date"+ System.DateTime.Now);
            //while (i < 20000)
            //{
            //    var lib = new Library();
            //    lib.Libraryname = "Salt Lake County" + i;
            //    lib.Librarylocation = "State" + i;

            //    db.Library.Add(lib);
            //    db.SaveChanges();
            //    i++;

            //}
            //Console.WriteLine("end date" + System.DateTime.Now);

           
            var list = new List<int>();
            for (int i = 1; i <= 200000; i++)
            {
                list.Add(i);
            }
            Console.WriteLine("Start time" + System.DateTime.Now);
            Console.WriteLine("fun begins here");

            Parallel.ForEach(list, (x) =>
             {
                 librarydbContext db = new librarydbContext();
                 var lib = new Library();

                 lib.Libraryname = "Salt Lake County" + x;
                 lib.Librarylocation = x.ToString();
              
                 db.Library.Add(lib);
                 db.SaveChanges();
                 db.Dispose();

             });
            Console.WriteLine("End time" + System.DateTime.Now);
           
        }
        public static void InsertBooks_Library()
        {
            //parallel linq 
            //parlllel foreach let see
            //new records;;   //create book objects;  //set of existing records //later figure it out for 
            //dbcontext;
            

            librarydbContext db1 = new librarydbContext();
            var libraries = db1.Library.ToList();

            Console.WriteLine("start time" + DateTime.Now);
            var books = new List<Books>();
            Parallel.ForEach(libraries, x =>
            {
                librarydbContext db = new librarydbContext();
                var book = new Books()
                {
                    Bookname = "A" + x.Libraryid,
                    Libraryid = x.Libraryid
                };
                db.Books.Add(book);
                db.SaveChanges();
                db.Dispose();
            });

            Console.WriteLine("End time" + DateTime.Now);
          

        }
        public static void InsertPerson_Books()
        {
            librarydbContext db1 = new librarydbContext();
            var books = db1.Books.ToList();

            Console.WriteLine("start time" + DateTime.Now);
        
            Parallel.ForEach(books, x =>
            {
                librarydbContext db = new librarydbContext();
                var person = new Person()
                {
                    PersonName = "A" + x.Bookid,
                    Bookid = x.Bookid
                };
                db.Person.Add(person);
                db.SaveChanges();
                db.Dispose();
            });

            Console.WriteLine("End time" + DateTime.Now);


        }

       public static int ReturnLibraryobject()
        {

            //select if exists;
            //r else insert object;
            return 0;
        }
        public static int ReturnBooksobject()
        {
            //select if exists;
            //r else insert object;
            return 0;
        }
        
        public static void InsertPerson()
        {
            //for every loop inesert one call;
        }

        public static void InsertPerson_Details()
        {
           
            Console.WriteLine("start date" + System.DateTime.Now);

            var list = new List<int>();
            for (int i = 1; i <= 200000; i++)
            {
                list.Add(i);
            }
            Console.WriteLine("Start time" + System.DateTime.Now);
            

            Parallel.ForEach(list, (x) =>
            {
                librarydbContext db = new librarydbContext();
                var lib = new PersonDetails();
                lib.PersonName = "M" + x;
                lib.BookName = "B" + x;
                lib.LibraryName = "L" + x;


                db.PersonDetails.Add(lib);
                db.SaveChanges();

                db.Dispose();

            });
            Console.WriteLine("End time" + System.DateTime.Now);          
        }

        static void Main(string[] args)
        {
            //call web service right now;

            //InsertLibrary();
            //InsertBooks_Library();
            //InsertPerson_Books();
            // InsertPerson_Details();

            Parallelism parallelism = new Parallelism();
            Console.WriteLine("start time" + DateTime.Now);
            parallelism.InsertData();
            Console.ReadKey();
        }
    }
}
