using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using The_treasure_of_books.DAL;
using The_treasure_of_books.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;

namespace The_treasure_of_books.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult showLibrery()
        {
            List<Library> library = Data.Get.Librarys.ToList();
            return View(library);
        }




        public IActionResult Create()
        {
            
            return View(new Library());
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(Library library)
        {
            //מוסיף חבר לדאדטא בייס 
            Data.Get.Librarys.Add(library);
            //שמירת נתונים בדאטה בייס
            Data.Get.SaveChanges();
            //מחזיר אותנו לדף חברים
            return RedirectToAction("showLibrery");
        }



        public IActionResult AddShelve(int? id)
        {
            ViewBag.Id = id;
            //Library? library = Data.Get.Librarys.FirstOrDefault(x => x.Id == id);
            //int liberid = library.Id;
            return View (new Shelves());
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult CreateShelve(Shelves shelve)
        {
             Library? shelv = Data.Get.Librarys.FirstOrDefault(x => x.Id == shelve.lid);
            if (shelv == null)
            {
                return NotFound();
            }
             shelve.Libraryid = shelv;
             Data.Get.shelvess.Add(shelve);

             Data.Get.SaveChanges();
             return RedirectToAction("showShelves");
        }


        public IActionResult showShelves()
        {
            List<Shelves> shelve = Data.Get.shelvess.Include(shelv => shelv.Libraryid).ToList();
            return View(shelve);
        }


        public IActionResult CreateBook(int id)
        {
            ViewBag.id = id;
            return View(new Books());
        }

        //public Shelves GetSelv()
        //{
        //    return selv;
        //}
        [HttpPost,ValidateAntiForgeryToken]
        
        public IActionResult AddBook(Books book) 
        {
            Shelves? shelvefromDB = Data.Get.shelvess.Include(s => s.Libraryid).FirstOrDefault(selv => selv.Id == book.shid);
            if(shelvefromDB == null)
            {
                return NotFound();
            }
            book.Shelveid = shelvefromDB;

            if (shelvefromDB.Libraryid.genre != book.GenreBook)
            {
                TempData["name"] = "ז'אנר לא מתאים לספריה ";
                return RedirectToAction("CreateBook");
            }
            
           
            if(book.BookHeight > shelvefromDB.Height)
            {

                TempData["name"] = "הספר גבוה מדי ולכן לא נכנס למערכת אנא בחר מדף שיתאים לגודלו";
                return RedirectToAction("CreateBook");
            }

            if(book.BookHeight <= shelvefromDB.Height)
            {
                var difference = shelvefromDB.Height - book.BookHeight;
                if(difference >= 10)
                {
                    TempData["name"] = "הספר נכנס למערכת רק תדע שהוא נמוך מאוד";
                }
            }

            Data.Get.Bookss.Add(book);
            Data.Get.SaveChanges();
            return RedirectToAction("CreateBook");


        }


        public IActionResult showBooks()
        {
            List<Books> books = Data.Get.Bookss.Include(f => f.Shelveid).ToList();
            return View(books);




        }
    }
}
