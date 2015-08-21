using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TPCWare.SQLiteTest.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TPCWare.SQLiteTest;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TPCWare.SQLiteTest
{
    /// <summary>
    /// This is a demo app, with almost everithing inside this page code behind.
    /// A real app should use a MVVM (Model View ViewModel) approach
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Campuses> users { get; set; }
        private string item = string.Empty;
       
           Campuses newUser = new Campuses();
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            string part = e.Parameter as string;
            navigated.Text = part;
                // Get users

               SQLiteAsyncConnection connection = new SQLiteAsyncConnection("institutionFinder.db");
               users = await connection.QueryAsync<Campuses>("Select * FROM Campuses WHERE City ='" + part + "'");
                // Show users
                UserList.ItemsSource = users;


         
        }
           public async void MessageBox(String message)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message);
            await dialog.ShowAsync();
        }
        private async void CreateDbAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            
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

        private async void AddUserAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a random user
         
          
          
               // Add row to the User Table
               SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
               await conn.InsertAsync(newUser);

               // Add to the user list
               users.Add(newUser);

               // Refresh user list
               UserList.ItemsSource = null;
               UserList.ItemsSource = users;
           
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            var i = UserList.SelectedItems.ToArray();
            foreach (var it in i)
            {
                item = it.ToString();
            }
      
            MessageBox(item +"");
        }

        private async void DeleteUserAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (users != null && users.Count > 0)
            {
                // get last inserted user
                Campuses user = users.Last();

                // delete the row of the table
                // SQLite uses the User.Id to find witch row correspond to the user instance
                SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
                await conn.DeleteAsync(user);

                // delete the user from the user list
                users.RemoveAt(users.Count - 1);

                // Refresh user list
                UserList.ItemsSource = null;
                UserList.ItemsSource = users;
            }
            
        }

        #region SQLite utils




        public async Task<Campuses> SearchUniversities(string name)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("institutionFinder.db");
            var result = await connection.QueryAsync<Campuses>("Select * FROM Campuses WHERE Name ='" + name + "'");
            return result.SingleOrDefault();
        }
       
     
       

        private async Task UpdateUserNameAsync(string oldName, string newName)
        {
          
            // Retrieve user
            var user = await App.conn.Table<Campuses>().Where(x => x.Name == oldName).FirstOrDefaultAsync();
            if (user != null)
            {
                // Modify user
                user.Name = newName;

                // Update record
                await App.conn.UpdateAsync(user);
            }
        }

        private async Task DeleteUserAsync(string name)
        {
           
            // Retrieve user
            var user = await App.conn.Table<Campuses>().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (user != null)
            {
                // Delete record
                await App.conn.DeleteAsync(user);
            }
        }

        private async Task DropTableAsync(string name)
        {
            await App.conn.DropTableAsync<Campuses>();
        }

        #endregion SQLite utils

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Campuses seg = UserList.SelectedItem as Campuses;
            if (seg != null)
            {
                this.Frame.Navigate(typeof(ViewLocation),seg.Name);//TextBlock called bckChoiceSelected
            }
       }
           

        private void back_main_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchPage));

        }
    }

    public class IsolatedStorageFile
    {
    }
}
