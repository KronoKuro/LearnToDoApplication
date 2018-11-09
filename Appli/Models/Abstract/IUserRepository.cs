using System.Collections.Generic;

namespace Appli.Models.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(string id);
        void Create(User item);
        void Update(User item);
        void Delete(string id);
    }
}
