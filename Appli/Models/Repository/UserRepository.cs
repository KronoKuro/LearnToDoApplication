using Appli.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Appli.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext db;
        public UserRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            User item = db.Users.FirstOrDefault(g => g.Id == id);
            if (item != null)
            {
                db.Users.Remove(item);
                db.SaveChanges();
            }
        }

        public User Get(string id)
        {
            return db.Users.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User item)
        {
            var local = db.Set<User>().FirstOrDefault(entry => entry.Id.Equals(item.Id));
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
