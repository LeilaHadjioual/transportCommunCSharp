using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTransports.Model
{
    public class Transport
    {
        //property définit les données - utilisées pour affichage en dur
        //public String BusStation { get; set; }
        //public String BusLine { get; set; }
        //public String MyTitle { get; set; } // à déclarer dans model suelement si on veut l'utiliser dans la collectionObservable

        public string Station { get; set; }
        public List<string> Lines { get; set; }

        //constructeur
        public Transport(string key, List<string> value)
        {
            Station = key;
            Lines = value;
        }
    }
}
