using Chat.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Presenters
{
    public class LoginPresenter:IPresenter<User,User>
    {
        public User Content { get; set; }
        public void Handle(User response)
        {
            if(response != null)
            {
                response.Password = "";
            }
            Content = response;
        }
    }
}
