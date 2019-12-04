using System;
using System.Collections.Generic;
using System.Text;
using DatabaseMultiThreadedApplication.database;
using System.Threading.Tasks;
using System.Linq;


namespace DatabaseMultiThreadedApplication
{
   public class Parallelism
    {

        public Parallelism()
        {

        }

        public void InsertData()
        {
            var db=new librarydbContext();

            var personDetails = db.PersonDetails.Take(20000).ToList();

            Parallel.ForEach(personDetails, (x) =>
            {

             var libraryReturnValue=  InsertLibrary(x.LibraryName);
                 if(libraryReturnValue!=null)
                {
                   var insertBooks= InsertBooks(x.BookName, x.LibraryName);

                    if(insertBooks!=null)
                    {
                        var insertPerson = InsertPerson(x.PersonName, x.LibraryName);
                    }
                }
                   
                  
                InsertPerson(x.PersonName, x.BookName);

            });

            Console.WriteLine("End time" + DateTime.Now);
            Console.ReadKey();
        }
        public Library InsertLibrary(string libraryName)
        {
            var db = new librarydbContext();
            try
            {

                var libraries = db.Library.Where(x => x.Libraryname == libraryName).FirstOrDefault();
                if(libraries!=null)
                {
                    return libraries;
                }
                else
                {
                    var library = new Library()
                    {
                        Librarylocation = libraryName + "insert",
                        Libraryname=libraryName
                    };

                    db.Library.Add(library);
                    db.SaveChanges();
                    db.Dispose();

                    return library;
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
                
            }
        }
        public Books InsertBooks(string bookName, string libraryName)
        {
            var db = new librarydbContext();
            try
            {
                var libraryId = db.Library.Where(x => x.Libraryname == libraryName).FirstOrDefault();

                if(libraryId.Libraryid>0)
                {
                    var book = new Books()
                    {
                        Bookname=bookName,
                        Libraryid=libraryId.Libraryid
                    };

                    db.Books.Add(book);
                    db.SaveChanges();
                    db.Dispose();

                    return book;
                }
                return null;


            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public Person InsertPerson(string person, string bookName)
        {
            var db = new librarydbContext();
            try
            {

                var book = db.Books.Where(x => x.Bookname == bookName).FirstOrDefault();

                if(book.Bookid>0)
                {

                    var per = new Person()
                    {
                        PersonName=person,
                        Bookid=book.Bookid
                    };
                    db.Person.Add(per);
                    db.SaveChanges();
                    db.Dispose();

                    return per;
                }
                else
                {
                    return null;
                }

            }catch(Exception e)
            {
                return null;
            }  
        }
    }
}
