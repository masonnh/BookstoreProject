using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalBookCount { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        // Calculate the number of pages we'll need
        public int TotalPageCount => (int) Math.Ceiling((double) TotalBookCount / BooksPerPage);
    }
}
