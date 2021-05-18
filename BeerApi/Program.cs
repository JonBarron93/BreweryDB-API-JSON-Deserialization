using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeerApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            //Random Beer
            var randomBeerResponse = client.GetStringAsync("http://api.brewerydb.com/v2/beer/random/?key=40458894fcdedcacd895893ec611396a").Result;
            JToken rBeer = JToken.Parse(randomBeerResponse);
            var rBeerName = rBeer.SelectToken("data.style.name").ToString();
            var beerClass = new beer();
            


            Console.WriteLine("RANDOM BEER");
            Console.WriteLine(rBeerName);

            //List of Beer
            var beerResponse = client.GetStringAsync("http://api.brewerydb.com/v2/beers/?key=40458894fcdedcacd895893ec611396a").Result;
            var beers = JsonConvert.DeserializeObject<BeerList>(beerResponse);


            foreach (var b in beers.data)
            {
                Console.WriteLine($"Name: {b.name} ID: {b.id} ABV: {b.abv}%");
            }
        }
    }
}
