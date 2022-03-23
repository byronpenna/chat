using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Net.Http;
using System.Threading.Tasks;
using Chat.Entities.POCOEntities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Chat.ChatWebBrowser.Controllers
{
    public class ChatController : Controller
    {
        public static Dictionary<int, string> Rooms = new Dictionary<int, string>()
        {
            {1,"Beers" },
            {2,"Software" }
        };
        public async Task<IActionResult> Index()
        {
            var userID = HttpContext.Session.GetString("userID");
            if(userID == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //int userID = HttpContext.Session.getS;
            string url = "https://localhost:44316/api/User/get-rooms";
            ApiHelper.InicializeClient();
            string message = "";
            List<ChatRoom> chatRooms = null;
            HttpContent content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(url))
            {
                message = await response.Content.ReadAsStringAsync();
                chatRooms = JsonConvert.DeserializeObject<List<ChatRoom>>(message);
            }

            ViewBag.Rooms = chatRooms;
            return View();
        }
        public async Task<IActionResult> Room(int room)
        {
            ApiHelper.InicializeClient();
            string responseContent = "";
            List<Message> messages = null;
            string url = "https://localhost:44316/api/User/get-message-by-room?roomID=" + room;
            HttpContent content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(url))
            {
                responseContent = await response.Content.ReadAsStringAsync();
                var x = JsonConvert.DeserializeObject(responseContent).ToString();
                messages = JsonConvert.DeserializeObject<List<Message>>(x);
            }
            ViewBag.messages = messages;
            ViewBag.roomID = room;
            //
            return View("Room", room);
        }
        public IActionResult login()
        {
            return View();
        }
    }
}
