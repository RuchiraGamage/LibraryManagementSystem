using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface ICheckout
    {
        IEnumerable<Checkouts> Getall();
        Checkouts getById(int checkoutId);
        void add(Checkouts newCheckout);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assetId,int libraryCardId);
        IEnumerable<CheckoutHistory> GetCheckOutHistory(int id);

        void PlaceHold(int assetId,int LibraryCardId);
        String GetCurrentHoldPatronName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);

        void MarkLost(int id);
        void MarkFound(int id);

    }
}
