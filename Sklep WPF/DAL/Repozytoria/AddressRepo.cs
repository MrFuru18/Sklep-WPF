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
    static class AddressRepo
    {
        public static async Task<List<Address>> getAllAddresses()
        {
            List<Address> lista = new List<Address>();
            HttpResponseMessage responseMessage = await ClientHttp.Client.GetAsync("Address/getAll").ConfigureAwait(false);
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonResult = await responseMessage.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Address>>(jsonResult);
            }
            return lista;
        }

        public static async Task<Address> addAddress(Address address)
        {
            Address result = null;
            string serializedAddress = JsonConvert.SerializeObject(address);
            HttpResponseMessage responseMessage = await ClientHttp.Client
                .PostAsync("Address/addAddress", new StringContent(serializedAddress, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonResult = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Address>(jsonResult);
            }
            return result;
        }
    }
}
