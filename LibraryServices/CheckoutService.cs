
using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryServices
{
    public class CheckoutService : ICheckout
    {
        public void add(Checkouts newCheckout)
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

        public IEnumerable<Checkouts> Getall()
        {
            throw new NotImplementedException();
        }

        public Checkouts getById(int checkoutId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CheckoutHistory> GetCheckOutHistory(int id)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentHoldPatronName(int id)
        {
            throw new NotImplementedException();
        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            throw new NotImplementedException();
        }

        public void MarkFound(int id)
        {
            throw new NotImplementedException();
        }

        public void MarkLost(int id)
        {
            throw new NotImplementedException();
        }

        public void PlaceHold(int assetId, int LibraryCardId)
        {
            throw new NotImplementedException();
        }
    }
}
