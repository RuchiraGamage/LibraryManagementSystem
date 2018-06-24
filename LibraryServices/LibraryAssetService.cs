using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        //this is a service layer which provide the interaction with the database do basic crud operations
        //impliment all the method inherit from interface

        private LibraryContext _context;
        //now we have acces to all the methods in DBContext through context object,can use read,update ,delete..methods to do changes in the DB

        public LibraryAssetService(LibraryContext context) {
            _context = context;
        }

        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                .Include(asset=>asset.Status)
                .Include(asset=>asset.Location);
        }

        public LibraryAsset GetBuId(int id)
        {
            // return _context.LibraryAssets
            //      .Include(asset => asset.Status)
            //      .Include(asset => asset.Location)
            //      .FirstOrDefault(asset => asset.ID == id);

            //we can also write above code refering GetAll()

            return GetAll().FirstOrDefault(asset => asset.ID == id);

        }
        public LibraryBranch getCurrentLocation(int id)
        {
            return GetBuId(id).Location;
           // return _context.LibraryAssets.FirstOrDefault(asset => asset.ID == id).Location;
        }

        public string getDeweyIndex(int id)
        {
            throw new NotImplementedException();
        }

        public string getISBN(int id)
        {
            throw new NotImplementedException();
        }

        public string getTitle(int id)
        {
            throw new NotImplementedException();
        }

        public string getType(int id)
        {
            throw new NotImplementedException();
        }

        public string getAuthorOrDirector(int id)
        {
            throw new NotImplementedException();
        }
    }
}
