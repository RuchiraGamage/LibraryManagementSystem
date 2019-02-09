using LibraryData.Models;
using System.Collections.Generic;
namespace LibraryData
{
   public interface IPatron
    {
        Patron Get(int patronId);
        IEnumerable<Patron> GetAll();
        void Add(Patron newPatron);

        IEnumerable<CheckoutHistory> GetCheckOutHistory(int PatronId);
        IEnumerable<Hold> GetHolds(int PatronId);
        IEnumerable<Checkouts> GetCheckOuts(int PatronId);
    }
}
