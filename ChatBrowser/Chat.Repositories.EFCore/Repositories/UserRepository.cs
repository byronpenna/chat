using Chat.Entities.Interfaces;
using Chat.Entities.POCOEntities;
using Chat.Entities.Specifications;
using System;
using System.Collections.Generic;
using Chat.Repositories.EFCore.DataContext;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Repositories.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly ChatContext Context;
        public UserRepository(ChatContext context)
        {
            Context = context;
        }
        void IUserRepository.Create(User user)
        {
            Context.Add(user);
        }

        void IUserRepository.Delete(User user)
        {
            throw new NotImplementedException();
        }
        User IUserRepository.Login(User user)
        {
            var x = (from u in Context.Users
                    where u.UserName == user.UserName 
                    && u.Password == user.Password
                    orderby u.Id 
                    select u).ToList();
            return x.Count > 0 ? x[0]: null;
        }
        IEnumerable<User> IUserRepository.GetUsersBySpecification(Specification<User> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();
            return Context.Users.Where(ExpressionDelegate);

        }

        void IUserRepository.Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
