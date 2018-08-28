using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportsCommunCSharp;

namespace MyLibrary
{
    public class Unduplicate
    {
        private IConnexion Connect;
     
        //constructeur
        public Unduplicate(IConnexion con)
        {
            Connect = con;
        }
       
        //méthode qui permet de se connecter 1ère api
        private List<BusStationObject> convertJsonList(String latitude, String longitude, Int32 distance)
        {
            String url = "http://data.metromobilite.fr/api/linesNear/json?x=" + longitude + "&y=" + latitude + "&dist=" + distance + "&details=true";
            String co = Connect.ConnectApi(url);
            List<BusStationObject> busStation = JsonConvert.DeserializeObject<List<BusStationObject>>(co);
            return busStation;
        }

        //méthode qui supprime les doublons
        public Dictionary<string, List<string>> RemoveDuplicate(String latitude, String longitude, Int32 distance)
        {
            List<BusStationObject> listStation = convertJsonList(latitude, longitude, distance);
            
            Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();

            foreach (BusStationObject station in listStation)
            {
                if (!myDictionary.ContainsKey(station.name))
                {
                    myDictionary.Add(station.name, station.lines);
                }
                else
                {
                    foreach (string line in station.lines)
                    {
                        if (!myDictionary[station.name].Contains(line))
                        {
                            myDictionary[station.name].Add(line);
                        }
                    }
                }
            }
            return myDictionary;
        }
    }
}
