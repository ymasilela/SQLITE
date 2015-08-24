using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TPCWare.SQLiteTest.Model;
using TPCWare.SQLiteTest.ViewModels;
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
    public sealed partial class ViewPDF : Page
    {
        private CampusModels Model = null;
        public Campuses users { get; set; }
        string part = "";
        public ViewPDF()
        {
           
            
            this.InitializeComponent();
    
            
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            Model = new CampusModels();
             part = e.Parameter as string;
            
            // Get users
             Campuses c= Model.getAll("Soweto Campus");
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("institutionFinder.db");
          //  users = await connection.QueryAsync<Campuses>("Select WebsiteLink FROM Campuses WHERE Name = '" +part+ "'").Single();
           // users = await connection.QueryAsync<Campuses>("Select WebsiteLink FROM Campuses WHERE Name = '" + part + "'").FirstOrDefault();
            // Show users
     
         
           // Uri targetUri = new Uri("@" + users);
           // webView1.Navigate(targetUri);
            MessageBox(c.WebsiteLink + "");

        }
        public async void MessageBox(String message)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message);
            await dialog.ShowAsync();
        }

        private void back_web_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewPage),part);
        }

        private void webView1_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

    
    }
}
