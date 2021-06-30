using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebMailing.Models.Entities
{
    /// <summary>
    /// Class to represent user
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
