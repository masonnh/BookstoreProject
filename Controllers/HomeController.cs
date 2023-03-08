using BookstoreProject.Models;
using BookstoreProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreProjectRepository repo;
        public HomeController (IBookstoreProjectRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string bookGenre, int pageNum = 1)
        {
            int pageSize = 10;

            var vm = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Where(b => b.Category == bookGenre || bookGenre == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalBookCount = (bookGenre == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == bookGenre).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(vm);
        }
    }
}
