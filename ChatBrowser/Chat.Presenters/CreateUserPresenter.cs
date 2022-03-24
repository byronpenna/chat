using Chat.Entities.POCOEntities;
using Chat.UseCases.Common.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Presenters
{
    public class CreateUserPresenter : IPresenter<User, User>
    {
        public User Content { get;  set; }
        
        public void Handle(User response)
        {
            Content = response;
        }
    }
}
