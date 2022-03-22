using Chat.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities.Interfaces
{
    public interface IMessageRepository
    {
        void Create(Message message);
        List<Message> GetByChatRoom(int roomID);
    }
}
