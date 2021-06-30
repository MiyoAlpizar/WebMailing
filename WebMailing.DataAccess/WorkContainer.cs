using System;
using System.Collections.Generic;
using System.Text;
using WebMailing.DataAccess.Interfaces;

namespace WebMailing.DataAccess
{
    /// <summary>
    /// Class where controllers layer can access to the all the database entities to read, add, delete, etc.
    /// </summary>
    public class WorkContainer : IWorkContainer
    {
        public IUserRepository Users { get; private set; }
        public WorkContainer(IApplicationContext context)
        {
            Users = new UserRepository(context);
        }
    }
}
