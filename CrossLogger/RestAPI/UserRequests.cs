using CrossLogger.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrossLogger.RestAPI
{
    public class UserRequests
    {
        public static async Task<string> Add(HttpClient client, IdentityUser user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var httpResponse = await client.PostAsync($"api/user/newuser", content);
            return await httpResponse.Content.ReadAsStringAsync();
        }

        public static async Task<bool> Exists(HttpClient client, string userId)
        {
            var httpResponse = await client.GetAsync($"api/user/checkforuser/{userId}");
            return JsonConvert.DeserializeObject<bool>(await httpResponse.Content.ReadAsStringAsync());
        }
    }
}
