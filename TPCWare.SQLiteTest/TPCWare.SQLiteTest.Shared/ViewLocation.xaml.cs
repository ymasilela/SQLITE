﻿using System;
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
        String part = "";
        public ViewLocation()
        {
            this.InitializeComponent();
           
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            part = e.Parameter as string;
          
            // Get users
            Uri targetUris = new Uri(@"https://www.google.co.za/maps/@-25.7759525,28.1377125,13z?hl=en");
            webView.Navigate(targetUris);

        }
 

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage),part);
        }
    }
}
+