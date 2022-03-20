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

        IEnumerable<User> IUserRepository.GetUsersBySpecification(Specification<User> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();
            return Context.Users.Where(ExpressionDelegate);

        }
    }
}
