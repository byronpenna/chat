using Chat.Entities.POCOEntities;
using Chat.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        User Login(User user);
        IEnumerable<User> GetUsersBySpecification(Specification<User> specification);
    }
}
