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
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
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
       

        Campuses part = null;
        Campuses camp = null;
        public ViewLocation()
        {
            this.InitializeComponent();
            ShowRouteOnMap();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


           
            // Show users
           
          part = e.Parameter as Campuses;
          SQLiteAsyncConnection connection = new SQLiteAsyncConnection("institutionFinder.db");
          var users = await connection.QueryAsync<Campuses>("Select * FROM Campuses WHERE Name ='" + part.Name + "'");
            // Get users
          camp = users.FirstOrDefault();
        
            map.MapServiceToken = "yvPVkyiTloR2lug6UK3uVg";

            map.Center =
               new Geopoint(new BasicGeoposition()
               {
                   Latitude = camp.Latitude,
                   Longitude = camp.Longitude
               });
            map.ZoomLevel = 15;
            map.LandmarksVisible = true;

            MapIcon MapIcon1 = new MapIcon();
            MapIcon1.Location = new Geopoint(new BasicGeoposition()
            {

                Latitude = camp.Latitude,
                Longitude = camp.Longitude
            });
            MapIcon1.NormalizedAnchorPoint = new Point(10,10);
            MapIcon1.Title = camp.Name;
            map.MapElements.Add(MapIcon1);


            MapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///ViewModels/map.jpg"));
            Windows.UI.Xaml.Shapes.Ellipse fence = new Windows.UI.Xaml.Shapes.Ellipse();
           
            MapControl.SetNormalizedAnchorPoint(fence, new Point(0.5, 0.5));

            // Get a route as shown previously.
            BasicGeoposition startLocation = new BasicGeoposition();
            startLocation.Latitude = -25.73134;
            startLocation.Longitude = 28.21837;
            Geopoint startPoint = new Geopoint(startLocation);

            // End at the city of Seattle, Washington.
            BasicGeoposition endLocation = new BasicGeoposition();
            endLocation.Latitude = camp.Latitude;
            endLocation.Longitude = camp.Longitude;
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
