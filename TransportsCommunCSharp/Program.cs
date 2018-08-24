﻿using MyLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TransportLibrary;

namespace TransportsCommunCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            //connexion à l'API
            Connexion connect = new Connexion();

            //récupère les coordonnées 7 rue hoche
            String latitude = "45.185476";
            String longitude = "5.727772";
            int distance = 800;

            //déclare l'url
            String url = "http://data.metromobilite.fr/api/linesNear/json?x=" + longitude + "&y=" + latitude + "&dist=" + distance + "&details=true";

            //stocke la réponse de la méthode coccect.Api
            String ResponseFromServer = connect.ConnectApi(url);

            //utilise l'objet BusStationObject et convertit le flux JSON en objet C# ---- "ajout package nuget newtonsoft.json et création d'un objet BusstationObject via json2charp.com"
            List<BusStationObject> busStation = JsonConvert.DeserializeObject<List<BusStationObject>>(ResponseFromServer);

            Unduplicate lib = new Unduplicate();
            Dictionary<string, List<string>> result = lib.RemoveDuplicate(busStation);

            //affichage du nouveau dictionnaire result
            foreach (KeyValuePair<string, List<string>> kvp in result)
            {
                Console.WriteLine("Arret = " + kvp.Key);
                foreach (string line in kvp.Value)
                {
                    int delimiter = line.IndexOf(":");
                    Console.WriteLine("    Ligne = " + line.Substring(delimiter + 1));
                }

            }


            //--------------------------------AUTRES EXEMPLES--------------------------------------------------------------------//

            //affiche le nom de l'arret bus à la place x de la collection 
            //Console.WriteLine(busStation[1].name);

            //---------------1ère méthode sans dictionary---------------
            //boucle qui parcourt la collection et affiche le nom de chaque station bus et la ligne de bus
            //foreach (BusStationObject station in busStation)
            //{
            //    foreach (string line in station.lines)
            //    {
            //        int delimiter = line.IndexOf(":");
            //        Console.WriteLine(station.name + " -- Bus N°: " + line.Substring(delimiter + 1));
            //    }
            //}

            //--------------utilisation de la classe dictionary------------------------- 
            //Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();

            //foreach (BusStationObject station in busStation)
            //{
            //    try
            //    {
            //        if (!myDictionary.ContainsKey(station.name))
            //        {
            //            myDictionary.Add(station.name, station.lines);
            //        }
            //        else
            //        {
            //            foreach (string line in station.lines)
            //            {
            //                if (!myDictionary[station.name].Contains(line))
            //                {
            //                    myDictionary[station.name].Add(line);
            //                }
            //            }
            //        }
            //    }
            //    catch (ArgumentException)
            //    {
            //        Console.WriteLine("An element with Key = " + station.name + " already exists.");
            //    }
            //}

            ////affichage du dictionnaire
            //foreach (KeyValuePair<string, List<string>> kvp in myDictionary)
            //{
            //    Console.WriteLine("Arret = " + kvp.Key);
            //    foreach (string line in kvp.Value)
            //    {
            //        int delimiter = line.IndexOf(":");
            //        Console.WriteLine("    Ligne = " + line.Substring(delimiter + 1));
            //    }


        }


    }
}


