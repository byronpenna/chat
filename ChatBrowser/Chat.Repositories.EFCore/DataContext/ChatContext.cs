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
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(
            ModelBuilder modelBuilder
            )
        {
            /*
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<ChatRoom>().ToTable("ChatRoom");*/
            // user
            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();

            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.UserName).IsUnique();
                });
            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.UserName).IsUnique();
                });
            // messages

            modelBuilder.Entity<Message>()
                .HasOne<User>()
                .WithMany().HasForeignKey(m => m.UserId);
            modelBuilder.Entity<Message>()
                .HasOne<ChatRoom>()
                .WithMany().HasForeignKey(m => m.RoomId);

            // chatroom
            modelBuilder.Entity<ChatRoom>().Property(c => c.Name).IsRequired();
            
            // seed
            modelBuilder.Entity<ChatRoom>().HasData(
                new ChatRoom { Id = 1, Name="Default"},
                new ChatRoom { Id = 2, Name = "Second Chat room" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "byronpenna", Email="byronpenna@gmail.com",Password= "cadaefedfef59f3b2eadd7147d4b6891" },
                new User { Id = 2, UserName = "diana_alfaro", Email = "diana@gmail.com", Password = "cadaefedfef59f3b2eadd7147d4b6891" }
                );
        }
    }
}
