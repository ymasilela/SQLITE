﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
        String part = "";
        public GetDirections()
        {
            this.InitializeComponent();
            GetRouteAndDirections();
          
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            part = e.Parameter as string;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewLocation),part);
        }

        private async void GetRouteAndDirections()
        {
            // Start at Microsoft in Redmond, Washington.
            BasicGeoposition startLocation = new BasicGeoposition();
            startLocation.Latitude = 47.643;
            startLocation.Longitude = -122.131;
            Geopoint startPoint = new Geopoint(startLocation);

            // End at the city of Seattle, Washington.
            BasicGeoposition endLocation = new BasicGeoposition();
            endLocation.Latitude = 47.604;
            endLocation.Longitude = -122.329;
            Geopoint endPoint = new Geopoint(endLocation);

            // Get the route between the points.
            MapRouteFinderResult routeResult =
                await MapRouteFinder.GetDrivingRouteAsync(
                startPoint,
                endPoint,
                MapRouteOptimization.Time,
                MapRouteRestrictions.None);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                // Display summary info about the route.
                tbOutputText.Inlines.Add(new Run()
                {
                    Text = "Total estimated time (minutes) = "
                        + routeResult.Route.EstimatedDuration.TotalMinutes.ToString()
                });
                tbOutputText.Inlines.Add(new LineBreak());
                tbOutputText.Inlines.Add(new Run()
                {
                    Text = "Total length (kilometers) = "
                        + (routeResult.Route.LengthInMeters / 1000).ToString()
                });
                tbOutputText.Inlines.Add(new LineBreak());
                tbOutputText.Inlines.Add(new LineBreak());

                // Display the directions.
                tbOutputText.Inlines.Add(new Run()
                {
                    Text = "DIRECTIONS"
                });
                tbOutputText.Inlines.Add(new LineBreak());

                foreach (MapRouteLeg leg in routeResult.Route.Legs)
                {
                    foreach (MapRouteManeuver maneuver in leg.Maneuvers)
                    {
                        tbOutputText.Inlines.Add(new Run()
                        {
                            Text = maneuver.InstructionText
                        });
                        tbOutputText.Inlines.Add(new LineBreak());
                    }
                }
            }
            else
            {
                tbOutputText.Text =
                    "A problem occurred: " + routeResult.Status.ToString();
            }

        }
        
    }
}