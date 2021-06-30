using System;
using System.Collections.Generic;
using System.Text;
using WebMailing.Models.Entities;

namespace WebMailing.DataAccess.Interfaces
{
    public interface IApplicationContext
    {
        public List<User> Users { get; }
    }
}
