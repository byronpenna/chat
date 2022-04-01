using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Presenters
{
    public class GetStockPresenter : IPresenter<string, string>
    {
        public string Content { get; set; }
        public void Handle(string messages)
        {
            Content = messages;
            
            //Content = messages;
        }
    }
}
