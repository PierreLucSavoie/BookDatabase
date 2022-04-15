﻿using BookDatabase.Models;
using BookDatabase.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
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
                _db.Books.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}