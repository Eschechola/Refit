using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RefitProject.Tradictional
{
    class Program
    {
        private readonly string _apiUrl;

        public Program()
        {
            _apiUrl = "https://refitapi.herokuapp.com/api/v1/customer/";
        }
        
        static void Main(string[] args)
        {
            new Program().Execute()
                .GetAwaiter()
                .GetResult();

            Console.ReadKey();
        }
        
        private async Task Execute()
        {
            var customer = await GetAsync(15362);

            Console.WriteLine("Cliente encontrado!\n\n" + JsonConvert.SerializeObject(customer, Formatting.Indented));
        }
        
        private async Task<Customer> GetAsync(int id)
        {
            using(var client = new HttpClient())
            {
                Customer customer = null;

                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"{id}");

                if (response.IsSuccessStatusCode)
                {
                    customer = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
                }

                return customer;
            }
        }
    }
}
