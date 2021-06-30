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
            return await Task.Run(() => context.Users.Where(filter));
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
