using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCasesDTOs.CreateUser
{
    public class CreateUserParams
    {
        public int id
            { get; set; }
        public string username { get; set; }
        public DateTime CreatedDate { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
