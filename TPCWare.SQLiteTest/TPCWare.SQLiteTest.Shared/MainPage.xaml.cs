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
        public List<User> users { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
           

            // Get users
            var query = App.conn.Table<User>();
            users = await query.ToListAsync();

            // Show users
            UserList.ItemsSource = users;
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
            User newUser = new User()
            {
                // the Id will be set by SQlite
                Name = string.Format("User X (created at {0})", DateTime.Now),
                City = "Rome, Italy"
            };

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
            if (UserList.SelectedItems.Count > 0)
            {
                this.Frame.Navigate(typeof(Search));
            }
        }

        private async void DeleteUserAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (users != null && users.Count > 0)
            {
                // get last inserted user
                User user = users.Last();

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
     

  

        public async Task SearchUserByNameAsync(string name)
        {

           

            var allUsers = await App.conn.QueryAsync<User>("SELECT * FROM Users  "+ name) ;
            foreach (var user in allUsers)
            {
                // ...
            }

           var cityUsers = await App.conn.QueryAsync<User>(
                "SELECT Name FROM Users WHERE City = ?", new object[] { "Rome, Italy" });
            foreach (var user in cityUsers)
            {
                // ...
            }
            
        }

        private async Task UpdateUserNameAsync(string oldName, string newName)
        {
          
            // Retrieve user
            var user = await App.conn.Table<User>().Where(x => x.Name == oldName).FirstOrDefaultAsync();
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
            var user = await App.conn.Table<User>().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (user != null)
            {
                // Delete record
                await App.conn.DeleteAsync(user);
            }
        }

        private async Task DropTableAsync(string name)
        {
            await App.conn.DropTableAsync<User>();
        }

        #endregion SQLite utils

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (UserList.SelectedItems.Count > 0)
            {
                this.Frame.Navigate(typeof(ViewPage));
            }
        }
    }
}
