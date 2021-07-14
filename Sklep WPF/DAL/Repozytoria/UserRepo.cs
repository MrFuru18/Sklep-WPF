using Newtonsoft.Json;
using Sklep_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.DAL.Repozytoria
{
    static class UserRepo
    {
        public static async Task<User> Login(LoginModel login)
        {
            User user = null;
            string serializedLogin = JsonConvert.SerializeObject(login);
            HttpResponseMessage responseMessage = await ClientHttp.Client
                .PostAsync("User/Login", new StringContent(serializedLogin, Encoding.UTF8, "application/json"));
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
    }
}
