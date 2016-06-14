using Newtonsoft.Json;
using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.Web.Http;

namespace Application_Windows_Phone_Serre
{
    class ConnexionServeur : INotifyPropertyChanged
    {
        System.Net.Http.HttpClient httpc = new System.Net.Http.HttpClient();
        String profilActuelNom = "Aucun Profil";
        String profilActuelDate = "";
        String profilActuelTemp = "0";
        String profilActuelHumi = "0";
        String profilActuelEnso = "0";
        int idProfil;
        int idReglage;
        string ipServeur = "localhost:37768";
        //string ipServeur = "10.0.0.164:37768";


        public int IdReglage
        {
            get { return idReglage; }
            set 
            { 
                idReglage = value;
                RaisePropertyChanged("IdReglage");
            }
        }

        public int IdProfil
        {
            get { return idProfil; }
            set 
            { 
                idProfil = value;
                RaisePropertyChanged("IdProfil");
            }
        }
        

        public String ProfilActuelNom
        {
            get { return profilActuelNom; }
            set 
            { 
                profilActuelNom = value;
                RaisePropertyChanged("ProfilActuelNom");
            }
        }

        public String ProfilActuelDate
        {
            get { return profilActuelDate; }
            set 
            { 
                profilActuelDate = value;
                RaisePropertyChanged("ProfilActuelDate");
            }
        }
        public String ProfilActuelTemp
        {
            get { return profilActuelTemp; }
            set 
            {
                profilActuelTemp = value;
                RaisePropertyChanged("ProfilActuelTemp");
            }
        }
        public String ProfilActuelHumi
        {
            get { return profilActuelHumi; }
            set 
            { 
                profilActuelHumi = value;
                RaisePropertyChanged("ProfilActuelHumi");
            }
        }
        public String ProfilActuelEnso
        {
            get { return profilActuelEnso; }
            set 
            { 
                profilActuelEnso = value;
                RaisePropertyChanged("ProfilActuelEnso");
            }
        }

        public ConnexionServeur()
        {
            httpc.BaseAddress = new Uri("http://" + ipServeur);
            httpc.DefaultRequestHeaders.Accept.Clear();
            httpc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public virtual void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public async void LoadDataCapteur(TextBlock tbTempInt, TextBlock tbTempExt, TextBlock tbHumi, TextBlock tbEnso, TextBlock tbVent)
        {
            var reponse = await httpc.GetAsync("/api/Capteur");
            LigneHistoriqueViewModel lhvm = JsonConvert.DeserializeObject<LigneHistoriqueViewModel>(await reponse.Content.ReadAsStringAsync());
            tbTempExt.Text = lhvm.TemperatureExterieur.ToString();
            tbTempInt.Text = lhvm.TemperatureInterieur.ToString();
            tbHumi.Text = lhvm.Humidite.ToString();
            tbEnso.Text = lhvm.Lumiere.ToString();
            tbVent.Text = "0";
        }

        public async void LoadDataProfil()
        {
            var reponse = await httpc.GetAsync("/api/Profil");
            var temp = reponse.Content;
            
        }

        public async void LoadDataReglage(int idProfil)
        {
            var reponse = await httpc.GetAsync("/api/Reglage");
            var temp = reponse.Content;

        }
        public async void LoadDataProfilActuel()
        {
            var reponse = await httpc.GetAsync("/api/ProfilActuel");
            dynamic json = JsonConvert.DeserializeObject(await reponse.Content.ReadAsStringAsync());
            ProfilViewModel p = JsonConvert.DeserializeObject<ProfilViewModel>(json.profil.ToString());
            int dt = (DateTime.Now - DateTime.Parse(json.date.ToString())).Days;


            var reponse2 = await httpc.GetAsync("/api/Capteur");
            LigneHistoriqueViewModel lhvm = JsonConvert.DeserializeObject<LigneHistoriqueViewModel>(await reponse2.Content.ReadAsStringAsync());
            var reponse3 = await httpc.GetAsync("/api/Reglage/" + lhvm.Id_profil + "/" + lhvm.Id_reglage);
            ReglageViewModel rvm = JsonConvert.DeserializeObject<ReglageViewModel>(await reponse3.Content.ReadAsStringAsync());
            

            if (p == null)
            {
                ProfilActuelNom = "Aucun Profil";
                ProfilActuelDate = "";
                ProfilActuelTemp = "0";
                ProfilActuelHumi = "0";
                ProfilActuelEnso = "0";

            }
            else
            {
                IdProfil = p.Id;
                IdReglage = rvm.IdReglage;
                ProfilActuelNom = p.Nom;
                ProfilActuelDate = "Jour " + dt;
                ProfilActuelTemp = rvm.TemperatureInterieur.ToString();
                ProfilActuelHumi = rvm.Humidite.ToString();
                ProfilActuelEnso = rvm.Lumiere.ToString();
            }
        }

        public async void SendDataReglage(int idProfil, int idReglage, String temp, String humi, String duree = "-1", String enso = "-1")
        {
            ReglageViewModel r = new ReglageViewModel()
            {
                TemperatureInterieur = double.Parse(temp),
                Humidite = double.Parse(humi),
                Duree = int.Parse(duree),
                Lumiere = double.Parse(enso),
            };

            string content = JsonConvert.SerializeObject(r);

            var reponse = await httpc.PutAsync("/api/Reglage/" + idProfil + "/" + idReglage, new StringContent(content, Encoding.UTF8, "application/json"));
            var t = reponse;
        }

        public async void SendDataProfilActuel(int id, DateTime dt)
        {
            var content = JsonConvert.SerializeObject(new { Id = id.ToString(), Date = dt.ToString("yyyy-MM-dd")});
            var reponse = await httpc.PutAsync("/api/ProfilActuel", new StringContent(content));
        }
        
    }
}
