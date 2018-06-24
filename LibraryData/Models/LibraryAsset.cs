using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public abstract class LibraryAsset
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }//just store int as BC

        [Required]
        public Status Status { get; set; }
        //status has given the navigation property to LibraryAsset
        [Required]
        public decimal Cost { get; set; }

        public string ImageUrl { get; set; }

        public int NumberOfCopies { get; set; }

        public virtual LibraryBranch Location { get; set; }




    }
}

