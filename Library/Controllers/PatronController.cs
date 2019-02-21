using Library.Models.Patron;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    public class PatronController : Controller
    {
        private IPatron _patron;

        public PatronController(IPatron ipatron)
        {
            _patron = ipatron;
        }

        public IActionResult Index()
        {
            var allPatrons = _patron.GetAll();

            var patronModels = allPatrons.Select(p => new PatronDetailModel
            {
                Id =p.Id,
                FirstName =p.FirstName,
                LastName =p.LastName,
                Address =p.Address,
                AssetsCheckedOut =_patron.GetCheckOuts(p.Id),
                CheckoutHistory =_patron.GetCheckOutHistory(p.Id),
                Holds =_patron.GetHolds(p.Id),
                HomeLibraryBranch =p.HomeLibraryBranch.Name,
                LibraryCardId =p.LibraryCard.Id,
                MemberSince =p.LibraryCard.Created,
                OverDueFees=p.LibraryCard.Fees,
                Telephone=p.Telephone
            }).ToList();

            var model = new PatronIndexModel()
            {
                Patrons = patronModels
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var patron = _patron.Get(id);

            var model = new PatronDetailModel
            {
                Id = patron.Id,
                FirstName = patron.FirstName,
                LastName = patron.LastName,
                Address = patron.Address,
                AssetsCheckedOut = _patron.GetCheckOuts(patron.Id)??new List<Checkouts>(),
                CheckoutHistory = _patron.GetCheckOutHistory(patron.Id),
                Holds = _patron.GetHolds(patron.Id),
                HomeLibraryBranch = patron.HomeLibraryBranch.Name,
                LibraryCardId = patron.LibraryCard.Id,
                MemberSince = patron.LibraryCard.Created,
                OverDueFees = patron.LibraryCard.Fees,
                Telephone = patron.Telephone
            };

            return View(model);
        }
    }
}
