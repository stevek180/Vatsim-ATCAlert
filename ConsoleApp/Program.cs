using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("This will monitor an airport code when Tower comes online.");
            Console.WriteLine("Enter a three- or four-character airport code, i.e. 'BOS'.  Do not use 'KBOS'");
            Console.WriteLine("Note that US airports omit the leading 'K', but others use the full ICAO code.");
            //todo:  add logic that removes K for us airports, or similar.  
            var airportCode = Console.ReadLine().ToUpper();

            Console.WriteLine($"Monitoring every 30 seconds for ATC that starts with '{airportCode}_' and contains 'TWR' ");

            bool found = false;
            while(!found)
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://api.vatsim.net/v2/atc/online";
                    
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Process the successful response here
                        string responseData = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(responseData);
                        
                        if(IsTowerOnline(airportCode,responseData))
                        {
                            Console.WriteLine($"{airportCode} Tower is online.");
                            Console.Beep(3000,200);
                            Console.Beep(4000,200);
                            Console.Beep(3000,200);
                            return;

                        }
                        else
                            Console.WriteLine($"No {airportCode} tower yet.");




                    }
                }
                System.Threading.Thread.Sleep(30*1000);


                
            }
        }

        private static bool IsTowerOnline(string airportCode, string VatsimJSON)
        {
            JArray jsonArray = JArray.Parse(VatsimJSON);
            Console.WriteLine(jsonArray.Count);

            bool found = false;
            
            foreach (JObject obj in jsonArray)
            {
                //Console.WriteLine("Checking " + obj["callsign"]);

                found = (obj["callsign"].ToString().StartsWith($"{airportCode}_") && 
                        obj["callsign"].ToString().Contains("TWR"));
                if (found)
                    break;
                    

                
            }
            return found;
        }

    }
}
