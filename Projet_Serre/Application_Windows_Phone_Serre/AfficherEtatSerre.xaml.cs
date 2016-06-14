using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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


namespace Application_Windows_Phone_Serre
{
    public sealed partial class MainPage : Page
    {
        
        ConnexionServeur cs = new ConnexionServeur();


        public MainPage()
        {
            this.InitializeComponent();
            DataContext = cs;
            this.NavigationCacheMode = NavigationCacheMode.Required;

            
            Loaded += MainPage_Loaded;
        }
       private void buttonGestion_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GererEtatSerre),cs);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            cs = (ConnexionServeur)e.Parameter;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            cs.LoadDataProfilActuel();
            cs.LoadDataCapteur(captTempIntSerre, captTempExtSerre, captHumiSerre, captEnsoSerre, captVentSerre);
 
        }
        /*
        private void captTempIntSerre_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (captTempIntSerre.Text == "0")
            {
                VoyantEtatTemp.Fill = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                VoyantEtatTemp.Fill = new SolidColorBrush(Colors.DarkGreen);
            }
            if (captEnsoSerre.Text == "0")
            {
                VoyantEtatEnso.Fill = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                VoyantEtatEnso.Fill = new SolidColorBrush(Colors.DarkGreen);
            }
            if (captHumiSerre.Text == "0")
            {
                VoyantEtatHumi.Fill = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                VoyantEtatHumi.Fill = new SolidColorBrush(Colors.DarkGreen);
            }
            if (captVentSerre.Text == "0")
            {
                VoyantEtatVent.Fill = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                VoyantEtatVent.Fill = new SolidColorBrush(Colors.DarkGreen);
            }
            
        }*/








    }
         
}
