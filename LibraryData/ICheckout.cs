using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface ICheckout
    {
        IEnumerable<Checkouts> Getall();
        IEnumerable<CheckoutHistory> GetCheckOutHistory(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);

        void add(Checkouts newCheckout);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assetId);
        void MarkLost(int id);
        void MarkFound(int id);
        void PlaceHold(int assetId, int LibraryCardId);

        String GetCurrentCheckoutPatron(int assetId);
        String GetCurrentHoldPatronName(int holdId);
        DateTime GetCurrentHoldPlaced(int holdId);
        Checkouts GetLatestCheckouts(int assetId);
        Checkouts getById(int checkoutId);

        bool IsCheckedOut(int assetId);
    }
}
