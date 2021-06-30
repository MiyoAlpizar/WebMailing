using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebMailing.Models.Entities;

namespace WebMailing.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Filter the list of user by last name and returns a new list orderer by Last Name and then By First Name
        /// </summary>
        /// <param name="lastName">Last Name to filter by</param>
        /// <param name="ascending">List should be orderer Ascending or Descending</param>
        /// <returns>List of users</returns>
        public Task<IEnumerable<User>> GetUsersOrder(string lastName = "", bool ascending = true);
    }
}
