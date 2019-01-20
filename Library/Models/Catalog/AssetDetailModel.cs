using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Catalog
{
    public class AssetDetailModel
    {
        public int AassetId { get; set; }
        public String Tittle { get; set; }
        public String AuthorOrDirector { get; set; }
        public String Type { get; set; }
        public int Year { get; set; }
        public String ISBN { get; set; }
        public String DeweyCallNumber { get; set; }
        public String Status { get; set; }
        public decimal Cost { get; set; }
        public String CurrentLocation { get; set; }
        public String ImageUrl { get; set; }
        public String PatronName { get; set; }
        public Checkouts LatestCheckout { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }
        public IEnumerable<AssetHoldModel> CurrentHolds{ get; set; }

    }

    public class AssetHoldModel
    {
        public String PatronName { get; set; }
        public String HoldPlaced { get; set; }
    }
}
