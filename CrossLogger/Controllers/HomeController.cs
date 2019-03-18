using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrossLogger.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using CrossLogger.RestAPI;

namespace CrossLogger.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private HttpClient client;

        public HomeController(UserManager<IdentityUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            client = httpClientFactory.CreateClient("CrossLoggerAPI");
        }

        public async Task<IActionResult> Index()
        {
            var userID = await _userManager.GetUserAsync(HttpContext.User);
            if (!await UserRequests.Exists(client, userID.Id))
            {
                User user = new User
                {
                    Id = userID.Id,
                    UserName = userID.UserName,
                    Email = userID.Email
                };
                string response = await UserRequests.Add(client, user);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
