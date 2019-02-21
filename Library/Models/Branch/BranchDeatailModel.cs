using System;
using System.Collections.Generic;

namespace Library.Models.Branch
{
    public class BranchDeatailModel
    {
        public int Id { get; set; }
        public String Address { get; set; }
        public String OpenDate { get; set; }
        public String Name { get; set; }
        public String Telephone { get; set; }
        public bool IsOpen { get; set; }
        public String Description { get; set; }
        public int NOOfPatrons { get; set; }
        public int NOOfAssets { get; set; }
        public decimal TotalAssetvalue { get; set; }
        public String ImageUrl { get; set; }
        public IEnumerable<String> HoursOpen { get; set; }
    }
}
