using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public ViewLocation()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var myPosition = new Windows.Devices.Geolocation.BasicGeoposition();
            myPosition.Latitude = 41.7446;
            myPosition.Longitude = -087.7915;

            var myPoint = new Windows.Devices.Geolocation.Geopoint(myPosition);
            if (await map.TrySetViewAsync(myPoint, 10D))
            {
                // Haven't really thought that through!
            }

        }
    }
}
