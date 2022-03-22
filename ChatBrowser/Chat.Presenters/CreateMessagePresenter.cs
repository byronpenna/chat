using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Presenters
{
    public class CreateMessagePresenter:IPresenter<int,int>
    {
        public int Content { get; set; }
        public void Handle(int response)
        {
            Content = response;
        }
    }
}
