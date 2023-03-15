using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Models
{
    public interface IPurchaseRepository
    {
        public IQueryable<Purchase> Purchases { get; }
        public void SavePurchase(Purchase purchase);
    }
}
