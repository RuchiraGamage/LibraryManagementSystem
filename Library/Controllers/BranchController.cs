using System.Linq;
using Library.Models.Branch;
using LibraryData;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BranchController : Controller
    {
        private ILibraryBranch _branch;

        public BranchController(ILibraryBranch branch)
        {
            _branch = branch;
        }
        public IActionResult Index()
        {
            var branches = _branch.GetAll().Select(branch => new BranchDeatailModel
            {
                Id = branch.ID,
                Address =branch.Address,
                Description =branch.Description,
                ImageUrl =branch.ImageUrl,
                Name =branch.Name,
                NOOfAssets =_branch.GetAssets(branch.ID).Count(),
                NOOfPatrons =_branch.Getpatrons(branch.ID).Count(),
                IsOpen =_branch.IsBranchOpen(branch.ID),
                Telephone =branch.Telephone
            });

            var model = new BranchIndexModel
            {
                Branches = branches
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var branch = _branch.Get(id);

            var model = new BranchDeatailModel
            {
                Id=branch.ID,
                Name=branch.Name,
                Address=branch.Address,
                Telephone=branch.Telephone,
                OpenDate=branch.OpenDate.ToString("yyyy-MM-dd"),
                NOOfAssets=_branch.GetAssets(branch.ID).Count(),
                NOOfPatrons =_branch.Getpatrons(id).Count(),
                TotalAssetvalue=_branch.GetAssets(id).Sum(a=>a.Cost),
                ImageUrl=branch.ImageUrl,
                HoursOpen=_branch.getBranchHours(id)
            };

            return View(model);
        }
    }
}