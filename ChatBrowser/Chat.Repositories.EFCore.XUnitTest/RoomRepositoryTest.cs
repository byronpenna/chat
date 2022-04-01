using Chat.Repositories.EFCore.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Chat.Entities.POCOEntities;
using System.Threading.Tasks;
using Chat.Repositories.EFCore.Repositories;
using Chat.Entities.Interfaces;
using System.Collections.Generic;

namespace Chat.Repositories.EFCore.XUnitTest
{
    public class RoomRepositoryTest
    {
        [Fact]
        public void SaveChanges()
        {
            var builder = new DbContextOptionsBuilder<ChatContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                ;

            using (var context = new ChatContext(builder.Options))
            {
                context.ChatRooms.Add(new ChatRoom { Name = "Testing", CreatedDate = DateTime.Now });
                context.SaveChanges();
                var x = context.ChatRooms.CountAsync(c => c.Name == "Testing").Result;

                Assert.Equal(1, x);
            }

        }
        [Fact]
        public void get()
        {
            /*
            var builder = new DbContextOptionsBuilder<ChatContext>()
                .EnableSensitiveDataLogging()
                ;
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=ChatDB");
            */
            var OptionBuilder = new DbContextOptionsBuilder<ChatContext>();
            OptionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=ChatDB");
            

            using (var context = new ChatContext(OptionBuilder.Options))
            { 
                IRoomRepository rp = new RoomRepository(context);
                List<ChatRoom> rooms = rp.get();

                Assert.True(rooms.Count > 1); // at least 1 room
            }
        }
    }
}