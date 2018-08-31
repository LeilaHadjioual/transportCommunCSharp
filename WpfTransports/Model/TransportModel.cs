using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTransports.Model
{
    
    public class Transport
    {
        //property définit les données
        //public String BusStation { get; set; }
        //public String BusLine { get; set; }

        //constructeur
        public Transport(string key, List<string> value)
        {
            Station = key;
            Lines = value;
        }
        //public String MyTitle { get; set; } // pour pouvoir l'utiliser dans la collectionObservable
        public string Station { get; set; }
        public List<string> Lines { get; set; }

    }
}
