using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebMailing.Models.ViewModels
{
    public class CreateUser
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid E-mail")]
        public string Email { get; set; }
    }

    public class UserViewModel: CreateUser
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get 
            {
                return $"{FirstName} {LastName}";
            }
        }

    }
}
