using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

namespace Application_Windows_Phone_Serre
{
    public sealed partial class GererEtatSerre : Page
    {
        ConnexionServeur cs;

        

        public GererEtatSerre()
        {
            this.InitializeComponent();
            
        }

        private void buttonEtat_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }


        private void TempProfilModif_TextChanged(object sender, TextChangedEventArgs e)
        {
            VoyantTemp.Fill = new SolidColorBrush(Colors.DarkGreen);
        }

        private void HumiProfilModif_TextChanged(object sender, TextChangedEventArgs e)
        {
            VoyantHumi.Fill = new SolidColorBrush(Colors.DarkGreen);
        }

        private void EnsoProfilModif_TextChanged(object sender, TextChangedEventArgs e)
        {
            VoyantEnso.Fill = new SolidColorBrush(Colors.DarkGreen);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            cs = (ConnexionServeur)e.Parameter;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = cs;
            cs.LoadDataProfilActuel();
            
            
        }


        private void buttonEnvoyerProfilActuel_Click(object sender, RoutedEventArgs e)
        {

            cs.SendDataReglage(cs.IdProfil, cs.IdReglage, TempProfilModif.Text, HumiProfilModif.Text);
            
        }

        private void buttonRafraichir_Click(object sender, RoutedEventArgs e)
        {
            DataContext = cs;
            cs.LoadDataProfilActuel();
        }

       
    }
}
