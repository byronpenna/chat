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
    public class MessageRepository:IMessageRepository
    {

        readonly ChatContext Context;
        public MessageRepository(ChatContext context)
        {
            Context = context;
        }
        void IMessageRepository.Create(Message message)
        {
            Context.Add(message);
        }

        List<Message> IMessageRepository.GetByChatRoom(int roomID)
        {

            List<Message> messages = null;
            try
            {

                messages = (
                    from m in Context.Messages
                    join user in Context.Users on m.UserId equals user.Id
                    where m.RoomId == roomID
                    orderby m.MessageId descending
                    select new Message { 
                        MessageId = m.MessageId,
                        content = m.content,
                        RoomId = m.RoomId,
                        UserId = m.UserId,
                        room = new ChatRoom
                        {
                            Id = m.RoomId
                        },
                        user = new User { 
                            Id = user.Id,
                            UserName = user.UserName,
                            Email = user.Email,
                            Password = ""
                        }
                    }
                    ).ToList();
                    

            }
            catch(Exception ex)
            {
                string y = "";
            }
            return messages;
        }
    }
}
