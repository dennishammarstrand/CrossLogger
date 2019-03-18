using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossLoggerDataManager.Data;
using CrossLoggerDataManager.Models;
using CrossLoggerDataManager.Processors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrossLoggerDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDbContext database;

        public UserController(AppDbContext _database)
        {
            database = _database;
        }

        [HttpPost("newuser")]
        public string NewUser(User user)
        {
            return UserProcessor.Create(database, user);
        }

        [HttpGet("checkforuser/{userid}")]
        public ActionResult<bool> CheckForUser(string userId)
        {
            return UserProcessor.UserExists(database, userId);
        }
    }
}
