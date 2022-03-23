using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Net.Http;
using System.Threading.Tasks;
using Chat.Entities.POCOEntities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace Chat.ChatWebBrowser.Controllers
{
    public class ChatController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<MyAPIConfig> _APIConfig;
        public ChatController(ILogger<HomeController> logger, IOptions<MyAPIConfig> config)
        {
            _APIConfig = config;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var userID = HttpContext.Session.GetString("userID");
            var userName = HttpContext.Session.GetString("userName");
            if (userID == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //int userID = HttpContext.Session.getS;
            string url = this._APIConfig.Value.url + "User/get-rooms";
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
            ViewBag.UserName = userName;
            return View();
        }
        public async Task<IActionResult> Room(int room)
        {
            ApiHelper.InicializeClient();
            string responseContent = "";
            var userName = HttpContext.Session.GetString("userName");
            List<Message> messages = null;
            string url = this._APIConfig.Value.url + "User/get-message-by-room?roomID=" + room;
            HttpContent content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(url))
            {
                responseContent = await response.Content.ReadAsStringAsync();
                var x = JsonConvert.DeserializeObject(responseContent).ToString();
                messages = JsonConvert.DeserializeObject<List<Message>>(x);
            }
            ViewBag.messages = messages;
            ViewBag.roomID = room;
            ViewBag.UserName = userName;
            //
            return View("Room", room);
        }
        public IActionResult login()
        {
            return View();
        }
    }
}
