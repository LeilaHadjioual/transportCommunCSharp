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
        //méthode qui supprime les doublons
        public Dictionary<string, List<string>> RemoveDuplicate(List<BusStationObject> listStation)
        {
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
