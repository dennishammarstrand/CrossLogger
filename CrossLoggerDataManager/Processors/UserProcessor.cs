using CrossLoggerDataManager.Data;
using CrossLoggerDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossLoggerDataManager.Processors
{
    public class UserProcessor
    {
        public static bool UserExists(AppDbContext database, string userId)
        {
            return database.User.Where(x => x.ID == userId).Count() > 0;
        }

        public static string Create(AppDbContext database, User user)
        {
            User newUser = new User
            {
                ID = user.ID,
                Username = user.Username,
                Email = user.Email
            };

            database.Add(newUser);
            database.SaveChangesAsync();

            return "User Added";
        }
    }
}
