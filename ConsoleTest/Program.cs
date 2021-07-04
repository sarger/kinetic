using KineticApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {

        
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            string url = "https://localhost:44322/";
            client.BaseAddress = new Uri(url);

            //Get 
            var found = GetCoinsAsync();
            Console.WriteLine($"Coins in string array =>   {found.Result})");

            //Create
             var serv =  AddCoin(1,8);
            Console.WriteLine($"Created.... " + serv.Result);

            //Create
             serv = AddCoin(50,15);
            Console.WriteLine($"Created.... " + serv.Result);

            //Get 
            found =  GetCoinsAsync();
            Console.WriteLine($"Coins in string array =>  {found.Result})");

            //Delete
            var statusCode =  Delete();
            Console.WriteLine($"Deleted returned HTTP Status => {(int)statusCode.Result}");

            //Get 
            found = GetCoinsAsync();
            Console.WriteLine($"Coins in string array after delete =>  {found.Result})");

            Console.ReadLine();
            Console.WriteLine( "End of a small informal test");
        }

        static async Task<Uri> AddCoin(decimal amount, decimal volume)
        {

            string json = JsonConvert.SerializeObject(new Coin {  Amount = amount, Volume = volume });

            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("Api/Values/Add", httpContent);
      
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        static async Task<string> GetCoinsAsync()
        {

            HttpResponseMessage response = await client.GetAsync("Api/Values/Get");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception("issue/not a good error message");
        }


        static async Task<HttpStatusCode> Delete()
        {
            HttpResponseMessage response = await client.DeleteAsync("Api/Values/Reset");
            return response.StatusCode;
        }

    }

}
