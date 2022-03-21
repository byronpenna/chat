using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Chat.ChatWebBrowser.Controllers
{
    public class ChatController : Controller
    {
        public static Dictionary<int, string> Rooms = new Dictionary<int, string>()
        {
            {1,"Beers" },
            {2,"Software" }
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Room(int room)
        {
            return View("Room", room);
        }
        public IActionResult login()
        {
            return View();
        }
    }
}
