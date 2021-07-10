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
    static class ProductRepo
    {
        public static async Task<List<Product>> getAllProtucts()
        {
            List<Product> lista = new List<Product>();
            HttpResponseMessage responseMessage = await Client.client.GetAsync("Product/getAll");
            if(responseMessage.IsSuccessStatusCode)
            {
                string jsonResult = await responseMessage.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Product>>(jsonResult);
            }
            return lista;
        }
    }
}
