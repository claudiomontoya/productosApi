using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace apiVs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese texto a buscar: ");
            string texto = Console.ReadLine();
            respuestaData data = new respuestaData();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://dummyjson.com/products/search?q="+texto);
                var response = client.GetAsync("").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<respuestaData>(responseString);
                }
                if (data.products.Count > 0)
                {
                    foreach (var item in data.products)
                    {
                        Console.WriteLine(item.id +" " + item.title + " Marca: " + item.brand + " Precio:" + item.price);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron Articulos!!");
                }

            }
            Console.ReadKey();
        }
    }
}
