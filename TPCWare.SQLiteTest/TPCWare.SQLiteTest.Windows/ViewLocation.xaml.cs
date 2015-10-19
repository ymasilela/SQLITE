using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TPCWare.SQLiteTest.Model;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;

using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TPCWare.SQLiteTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewLocation : Page
    {
       

        Campuses part = null;
        Campuses camp = null;
        public ViewLocation()
        {
            this.InitializeComponent();
            ShowRouteOnMap();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


           
        }
        public async void MessageBox(String message)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message);
            await dialog.ShowAsync();
        }
        private async void CheckDbAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var dbExist = false;
            if (App.conn != null)
                dbExist = true;
            string msg = "The database institutionFinder.db " + (dbExist ? "is present" : "is not present");

            MessageDialog dialog = new MessageDialog(msg);
            await dialog.ShowAsync();
        }
        private async void ShowRouteOnMap()
        {

         
            
           
        }

 

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), part.City);
        }

        private void tbOutputText_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GetDirections), part);
        }
       
    }
}
