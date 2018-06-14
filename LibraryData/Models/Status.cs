using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class Status
    {
        public int ID { get; set; }

        [Required]
        public int Name { get; set; }

        [Required]
        public string Discription { get; set; }
    }
}
