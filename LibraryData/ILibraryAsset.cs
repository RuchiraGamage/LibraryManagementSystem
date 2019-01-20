using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface ILibraryAsset
    {    //this is having series of methods requred for servises servises in libreryServises class can impliment this
        IEnumerable<LibraryAsset> GetAll();
        LibraryAsset GetById(int id);
        void Add(LibraryAsset newAsset);
        string getAuthorOrDirector(int id);
        string getDeweyIndex(int id);
        string getType(int id);
        string getTitle(int id);
        string getISBN(int id);

        LibraryBranch getCurrentLocation(int id);
    }
    
}
