using Chat.ChatWebBrowser.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Chat.Entities.POCOEntities;
using Chat.ChatWebBrowser.Security;
using Microsoft.Extensions.Options;

namespace Chat.ChatWebBrowser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<MyAPIConfig> _APIConfig;
        public HomeController(ILogger<HomeController> logger, IOptions<MyAPIConfig> config)
        {
            _APIConfig = config;
            _logger = logger;
        }
        public async Task<IActionResult> Login()
        {
            string url = this._APIConfig.Value.url+"User/get-by-email-pass";
            ApiHelper.InicializeClient();
            string responseContent = "";
            User usr = new User()
            {
                UserName = Request.Form["txtUserName"],
                Password = Encryptor.MD5Hash(Request.Form["txtPass"])
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(usr), System.Text.Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await ApiHelper.apiClient.PostAsync(url,content))
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }

            if(responseContent == "-1")
            {
                ViewBag.error = "Invalid credentials";
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetString("userID",responseContent);
            return RedirectToAction("Index","Chat");
            //return View();
        }
        public async Task<IActionResult> RegisterAction()
        {
            ApiHelper.InicializeClient();
            User usr = new User()
            {
                UserName = Request.Form["txtUserName"],
                Password = Encryptor.MD5Hash(Request.Form["txtPass"]),
                Email = Request.Form["txtEmail"]
            };
            string url = this._APIConfig.Value.url + "User/create-user";
            string responseContent = "";
            HttpContent content = new StringContent(JsonConvert.SerializeObject(usr), System.Text.Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await ApiHelper.apiClient.PostAsync(url, content))
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }
            HttpContext.Session.SetString("userID", responseContent);
            return RedirectToAction("Index", "Chat");

        }
        public IActionResult Register()
        {
            
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.SetString("userID", null);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var y = HttpContext.Session;
            return View();
        }

        public IActionResult Privacy()
        {
            
            var y = HttpContext.Session.GetString("userID");
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
