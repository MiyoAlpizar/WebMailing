using System;
using System.Collections.Generic;
using System.Text;
using WebMailing.DataAccess.Interfaces;

namespace WebMailing.DataAccess
{
    public class WorkContainer : IWorkContainer
    {
        
        public IUserRepository Users { get; private set; }
        public WorkContainer(ApplicationContext context)
        {
            Users = new UserRepository(context);
        }
    }
}
