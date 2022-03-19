using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Repositories.EFCore.DataContext
{
    public class ChatFactory : IDesignTimeDbContextFactory<ChatContext>
    {
        ChatContext IDesignTimeDbContextFactory<ChatContext>.CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<ChatContext>();
            OptionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=ChatDB");
            return new ChatContext(OptionBuilder.Options);
        }
    }
}
