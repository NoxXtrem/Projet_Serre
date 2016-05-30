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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Application_Windows_Phone_Serre
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GererEtatSerre : Page
    {
        double profilActuelTemp = 0;
        double profilActuelHumi = 0;
        double profilActuelEnso = 0;
        String profilActuelNom = "profil actuel";
        DateTime profilActuelDate = new DateTime();
        double nouveauProfilTemp;
        double nouveauProfilEnso;
        double nouveauProfilHumi;
        ConnexionServeur cs = new ConnexionServeur();








        public GererEtatSerre()
        {
            this.InitializeComponent();
        }

        private void buttonEtat_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void buttonProfil_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GererProfils));
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
   
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
