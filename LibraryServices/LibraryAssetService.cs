using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        //this is a service layer which provide the interaction with the database do basic crud operations
        //impliment all the method inherit from interface

        private LibraryContext _context;
        //now we have acces to all the methods in DBContext through context object,
        //can use read,update ,delete..methods to do changes in the DB

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

        public LibraryAsset GetById(int id)
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
            return GetById(id).Location;
           // return _context.LibraryAssets.FirstOrDefault(asset => asset.ID == id).Location;
        }

        public string getDeweyIndex(int id)
        {
            if (_context.Books.Any(book => book.ID == id))
            {
              //  var isbook = _context.LibraryAssets.OfType<Book>().Where(a => a.ID == id).Any();
                return _context.Books.FirstOrDefault(book => book.ID == id).DeweyIndex;
                
            }
            else return "";

        }

        public string getISBN(int id)
        {
            if (_context.Books.Any(book => book.ID == id))
            {
                return _context.Books.FirstOrDefault(book => book.ID == id).ISBN;
            }
            else return "";
            
        }

        public string getTitle(int id)
        {
            return _context.LibraryAssets.FirstOrDefault(a => a.ID == id).Title;
        }

        public string getType(int id)
        {
            var book = _context.LibraryAssets.OfType<Book>().Where(b => b.ID == id);

            return book.Any() ? "Book" : "Video";
        }

        public string getAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>().Where(asset => asset.ID == id).Any();
            var isVideo = _context.LibraryAssets.OfType<Video>().Where(asset => asset.ID == id).Any();

            return isBook ? _context.Books.FirstOrDefault(asset=>asset.ID==id).Author:
                _context.Videos.FirstOrDefault(asset=>asset.ID==id).Director
                ?? "unknown";
            //return b, from a??b when a is not satisfied             
        }
    }
}
