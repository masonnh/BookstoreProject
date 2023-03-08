using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreProject.Infrastructure;
using BookstoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreProject.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreProjectRepository repo { get; set; }
        public PurchaseModel(IBookstoreProjectRepository temp)
        {
            repo = temp;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book book = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
