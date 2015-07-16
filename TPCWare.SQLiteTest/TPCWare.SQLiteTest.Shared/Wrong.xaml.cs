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
    public sealed partial class Wrong : Page
    {
        public List<College> users { get; set; }

        public Wrong()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            // Get users
            var query = App.conn.Table<College>();
            users = await query.ToListAsync();

            // Show users
            UserLists.ItemsSource = users;
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
            College newUser = new College()
            {
                // the Id will be set by SQlite
                Name = string.Format("College X (created at {0})", DateTime.Now),
                
            };

            // Add row to the User Table
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
            await conn.InsertAsync(newUser);

            // Add to the user list
            users.Add(newUser);

            // Refresh user list
            UserLists.ItemsSource = null;
            UserLists.ItemsSource = users;
        }

        private async void DeleteUserAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (users != null && users.Count > 0)
            {
                // get last inserted user
                College user = users.Last();

                // delete the row of the table
                // SQLite uses the User.Id to find witch row correspond to the user instance
                SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
                await conn.DeleteAsync(user);

                // delete the user from the user list
                users.RemoveAt(users.Count - 1);

                // Refresh user list
                UserLists.ItemsSource = null;
                UserLists.ItemsSource = users;
            }

        }

        #region SQLite utils




        private async Task SearchUserByNameAsync(string name)
        {

            var query = App.conn.Table<College>().Where(x => x.Name.Contains(name));
            var result = await query.ToListAsync();
            foreach (var item in result)
            {
                // ...
            }

            var allUsers = await App.conn.QueryAsync<College>("SELECT * FROM Colleges");
            foreach (var user in allUsers)
            {
                // ...
            }

           
        }

        private async Task UpdateUserNameAsync(string oldName, string newName)
        {

            // Retrieve user
            var user = await App.conn.Table<College>().Where(x => x.Name == oldName).FirstOrDefaultAsync();
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
            var user = await App.conn.Table<College>().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (user != null)
            {
                // Delete record
                await App.conn.DeleteAsync(user);
            }
        }

        private async Task DropTableAsync(string name)
        {
            await App.conn.DropTableAsync<College>();
        }

        #endregion SQLite utils
    }
}
