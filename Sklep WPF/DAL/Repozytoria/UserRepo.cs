using Newtonsoft.Json;
using Sklep_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.DAL.Repozytoria
{
    static class UserRepo
    {
        public static async Task<User> Login(LoginModel login)
        {
            User user = null;
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "User/Login");
            req.Content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await ClientHttp.Client.SendAsync(req).ConfigureAwait(false);
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonResult = await responseMessage.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(jsonResult);
            }
            return user;
        }

        public static void Logout()
        {
            ClientHttp.Client.GetAsync("User/Logout");
        }

        public static async Task<RegisterResult> Register(RegisterModel model)
        {
            RegisterResult result = null;
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "User/Register");
            req.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await ClientHttp.Client.SendAsync(req).ConfigureAwait(false);
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonResult = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<RegisterResult>(jsonResult);
            }
            return result;
        }
    }
}
