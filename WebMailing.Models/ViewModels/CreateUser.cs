﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebMailing.Models.ViewModels
{
    /// <summary>
    /// Class used to create a new user registration
    /// </summary>
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
}
