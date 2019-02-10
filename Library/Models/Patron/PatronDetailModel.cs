using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Patron
{
    public class PatronDetailModel
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public String FullName { get { return FirstName + " " + LastName; } }

        public int LibraryCardId { get; set; }
        public String Address { get; set; }
        public DateTime MemberSince { get; set; }
        public String Telephone { get; set; }
        public String HomeLibraryBranch { get; set; }
        public decimal OverDueFees { get; set; }
        public IEnumerable<Checkouts> AssetsCheckedOut { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }
        public IEnumerable<Hold> Holds { get; set; }
    }
}
