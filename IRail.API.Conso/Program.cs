using IRail.API.Conso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace IRail.API.Conso
{
    class Program
    {
        private const string BASE_API_URI = "https://api.irail.be";
        static void Main(string[] args)
        {
            Console.WriteLine(GetLiveboardFrom("Gent-Sint-Pieters"));
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BASE_API_URI);

            //Définir le Médiatype approprié dans le Header Accept
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 0.8));
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));

            HttpResponseMessage response =  client.GetAsync(Program.GetLiveboardFrom("Gent-Sint-Pieters")).Result;
            if (response.IsSuccessStatusCode)
            {
                //Format de la réponse sérializé en class déterminée par l'utilisateur ATTENTION : System.Net.Http.Formatting à ajouter au Nuget si nécessaire
                Liveboard info = response.Content.ReadAsAsync<Liveboard>().Result;
                Console.WriteLine($"{info.Departures.Number}");
                string jsonInfo = JsonConvert.SerializeObject(info, Formatting.Indented);
                Console.WriteLine(jsonInfo);
                //Format de la réponse en string (XML/JSON/...)
                string resume = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resume);
            }
            Console.ReadLine();
        }

        private static string GetLiveboardFrom(string stationName,string time = null, string date = null, string format = "json", string lang="en")
        {
            time = time ?? DateTime.Now.Hour.ToString("##") + DateTime.Now.Minute.ToString("##");
            date = date ?? DateTime.Now.ToString("ddMMyy");
            return $"/liveboard/?station={stationName}&time={time}&date={date}&lang={lang}&format={format}";
        }
    }
}
