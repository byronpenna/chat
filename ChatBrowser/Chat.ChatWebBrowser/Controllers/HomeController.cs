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

            var userID = HttpContext.Session.GetString("userID");
            if(userID != null)
            {
                return RedirectToAction("Index", "Chat");
            }

            string url = this._APIConfig.Value.url+"User/get-by-email-pass";
            ApiHelper.InicializeClient();
            string responseContent = "";
            string strError = "";
            User usr = new User()
            {
                UserName = Request.Form["txtUserName"],
                Password = Encryptor.MD5Hash(Request.Form["txtPass"])
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(usr), System.Text.Encoding.UTF8, "application/json");
            User logedUser = null;
            using (HttpResponseMessage response = await ApiHelper.apiClient.PostAsync(url,content))
            {
                responseContent = await response.Content.ReadAsStringAsync();

                logedUser = JsonConvert.DeserializeObject<User>(responseContent);
            }

            if(logedUser == null)
            {
                strError = "Invalid credentials";
                return RedirectToAction("Index","Home", new { error = strError });
            }

            HttpContext.Session.SetString("userID",logedUser.Id.ToString());
            HttpContext.Session.SetString("userName", logedUser.UserName);

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
            User responseContent = null;
            bool error = false;
            ApiError apiError = null;
            string message="";
            string strError = "";
            HttpContent content = new StringContent(JsonConvert.SerializeObject(usr), System.Text.Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await ApiHelper.apiClient.PostAsync(url, content))
            {
                try { 

                    message = await response.Content.ReadAsStringAsync();
                    responseContent = JsonConvert.DeserializeObject<User>(message);
                    if(responseContent.Id == 0)
                    {
                        error = true;
                    }
                }
                catch (Exception)
                {
                    error = true;
                }

                //
            }

            if (error)
            {
                strError = "unhandle exception";
                try
                {

                    apiError = JsonConvert.DeserializeObject<ApiError>(message);
                    if(apiError.detail != "")
                    {
                        strError = apiError.detail;
                    }
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Register", "Home", new { error = strError });
            }


            HttpContext.Session.SetString("userID", responseContent.Id.ToString());
            HttpContext.Session.SetString("userName", usr.UserName);

            return RedirectToAction("Index", "Chat");
        }
        public IActionResult Register(string error = "")
        {
            ViewBag.error = error;
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.SetString("userID", null);
            HttpContext.Session.SetString("userName", null);

            return RedirectToAction("Index");
        }
        public IActionResult Index(string error = "")
        {
            ViewBag.error = error;
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
