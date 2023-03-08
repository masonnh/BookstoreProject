using BookstoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Components
{
    public class GenresViewComponent : ViewComponent
    {
        private IBookstoreProjectRepository repo { get; set; }
        public GenresViewComponent(IBookstoreProjectRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["bookGenre"];
            
            var genres = repo.Books.Select(x => x.Category).Distinct().OrderBy(x => x);
            
            return View(genres);
        }
    }
}
