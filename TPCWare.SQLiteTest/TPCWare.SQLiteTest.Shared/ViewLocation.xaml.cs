using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
        String part = "";
        public ViewLocation()
        {
            this.InitializeComponent();
            ShowRouteOnMap();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            part = e.Parameter as string;
          
            // Get users
            map.MapServiceToken = "yvPVkyiTloR2lug6UK3uVg";

            map.Center =
               new Geopoint(new BasicGeoposition()
               {
                   Latitude = 47.604,
                   Longitude = -122.329 
               });
            map.ZoomLevel = 15;
            map.LandmarksVisible = true;

            MapIcon MapIcon1 = new MapIcon();
            MapIcon1.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = 47.620,
                Longitude = -122.349
            });
            MapIcon1.NormalizedAnchorPoint = new Point(0,0);
            MapIcon1.Title = part;
            map.MapElements.Add(MapIcon1);

            MapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///ViewModels/map.jpg"));
        }
        private async void ShowRouteOnMap()
        {
            // Get a route as shown previously.
            BasicGeoposition startLocation = new BasicGeoposition();
            startLocation.Latitude = 47.643;
            startLocation.Longitude = -122.131;
            Geopoint startPoint = new Geopoint(startLocation);

            // End at the city of Seattle, Washington.
            BasicGeoposition endLocation = new BasicGeoposition();
            endLocation.Latitude = 47.604;
            endLocation.Longitude = -122.329;
            Geopoint endPoint = new Geopoint(endLocation);

            MapRouteFinderResult routeResult =
             await MapRouteFinder.GetDrivingRouteAsync(
             startPoint,
             endPoint,
             MapRouteOptimization.Time,
             MapRouteRestrictions.None);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                // Use the route to initialize a MapRouteView.
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.Yellow;
                viewOfRoute.OutlineColor = Colors.Black;

                // Add the new MapRouteView to the Routes collection
                // of the MapControl.
                map.Routes.Add(viewOfRoute);

                // Fit the MapControl to the route.
                await map.TrySetViewBoundsAsync(
                    routeResult.Route.BoundingBox,
                    null,
                    Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
            }
        }

 

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage),part);
        }

        private void tbOutputText_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GetDirections),part);
        }
       
    }
}
