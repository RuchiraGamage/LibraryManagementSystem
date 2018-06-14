using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class Patron
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String TelephoneNumber { get; set; }

        //foregn key like librycard use to refer to another table entity framework map our patron object to a libry card object 
        //using some foreign key property like ID of libry card object use to match Librarycard object
        //verual key word use for lazy load means initialize object when it is needed
        // application demands class loads its compose object
        public virtual LibraryCard libraryCard { get; set; }
        public virtual LibraryBranch HomeLibraryBranch { get; set; }

    }
}
