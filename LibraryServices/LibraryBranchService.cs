using System;
using System.Collections.Generic;
using System.Linq;
using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryServices
{
    public class LibraryBranchService :  ILibraryBranch
    {
        private LibraryContext _context;

        public LibraryBranchService(LibraryContext context)
        {
            _context = context;
        }

        public void Add(LibraryBranch newBranch)
        {
            _context.Add(newBranch);
            _context.SaveChanges();
        }

        public LibraryBranch Get(int branchId)
        {
            return GetAll()
                .FirstOrDefault(branch => branch.ID == branchId);
        }

        public IEnumerable<LibraryBranch> GetAll()
        {
            return _context.LibraryBranches
             .Include(branch => branch.Patrons)
             .Include(branch => branch.LibraryAssets);
        }

        public IEnumerable<LibraryAsset> GetAssets(int libraryId)
        {
            return _context
                .LibraryBranches
                .Include(b => b.LibraryAssets)
                .FirstOrDefault(b => b.ID == libraryId)
                .LibraryAssets;
        }

        public IEnumerable<string> getBranchHours(int branchId)
        {
            var hour = _context.BranchHours.Where(h => h.Branch.ID == branchId);
            return DataHelper.HumanizeBizHours(hour);
        }

        public IEnumerable<Patron> Getpatrons(int libraryId)
        {
            return _context
                .LibraryBranches
                .Include(b => b.Patrons)
                .FirstOrDefault(b => b.ID == libraryId)
                .Patrons;
        }
            
        public bool IsBranchOpen(int branchId)
        {
            var currentTimeHour = DateTime.Now.Hour;
            var currentDateOfWeek = (int)DateTime.Now.DayOfWeek+1;
            var hour = _context.BranchHours.Where(h => h.Branch.ID == branchId);
            var daysHours = hour.FirstOrDefault(h => h.DayOfWeek == currentDateOfWeek);

            var isOpen = currentTimeHour > daysHours.OpenTime && currentTimeHour < daysHours.CloseTime;
            return isOpen;
        }
    }
}
