using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class Patron
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Limit first name to 30 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Limit last name to 30 characters.")]
        public string LastName { get; set; }

        [Required] public string Address { get; set; }

        [Required] public DateTime DateOfBirth { get; set; }

        public string Telephone { get; set; }
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Library Card")]
        public LibraryCard LibraryCard { get; set; }
        public LibraryBranch HomeLibraryBranch { get; set; }

        //foregn key like librycard use to refer to another table entity framework map our patron object to a libry card object 
        //using some foreign key property like ID of libry card object use to match Librarycard object
        //verual key word use for lazy load means initialize object when it is needed
        // application demands class loads its compose object
    }

}
