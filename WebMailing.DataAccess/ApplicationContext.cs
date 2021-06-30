using System;
using System.Collections.Generic;
using System.Text;
using WebMailing.DataAccess.Interfaces;
using WebMailing.Models.Entities;

namespace WebMailing.DataAccess
{
    public class ApplicationContext : IApplicationContext
    {
        public List<User> Users { get; private set; }
        public ApplicationContext()
        {
            Users = new List<User>();
        }
    }
}
