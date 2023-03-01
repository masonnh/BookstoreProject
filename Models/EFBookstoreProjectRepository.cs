using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Models
{
    public class EFBookstoreProjectRepository : IBookstoreProjectRepository
    {
        private BookstoreContext context { get; set; }
        public EFBookstoreProjectRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
