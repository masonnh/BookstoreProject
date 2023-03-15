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
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public PurchaseModel(IBookstoreProjectRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book book = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart.AddItem(book, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookid, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookid).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
