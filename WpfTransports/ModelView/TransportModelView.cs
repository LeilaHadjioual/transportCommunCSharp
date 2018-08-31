using MyLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTransports.Model;

namespace WpfTransports.ModelView
{
    public class TransportModelView : INotifyPropertyChanged

    {   //attributs
        private string latitude;
        private string longitude;
        private int distance;
        private ObservableCollection<Transport> transports;
        //attribut pour pouvoir utiliser l'interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        //property liées aux attributs
        public int Distance
        {
            get { return distance; }
            set
            {
                if (distance != value)
                {
                    distance = value;
                    LoadTransport();
                    RaisePropertyChanged("Distance");
                }
            }
        }

        public string Longitude
        {
            get { return longitude; }
            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    LoadTransport();
                    RaisePropertyChanged("Longitude");
                }
            }
        }

        public string Latitude
        {
            get { return latitude; }
            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    LoadTransport();
                    RaisePropertyChanged("Latitude");
                }
            }
        }

        public ObservableCollection<Transport> Transports
        {
            get
            {
                return transports;
            }
            set
            {
                if (transports != value)
                {
                    transports = value;
                    RaisePropertyChanged("Transports");
                }
            }
        }

        public String MonTitre
        {
            get;
            set;
        }

        //constructeur
        public TransportModelView()
        {
            latitude = "45.185476";
            longitude = "5.727772";
            distance = 600;

            LoadTransport();
        }

        //méthode qui affiche les arrets et ligne de bus
        public void LoadTransport()
        {
            Unduplicate connect = new Unduplicate(new Connexion());
            Dictionary<string, List<string>> result = connect.RemoveDuplicate(latitude, longitude, distance);

            MonTitre = "Rechercher une ligne de bus à proximité";// titre dont la property est définit plus haut, binder dans la vue MonTitre

            ObservableCollection<Transport> bus = new ObservableCollection<Transport>();
            bus = transformDictionaryInList(result);
            Transports = bus;
        }

        //méthode qui transforme un dictionnaire en liste de string
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

        //méthode qui permet de notifier si un une modification a eu lieu  
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}

