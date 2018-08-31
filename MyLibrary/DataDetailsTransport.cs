using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyLibrary
{
    public class DataDetailsTransport
    {
        private IConnexion Connect;

        //constructeur
        public DataDetailsTransport(IConnexion conn)
        {
            Connect = conn;
        }

        //connexion à l'api pour récupèrer les détails d'une ligne de bus 
       public DetailsTransports GetDetailsLine(String idLine)
        {
            String url = "http://data.metromobilite.fr/api/routers/default/index/routes?codes=" + idLine;
            String co = Connect.ConnectApi(url);
            List<DetailsTransports> detailsLine = JsonConvert.DeserializeObject<List<DetailsTransports>>(co);
            return detailsLine[0];
        }
    }
}
