using Chat.Entities.Interfaces;
using Chat.Entities.POCOEntities;
using Chat.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Repositories.EFCore.Repositories
{
    public class RoomRepository:IRoomRepository
    {

        readonly ChatContext Context;
        public RoomRepository(ChatContext context)
        {
            Context = context;
        }

        List<ChatRoom> IRoomRepository.get()
        {
            List<ChatRoom> rooms = null;
            try
            {
                rooms = (
                    from cr in Context.ChatRooms
                    orderby cr.Id
                    select cr
                    ).ToList();
            }catch(Exception ex)
            {

            }
            return rooms;
        }
    }
}
