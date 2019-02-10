using System.Collections.Generic;
using System.Linq;
using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryServices
{
    public class PatronService : IPatron
    {
        private LibraryContext _context;

        public PatronService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(Patron newPatron)
        {
            _context.Add(newPatron);
            _context.SaveChanges();
        }

        public Patron Get(int patronId)
        {
            return GetAll()
                .FirstOrDefault(patron => patron.Id == patronId);
        }

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons
               .Include(patron => patron.LibraryCard)
               .Include(patron => patron.HomeLibraryBranch);
        }

        public IEnumerable<CheckoutHistory> GetCheckOutHistory(int PatronId)
        {
            var CardId = Get(PatronId).LibraryCard.Id;

            return _context.CheckoutHistories
                 .Include(co => co.LibraryCard)
                 .Include(co => co.LibraryAsset)
                 .Where(co => co.LibraryCard.Id == CardId)
                 .OrderByDescending(co=>co.CheckedOut);
        }

        public IEnumerable<Checkouts> GetCheckOuts(int PatronId)
        {
            var CardId = Get(PatronId).LibraryCard.Id;

            return _context.Checkouts
                .Include(c => c.LibraryCard)
                .Include(c => c.LibraryAsset)
                .Where(c => c.LibraryCard.Id == CardId);
        }

        public IEnumerable<Hold> GetHolds(int PatronId)
        {
            var cardId = Get(PatronId).LibraryCard.Id;

            return _context.Holds
                 .Include(h => h.LibraryCard)
                 .Include(h => h.LibraryAsset)
                 .Where(h => h.LibraryCard.Id == cardId)
                 .OrderByDescending(h => h.HoldPlaced);
        }
    }
}
