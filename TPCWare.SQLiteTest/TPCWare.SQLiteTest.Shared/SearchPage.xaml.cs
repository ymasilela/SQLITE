using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TPCWare.SQLiteTest.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TPCWare.SQLiteTest.ViewModels;
using SQLite;
using Windows.UI.Popups;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TPCWare.SQLiteTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public List<Universities> users { get; set; }

        Universities newUser = new Universities();

     
      
        public SearchPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            // Get users
            var query = App.conn.Table<Universities>();
            users = await query.ToListAsync();

            // Show users
            searchViewList.ItemsSource = users;
        

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            // Add row to the User Table
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
            await conn.InsertAsync(newUser);

            // Add to the user list
            users.Add(newUser);

            // Refresh user list
            searchViewList.ItemsSource = null;
            searchViewList.ItemsSource = users;
           
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

        public async void MessageBox(String message)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message);
            await dialog.ShowAsync();
        }

        private void back_se_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Search));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchViewList.SelectedItems.Count > 0)
            {
               string name = "TUT";
                //this.Frame.Navigate(typeof(MainPage));
                Universities uni = new Universities();
                var sel = searchViewList.SelectedItems.Cast<Object>().ToArray();
                string[] applianceNames = {""};
               

                for (int i = 0; i < sel.Count(); i++)
                {
                    string Name = "";

                    if (searchViewList.SelectedItems.Count == 0)
                    {
                        Name = "Tshwane University of Technology";

                    }
                    else if (searchViewList.SelectedItems.Count == 1)
                    {
                        Name = "University Of Johannesburg";

                    }
                    else if (searchViewList.SelectedItems.Count == 2)
                    {
                        Name = "University Of Pretoria";

                    }
                    else if (searchViewList.SelectedItems.Count == 3)
                    {
                        Name = "University Of Limpopo";

                    }
                    else if (searchViewList.SelectedItems.Count == 4)
                    {
                        Name = "University of South Africa";

                    }
                    else if (searchViewList.SelectedItems.Count == 5)
                    {
                        Name = "University of Kwazulu Natal";

                    }
                    else if (searchViewList.SelectedItems.Count == 6)
                    {
                        Name = "University of Stellenbosch";

                    }
                    else if (searchViewList.SelectedItems.Count == 7)
                    {
                        Name = "University of Mpumalanga";
                    }
                    else if (searchViewList.SelectedItems.Count == 8)
                    {
                        Name = "University of Venda";

                    }
                    else
                    {
                        Name = "Nelson Mandela Metropolitan Univesity";

                    }
                    MessageBox(Name + "");
                }
           
            }
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Name = "";
          
                if (searchViewList.SelectedItems.Count == 0)
                {
                    Name = "Tshwane University of Technology";

                }
                else if (searchViewList.SelectedItems.Count == 1)
                {
                    Name = "University Of Johannesburg";

                }
                else if (searchViewList.SelectedItems.Count == 2)
                {
                    Name = "University Of Pretoria";

                }
                else if (searchViewList.SelectedItems.Count == 3)
                {
                    Name = "University Of Limpopo";

                }
                else if (searchViewList.SelectedItems.Count == 4)
                {
                    Name = "University of South Africa";

                }
                else if (searchViewList.SelectedItems.Count == 5)
                {
                    Name = "University of Kwazulu Natal";

                }
                else if (searchViewList.SelectedItems.Count == 6)
                {
                    Name = "University of Stellenbosch";

                }
                else if (searchViewList.SelectedItems.Count == 7)
                {
                    Name = "University of Mpumalanga";
                }
                else if (searchViewList.SelectedItems.Count == 8)
                {
                    Name = "University of Venda";

                }
                else
                {
                    Name = "Nelson Mandela Metropolitan Univesity";

                }
            

            this.Frame.Navigate(typeof(MainPage), Name);
           
        }

       
      
    }
}
