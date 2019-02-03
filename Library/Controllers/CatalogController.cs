using Library.Models.Catalog;
using Library.Models.Checkout;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CatalogController : Controller
    {
        /*
         handle all the data back from database and push them to a perticuler view model to display them
        MVC model is defer from the models define in data layer
        Models in datalayer are called entity models and map derectly to object in database tables 
        Models in MVC layers are more like view models they just represent data that we show to
        the user inside of a view 
        */

        private ILibraryAsset _asset;
        private ICheckout _checkout;
        public CatalogController(ILibraryAsset asset, ICheckout checkout)
        {
            _asset = asset;
            _checkout = checkout;
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

            var model = new AssetIndexModel()
            {

                Asset = listingResult
            };
            return View(model);
        }


        public IActionResult Detail(int id)
        {
            var asset = _asset.GetById(id);

            var currentholds = _checkout
                .GetCurrentHolds(id)
                .Select(h => new AssetHoldModel
                {
                    HoldPlaced =_checkout.GetCurrentHoldPlaced(h.Id).ToString("d"),
                    PatronName=_checkout.GetCurrentHoldPatronName(h.Id)
                });

            var model = new AssetDetailModel
            {
                AassetId = id,
                Tittle = asset.Title,
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _asset.getAuthorOrDirector(id),
                CurrentLocation = _asset.getCurrentLocation(id).Name,
                DeweyCallNumber = _asset.getDeweyIndex(id),
                ISBN = _asset.getISBN(id),
                Type=_asset.getType(id),
                CheckoutHistory=_checkout.GetCheckOutHistory(id),
                LatestCheckout=_checkout.GetLatestCheckouts(id),
                PatronName=_checkout.GetCurrentHoldPatronName(id),
                CurrentHolds= currentholds
            };
            return View(model);
        }


        public IActionResult Checkout(int id)
        {
            var asset = _asset.GetById(id);
            var model = new CheckoutModel
            {
                AssetId=id,
                ImageUrl=asset.ImageUrl,
                isCheckedOut=_checkout.IsCheckedOut(id),
                LibraryCardId="",
                Title=asset.Title
            };

            return View(model);
        }

        public IActionResult CheckIn(int id)
        {
            _checkout.CheckInItem(id);
            return RedirectToAction("Detail", new { id = id });
        }

        public IActionResult Hold(int id)
        {
            var asset = _asset.GetById(id);
            var model = new CheckoutModel
            {
                AssetId = id,
                ImageUrl = asset.ImageUrl,
                isCheckedOut = _checkout.IsCheckedOut(id),
                LibraryCardId = "",
                Title = asset.Title,
                HoldCount = _checkout.GetCurrentHolds(id).Count()
            };

            return View(model);
        }

        public IActionResult MarkLost(int assetId)
        {
            _checkout.MarkLost(assetId);
            return RedirectToAction("Detail", new { id = assetId });
        }

        public IActionResult MarkFound(int assetId)
        {
            _checkout.MarkFound(assetId);
            return RedirectToAction("Detail", new { id = assetId });
        }

        [HttpPost]
        public IActionResult PlacedCheckOut(int assetId,int LibraryCardId)
        {
            _checkout.CheckOutItem(assetId, LibraryCardId);

            return RedirectToAction("Detail", new { id = assetId });
        }

        [HttpPost]
        public IActionResult PlaceHold(int assetId, int LibraryCardId)
        {
            _checkout.PlaceHold(assetId, LibraryCardId);

            return RedirectToAction("Detail", new { id = assetId });
        }
    }
}
