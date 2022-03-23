using Chat.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Presenters
{
    public class GetRoomPresenter:IPresenter<List<ChatRoom>, List<ChatRoom>>
    {
        public List<ChatRoom> Content { get; set; }
        public void Handle(List<ChatRoom> rooms)
        {
            Content = rooms;
        }
    }
}
