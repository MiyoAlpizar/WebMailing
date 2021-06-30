using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMailing.Models.Entities;

namespace WebMailing.Models
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }

        [Display(Name = "Last Name")]
        public string LastNameFilter { get; set; }

        [Display(Name = "Ascending")]
        public bool Ascending { get; set; } = true;
    }
}
