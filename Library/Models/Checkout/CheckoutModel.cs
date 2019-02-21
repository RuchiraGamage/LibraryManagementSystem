using System;

namespace Library.Models.Checkout
{
    public class CheckoutModel
    {
        public String LibraryCardId { get; set; }
        public String Title { get; set; }
        public String ImageUrl { get; set; }
        public int AssetId { get; set; }
        public int HoldCount { get; set; }
        public bool isCheckedOut { get; set; }
    }
}
