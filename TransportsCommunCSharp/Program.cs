using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TransportsCommunCSharp
{
    class Program
    {


        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            //coordonnées 7 rue hoche
            String latitude = "45.185476";
            String longitude = "5.727772";
            int distance = 800;

            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create("http://data.metromobilite.fr/api/linesNear/json?x=" + longitude + "&y=" + latitude + "&dist=" + distance + "&details=true");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            //Console.WriteLine(responseFromServer);

            //utilise l'objet BusStationObject et convertit le flux JSON en objet C# ---- "ajout package nuget newtonsoft.json et création d'un objet BusstationObject via json2charp.com"
            List<BusStationObject> busStation = JsonConvert.DeserializeObject<List<BusStationObject>>(responseFromServer);
            //affiche le nom de l'arret bus à la place x de la collection 
            //Console.WriteLine(busStation[1].name);

            //boucle qui parcourt la collection et affiche le nom de chaque station bus et la ligne de bus
            foreach (BusStationObject station in busStation)
            {

                foreach (string line in station.lines)
                {
                    int delimiter = line.IndexOf(":");
                    Console.WriteLine(station.name + " -- Bus N°: " + line.Substring(delimiter + 1));
                }
            }

            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}
