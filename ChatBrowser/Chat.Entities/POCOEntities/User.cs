using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities.POCOEntities
{
    public  class User
    {
        /*
           id
           username
           name
           lastname
        */
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
