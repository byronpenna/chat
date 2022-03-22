using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities.POCOEntities
{
    public class Message
    {
        public int MessageId { get; set; }
        public int RoomId
        {
            get; set;
        }
        public int UserId
        {
            get; set;
        }
        public string content { get; set; }
        public DateTime createdDate { get; set; }

        public User user;
        public ChatRoom room;
        
    }
}
