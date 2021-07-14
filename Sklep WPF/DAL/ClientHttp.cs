using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_WPF.DAL
{
    class ClientHttp : HttpClient
    {
        private static ClientHttp client = null;
        public static ClientHttp Client
        {
            get
            {
                if (client == null)
                    client = new ClientHttp();
                return client;
            }
        }

        private ClientHttp() : base()
        {
            client.BaseAddress = new Uri("http://localhost:44306/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
