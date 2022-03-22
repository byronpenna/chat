using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCasesDTOs.CreateMessage
{
    public class CreateMessageParams
    {
        public int id
        {
            get;set;
        }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string Content { get; set; }
        public DateTime createdDate { get; set;}
    }
}
