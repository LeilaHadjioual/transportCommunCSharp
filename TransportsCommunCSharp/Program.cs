using MyLibrary;
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

            //récupère les coordonnées 7 rue hoche
            String latitude = "45.185476";
            String longitude = "5.727772";
            int distance = 400;

            //connexion à la 1ère api et suppression des doublons d'arrêts bus via méthode removeduplicate
            Unduplicate fistConnect = new Unduplicate(new Connexion());
            Dictionary<string, List<string>> result = fistConnect.RemoveDuplicate(latitude, longitude, distance);

            //utilise la 2ème api pour avoir le détail des lignes et convertit en Json
            DataDetailsTransport dataDetailsTransport = new DataDetailsTransport(new Connexion());

            //affichage du nouveau dictionnaire result avec les détails arrêt de bus via l'appel à la 2ème api
            foreach (KeyValuePair<string, List<string>> kvp in result)
            {
                Console.WriteLine("\nArret = " + kvp.Key);
                foreach (string line in kvp.Value)
                {
                    Console.WriteLine("    " + dataDetailsTransport.GetDetailsLine(line).mode + " " + dataDetailsTransport.GetDetailsLine(line).shortName + "   couleur = " + dataDetailsTransport.GetDetailsLine(line).color + "   nom ligne = " + dataDetailsTransport.GetDetailsLine(line).longName);
                }
            }
        }
    }
}


