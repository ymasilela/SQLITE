using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TPCWare.SQLiteTest.Model;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;

using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TPCWare.SQLiteTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GetDirections : Page
    {
        Campuses part = null;
        public GetDirections()
        {
            this.InitializeComponent();
            GetRouteAndDirections();
          
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewLocation),part);
        }

        private async void GetRouteAndDirections()
        { 
            // Start at Microsoft in Redmond, Washington.
          
        }
        
    }
}
