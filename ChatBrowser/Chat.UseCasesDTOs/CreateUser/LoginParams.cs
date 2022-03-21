using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCasesDTOs.CreateUser
{
    public class LoginParams
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
    }
}
