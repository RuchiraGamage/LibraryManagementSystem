using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryData
{
    public interface ILibraryBranch
    {
        IEnumerable<LibraryBranch> GetAll();
        IEnumerable<Patron> Getpatrons(int libraryId);
        IEnumerable<LibraryAsset> GetAssets(int libraryId);
        IEnumerable<String> getBranchHours(int branchId); 
        LibraryBranch Get(int branchId);
        void Add(LibraryBranch newBranch);
        bool IsBranchOpen(int branchId);   
    }
}
