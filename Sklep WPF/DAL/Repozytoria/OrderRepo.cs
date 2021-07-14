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
    static class OrderRepo
    {
        public static async Task<List<Order>> getAllAddresses()
        {
            List<Order> lista = new List<Order>();
            HttpResponseMessage responseMessage = await ClientHttp.Client.GetAsync("Order/getAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonResult = await responseMessage.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Order>>(jsonResult);
            }
            return lista;
        }

        public static async Task<Order> makeOrder(Order order)
        {
            Order result = null;
            string serializedAddress = JsonConvert.SerializeObject(order);
            HttpResponseMessage responseMessage = await ClientHttp.Client
                .PostAsync("Order/makeOrder", new StringContent(serializedAddress, Encoding.UTF8, "application/json"));
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonResult = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Order>(jsonResult);
            }
            return result;
        }

        public static async Task<Order> confirmOrder(Order order)
        {
            Order result = null;
            string serializedAddress = JsonConvert.SerializeObject(order);
            HttpResponseMessage responseMessage = await ClientHttp.Client
                .PostAsync("Order/confirmOrder", new StringContent(serializedAddress, Encoding.UTF8, "application/json"));
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonResult = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Order>(jsonResult);
            }
            return result;
        }

    }
}
