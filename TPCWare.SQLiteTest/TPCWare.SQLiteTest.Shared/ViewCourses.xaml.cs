using SQLite;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TPCWare.SQLiteTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewCourses : Page
    {
        public List<Courses> users { get; set; }
        string part = "";
        public ViewCourses()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


             part = e.Parameter as string;
            label.Text = part;
            // Get users

            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("institutionFinder.db");
            users = await connection.QueryAsync<Courses>("Select * FROM Courses");
            // Show users
            viewcourses.ItemsSource = users;

        }
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewPage),part);
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewcourses.SelectedIndex >= -1)
            {
                viewcourses.IsEnabled = false;
            }
        }

        private void viewcourses_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
