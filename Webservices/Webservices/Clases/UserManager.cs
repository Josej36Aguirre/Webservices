using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
namespace Webservices.Clases
{
    class UserManager
    {
        const String URL = "http://192.168.0.105/SmartMarketWeb/index.php/Promocionescontroller/mostrar_movil";
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<IEnumerable<User>> GetUser()
        {
            HttpClient client = GetClient();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<User>>(content);
            }
            return Enumerable.Empty<User>();
        }
    }
}
