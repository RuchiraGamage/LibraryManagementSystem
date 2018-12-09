
using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryServices
{
    public class CheckoutService : ICheckout
    {
        private LibraryContext _context;

        public CheckoutService(LibraryContext context)
        {
            _context = context;
        }

        public void add(Checkouts newCheckout)
        {
            _context.Add(newCheckout);
            _context.SaveChanges();
        }

        public IEnumerable<Checkouts> Getall()
        {
            return _context.Checkouts;
        }

        public Checkouts getById(int checkoutId)
        {
            return Getall().FirstOrDefault(checkout => checkout.ID == checkoutId);
        }

        public IEnumerable<CheckoutHistory> GetCheckOutHistory(int id)
        {
            return _context.CheckoutHistories
                .Include(h=>h.LibraryAsset)
                .Include(h=>h.LibraryCard)
                .Where(h => h.LibraryAsset.ID == id);
        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds
                .Include(h=>h.LibraryAsset)//these are navigation property through 'Holds' object to the details of 'LibraryAssest object'
               // .Include(h=>h.LibraryCard)//these are navigation property through 'Holds' object to the details of 'Library card'
                .Where(h => h.Id == id);
        }

        public void MarkFound(int id)
        {
            var item = _context.LibraryAssets
                .FirstOrDefault(a => a.ID == id);
            _context.Update(item);
            item.Status = _context.Status
                .FirstOrDefault(a => a.Name == "Available");
            //remove any existing checkouts on the item
            var checkout = _context.Checkouts.FirstOrDefault(a => a.LibraryAsset.ID == id);
            if (checkout != null)
            {
                _context.Remove(checkout);
            }
            //close any existing checkout history

        }

        public void MarkLost(int id)
        {
            var item = _context.LibraryAssets
                .FirstOrDefault(a => a.ID == id);

            _context.Update(item);

            item.Status = _context.Status.FirstOrDefault(status => status.Name == "Lost");

            _context.SaveChanges();

        }

        public void PlaceHold(int assetId, int LibraryCardId)
        {
            throw new NotImplementedException();
        }

        public void CheckInItem(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }

        public void CheckOutItem(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }


        public string GetCurrentHoldPatronName(int id)
        {

        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            throw new NotImplementedException();
        }

        public Checkouts GetLatestCheckouts(int assetId)
        {
            return _context.Checkouts
                 .Where(h=>h.ID==assetId)
                 .OrderByDescending(h => h.Since)
                 .FirstOrDefault();
        }
    }
}
