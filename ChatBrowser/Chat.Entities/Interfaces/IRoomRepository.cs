using Chat.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities.Interfaces
{
    public interface IRoomRepository
    {
        List<ChatRoom> get();
    }
}
