using BookDatabase.Models;
using BookDatabase.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace BookDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;

        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //retreive all books
            IEnumerable<Book> BookList = _db.Books;
            return View(BookList);
        }

        //Get information from user
        public IActionResult CreatePage()
        {

            return View();
        }

        //Post info on book to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePage(Book obj)
        {

            if (ModelState.IsValid)
            {
                obj.UserId = _userManager.GetUserId(User);
                _db.Books.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Book Added";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();  
            }  
            var book = _db.Books.Find(id);

            if(book == null) { return NotFound(); }
            
            return View(book);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book obj)
        {

            if (ModelState.IsValid)
            {
                obj.UserId = _userManager.GetUserId(User);
                _db.Books.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Book Updated";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get Method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var book = _db.Books.Find(id);

            if (book == null) { return NotFound(); }

            return View(book);
        }

        //Post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? id)
        {

            var obj = _db.Books.Find(id);
            if(obj == null) { return NotFound(); }
            
            _db.Books.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Book deleted";
            return RedirectToAction("Index");
            
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}