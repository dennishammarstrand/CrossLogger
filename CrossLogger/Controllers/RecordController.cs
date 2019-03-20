using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CrossLogger.RestAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrossLogger.Controllers
{
    [Authorize]
    public class RecordController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private HttpClient client;

        public RecordController(UserManager<IdentityUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            client = httpClientFactory.CreateClient("CrossLoggerAPI");
        }

        public async Task<ActionResult> Index()
        {
            var userID = await _userManager.GetUserAsync(HttpContext.User);
            if (!await UserRequests.Exists(client, userID.Id))
            {
                string response = await UserRequests.Add(client, userID);
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Record/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Record/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Record/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Record/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Record/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}