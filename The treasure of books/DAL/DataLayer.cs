using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using The_treasure_of_books.Models;

namespace The_treasure_of_books.DAL
{
    public class DataLayer : DbContext
    {
        public DataLayer(string ConnctionString) : base(GetOptions(ConnctionString))
        {
            //תוודא שיש דאטהבייס
            Database.EnsureCreated();
            //הכנסת נתונים בפעם הראשונה
            Seed();
        }

        private void Seed()
        {
            if (Librarys.Count() > 0)
            {
                return;
            }

            //יצירת מופע חדש של חבר ברשימה
            Library firstlibrery = new Library();
            //הכנסת נתונים
            firstlibrery.LiberryName = "אוצר התוכחה";
            firstlibrery.genre = "מוסר";


            //הוספה למופע 
            Librarys.Add(firstlibrery);

           

            //Shelves firstShelve = new Shelves();
            //firstShelve.Height = 6;

            //shelvess.Add(firstShelve);

            //Books firstbook = new Books();
            //firstbook.BookHeight = 6;
            //firstbook.BookName = "הלכה למעשה";
            //firstbook.GenreBook = "תורה";
            
            //Bookss.Add(firstbook);
            



            SaveChanges();
        }












        //מייצר לי טבלאות בדאטהבייס
        public DbSet<Books> Bookss { get; set; }

        public DbSet<Shelves> shelvess { get; set; }

        public DbSet<Library> Librarys { get; set; }
        //פונקציה שגם מוודאת שאני מתחבר לSQLSERVERולא לדאטאבייס אחר 
        //פונקציה שמחזירה את אפשרויות ההתחברות למסד הנתונים
        private static DbContextOptions GetOptions(string ConnctionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnctionString).Options;
        }

}   }
