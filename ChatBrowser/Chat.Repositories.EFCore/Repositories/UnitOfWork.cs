using Chat.Entities.Interfaces;
using Chat.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ChatContext Context;
        public UnitOfWork(ChatContext context)
        {
            Context = context;
        }
        Task<int> IUnitOfWork.SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
