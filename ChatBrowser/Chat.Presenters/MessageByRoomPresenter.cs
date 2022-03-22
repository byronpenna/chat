using Chat.Entities.POCOEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Presenters
{
    public class MessageByRoomPresenter:IPresenter<List<Message>, string>
    {
        public string Content { get; set; } 
        public void Handle(List<Message> messages)
        {
            Content = JsonConvert.SerializeObject(messages);
            //Content = messages;
        }
    }
}
