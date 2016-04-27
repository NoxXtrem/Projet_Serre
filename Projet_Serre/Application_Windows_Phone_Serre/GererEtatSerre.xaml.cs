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
        
        public GererEtatSerre()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void buttonEtat_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void buttonProfil_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GererProfils));
        }
        /*
        private void buttonChauffageON_Click(object sender, RoutedEventArgs e)
        {
            buttonChauffageON.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            buttonChauffageOFF.Background = new SolidColorBrush(Color.FromArgb(255,65,0,0));
        }

        private void buttonChauffageOFF_Click(object sender, RoutedEventArgs e)
        {
            buttonChauffageON.Background = new SolidColorBrush(Color.FromArgb(255, 0, 65, 0));
            buttonChauffageOFF.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }

        private void buttonArrosageON_Click(object sender, RoutedEventArgs e)
        {
            buttonArrosageON.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            buttonArrosageOFF.Background = new SolidColorBrush(Color.FromArgb(255, 65, 0, 0));
        }

        private void buttonArrosageOFF_Click(object sender, RoutedEventArgs e)
        {
            buttonArrosageON.Background = new SolidColorBrush(Color.FromArgb(255, 0, 65, 0));
            buttonArrosageOFF.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }

        private void buttonTrappeON_Click(object sender, RoutedEventArgs e)
        {
            buttonTrappeON.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            buttonTrappeOFF.Background = new SolidColorBrush(Color.FromArgb(255, 65, 0, 0));
        }

        private void buttonTrappeOFF_Click(object sender, RoutedEventArgs e)
        {
            buttonTrappeON.Background = new SolidColorBrush(Color.FromArgb(255, 0, 65, 0));
            buttonTrappeOFF.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }

        private void buttonExtracteurON_Click(object sender, RoutedEventArgs e)
        {
            buttonExtracteurON.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            buttonExtracteurOFF.Background = new SolidColorBrush(Color.FromArgb(255, 65, 0, 0));
        }

        private void buttonExtracteurOFF_Click(object sender, RoutedEventArgs e)
        {
            buttonExtracteurON.Background = new SolidColorBrush(Color.FromArgb(255, 0, 65, 0));
            buttonExtracteurOFF.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }
        */
        

    }
}
