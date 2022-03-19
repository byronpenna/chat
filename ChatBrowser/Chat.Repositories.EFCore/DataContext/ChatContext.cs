using Microsoft.EntityFrameworkCore;
using Chat.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Repositories.EFCore.DataContext
{
    public class ChatContext:DbContext
    {
        public ChatContext(
            DbContextOptions<ChatContext> options
            ):
            base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder
            )
        {
            // user
            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            // chatroom
            modelBuilder.Entity<ChatRoom>().Property(c => c.Name).IsRequired();
            
            // seed
            modelBuilder.Entity<ChatRoom>().HasData(
                new ChatRoom { Id = 1, Name="Default"}
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "byronpenna", Email="byronpenna@gmail.com",Password="byronpenna123"},
                new User { Id = 2, UserName = "diana_alfaro", Email = "diana@gmail.com", Password = "diana123" }
                );
        }
    }
}
