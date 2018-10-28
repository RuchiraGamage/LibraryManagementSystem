using Library.Models.Catalog;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CatalogController :Controller
    {
        //handle all the data back from database and push them to a perticuler view model to display them
        //MVC model is defer from the models define in data layer
        //Models in datalayer are called entity models and map derectly to object in database tables 
        //Models in MVC layers are more like view models they just represent data that we show to the user inside of a view 


        //private LibraryContext _asset;
        private ILibraryAsset _asset;
        public CatalogController(ILibraryAsset asset)
        {
            _asset = asset;
        }
        //first controllerl action

        public IActionResult Index()
        {

            var assetModels = _asset.GetAll();
            var listingResult = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.ID,
                    ImageUrl = result.ImageUrl,
                    AuthorOrDirector = _asset.getAuthorOrDirector(result.ID),
                    DeweyCallNumber = _asset.getDeweyIndex(result.ID),
                    Title = result.Title,
                    Type = _asset.getType(result.ID),
                });

            var model = new AssetIndexModel() {

                Asset = listingResult
        };
            return View(model);
        }


        /*

    public IEnumerable<LibraryCard> index() {

        var assetModels = _asset.GetAll();

        var listingResult = assetModels
            .Select(result => new AssetIndexListingModel {
                Id = result.ID,
                ImageUrl = result.ImageUrl,
                AuthorOrDirector = _asset.getAuthorOrDirector(result.ID),
                DeweyCallNumber = _asset.getDeweyIndex(result.ID),
                Title = result.Title,
                Type = _asset.getType(result.ID)


            });
        var model = new AssetIndexModel()
        {
            Asset = listingResult
        };


        return View(model);


       // return _asset.LibraryCards;
    }
*/

    }
}
