
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
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .Where(h => h.LibraryAsset.ID == id);
        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds
                .Include(h => h.LibraryAsset)//these are navigation property through 'Holds'       
                                             //object to the details of 'LibraryAssest object'
                                             // .Include(h=>h.LibraryCard)//these are navigation property through 'Holds'
                                             //object to the details of 'Library card'
                .Where(h => h.LibraryAsset.ID == id);
        }

        public Checkouts GetLatestCheckouts(int assetId)
        {
            return _context.Checkouts
                 .Where(h => h.LibraryAsset.ID == assetId)
                 .OrderByDescending(h => h.Since)
                 .FirstOrDefault();
        }

        public void MarkFound(int id)
        {
            var now = DateTime.Now;

            UpdateAsset(id,"Available");

            //remove any existing checkouts on the item
            RemoveExistingCheckouts(id);

            //close any existing checkout history
            CloseExistingCheckoutHistory(id,now);

            _context.SaveChanges();
        }     

        public void MarkLost(int id)
        {

            UpdateAsset(id, "Lost");
         
            _context.SaveChanges();
        }

        private void UpdateAsset(int id, string state)
        {
            var item = _context.LibraryAssets
                .FirstOrDefault(a => a.ID == id);
            _context.Update(item);
            item.Status = _context.Status
            .FirstOrDefault(a => a.Name == state);
            _context.SaveChanges();
        }

        private void CloseExistingCheckoutHistory(int id, DateTime now)
        {

            var history = _context.CheckoutHistories
             .FirstOrDefault(h => h.LibraryAsset.ID == id
             && h.CheckedIn == null);

            if (history != null)
            {
                _context.Update(history);//entity framework mark this item for update.tracking it for update;
                history.CheckedIn = now;
            }
        }

        private void RemoveExistingCheckouts(int id)
        {
            var checkout = _context.Checkouts.FirstOrDefault(a => a.LibraryAsset.ID == id);
            if (checkout != null)
            {
                _context.Remove(checkout);
            }
        }

        public void CheckInItem(int assetId)
        {
            var now =DateTime.Now;
            var item = _context
                .LibraryAssets.FirstOrDefault(h => h.ID == assetId);
            _context.Update(item);

            //remove any existing checkouts on  the item
            RemoveExistingCheckouts(assetId);

            //close any xisting checkout history
            CloseExistingCheckoutHistory(assetId, now);

            //look for the existing holds on the item

            var currentHolds = _context.Holds
                .Include(h=>h.LibraryCard)
                .Include(h=>h.LibraryAsset)
                .Where(h => h.LibraryAsset.ID == assetId);

            //if there are holds checkout the item to the library card with the earliest hold

            if(currentHolds.Any())
            {
                CheckoutsToEarliestHold(assetId,currentHolds);
            }else
            {
                UpdateAsset(assetId, "Available");
            }
            //otherwise update the item status to available
            _context.SaveChanges();

        }

        private void CheckoutsToEarliestHold(int assetId, IQueryable<Hold> currentHolds)
        {
            var earliestHold = currentHolds
                .OrderBy(h => h.HoldPlaced)//sort in to assending order
                .FirstOrDefault();

            var librarycard = earliestHold.LibraryCard;
            _context.Remove(earliestHold);
            _context.SaveChanges();

            CheckOutItem(assetId, librarycard.Id);
        }

        public void CheckOutItem(int assetId, int libraryCardId)
        {
            if (IsCheckedOut(assetId))
            {
                return;
                //add logic here to feedback to the user
            }
            var Item = _context.LibraryAssets
                .FirstOrDefault(i => i.ID == assetId);

            UpdateAsset(assetId, "Checked Out");

            var libryCard = _context.LibraryCards
                .FirstOrDefault(h => h.Id == libraryCardId);

            var now = DateTime.Now;

            var checkout = new Checkouts
            {
                LibraryAsset = Item,
                LibraryCard = libryCard,
                Since = now,
                Until = GetDefaultCheckOutTime(now)
            };

            _context.Add(checkout);

            var checkOutHistory = new CheckoutHistory
            {
                LibraryAsset =Item,
                LibraryCard =libryCard,
                CheckedOut =now,
            };

            _context.Add(checkOutHistory);

            _context.SaveChanges();
        }

        private DateTime GetDefaultCheckOutTime(DateTime now)
        {
            return now.AddDays(12);
        }

        public bool IsCheckedOut(int assetId)
        {
           return _context.Checkouts
                .Where(h => h.LibraryAsset.ID == assetId)
                .Any();        
        }

        public void PlaceHold(int assetId, int LibraryCardId)
        {
            var now = DateTime.Now;

            var asset = _context.LibraryAssets
                .Include(a=>a.Status)
                .FirstOrDefault(h => h.ID == assetId);

            var Librycard = _context.LibraryCards
                .FirstOrDefault(h => h.Id == LibraryCardId);

             if(asset.Status.Name=="Available")
            {
                UpdateAsset(assetId, "On Hold");
            }

            var hold = new Hold
            {
                LibraryAsset=asset,
                LibraryCard =Librycard,
                HoldPlaced =now
            };

            _context.Add(hold);
            _context.SaveChanges();
        }

        public string GetCurrentHoldPatronName(int holdId)
        {
            var hold = _context.Holds
                .Include(h=>h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .FirstOrDefault(h => h.Id == holdId);

            var cardId = hold?.LibraryCard.Id;//'?' check for the null

            var patron = _context.Patrons
                .Include(p => p.LibraryCard)
                .FirstOrDefault(p => p.LibraryCard.Id == cardId);

            return patron?.FirstName + " " + patron?.LastName;
           
        }

        public DateTime GetCurrentHoldPlaced(int holdId)
        {
            return _context
                .Holds
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .FirstOrDefault(h => h.Id == holdId)
                .HoldPlaced;
        }

        public string GetCurrentCheckoutPatron(int assetId)
        {
            var checkOut = GetCheckoutByAssetId(assetId);
            if (checkOut==null)
            {
                return "";
            }

            var cardId = checkOut.LibraryCard.Id;
            var patron= _context.Patrons
                .Include(h => h.LibraryCard)
                .FirstOrDefault(h => h.LibraryCard.Id == cardId);

            return patron.FirstName + " " + patron.LastName;
                
        }

        private Checkouts GetCheckoutByAssetId(int assetId)
        {
           return _context.Checkouts
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .Where(h=>h.LibraryAsset.ID==assetId)
                .FirstOrDefault();
        }
    }
}
//here has used 'linq' queries to push data to data base and pull back from database