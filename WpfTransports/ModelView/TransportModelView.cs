using MyLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTransports.Model;

namespace WpfTransports.ModelView
{
    public class TransportModelView
    {
        //constructeur
        public TransportModelView()
        {
            LoadTransport();
        }

        public String MonTitre
        {
            get;
            set;
        }

        public ObservableCollection<Transport> Transports
        {
            get;
            set;
        }


        public void LoadTransport()
        {
            String latitude = "45.185476";
            String longitude = "5.727772";
            int distance = 600;

            Unduplicate connect = new Unduplicate(new Connexion());
            Dictionary<string, List<string>> result = connect.RemoveDuplicate(latitude, longitude, distance);

            MonTitre = "Rechercher une ligne de bus à proximité";// titre dont la property est définit plus haut, binder dans la vue MonTitre

            ObservableCollection<Transport> bus = new ObservableCollection<Transport>();
            bus = transformDictionaryInList(result);
            Transports = bus;
        }

        public ObservableCollection<Transport> transformDictionaryInList(Dictionary<string, List<string>> myDico)
        {
            ObservableCollection<Transport> newList = new ObservableCollection<Transport>();
            foreach (KeyValuePair<string, List<string>> kvp in myDico)
            {
                Transport listTransport = new Transport(kvp.Key, kvp.Value);
                newList.Add(listTransport);
            }
            return newList;
        }

    }
}

