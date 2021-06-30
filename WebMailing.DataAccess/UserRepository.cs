using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMailing.DataAccess.Interfaces;
using WebMailing.Models.Entities;

namespace WebMailing.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationContext context;

        public UserRepository(IApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetUsersOrder(string lastName = "", bool ascending = true)
        {
            IEnumerable<User> users;
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                users = await GetList(x => x.LastName.ToLower() == lastName.ToLower());
            }
            else
            {
                users = await GetList();
            }
            if (ascending)
            {
                users = users.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            }
            else
            {
                users = users.OrderByDescending(x => x.LastName).ThenByDescending(x => x.FirstName);
            }
            return users;
        }

        public async Task<User> Add(User entity)
        {
            entity.Id = GetNextId();
            await Task.Run(() => context.Users.Add(entity));
            return entity;
        }

        public async Task<User> Get(int id)
        {
            return await Task.Run(() => context.Users.Find(x => x.Id == id));
        }

        public async Task<IEnumerable<User>> GetList(Func<User, bool> filter = null)
        {
            IEnumerable<User> users;
            if (filter != null)
            {
                users = context.Users.Where(filter);
            }else
            {
                users = context.Users;
            }
            return await Task.Run(() => users);
        }
        public async Task<bool> Remove(int id)
        {
            var user = await Get(id);
            return await Remove(user);
        }

        public async Task<bool> Remove(User entity)
        {
            await Task.Run(() => context.Users.Remove(entity));
            return entity != null;
        }

        private int GetNextId()
        {
            if (context.Users.Count == 0)
                return 1;

            return context.Users.Max(u => u.Id) + 1;
        }
    }
}
