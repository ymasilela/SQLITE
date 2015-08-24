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
    public sealed partial class SearchCollege : Page
    {
        public List<College> college { get; set; }
        College newColleges = new College();

        public SearchCollege()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            // Get users
            var query = App.conn.Table<College>();
            college = await query.ToListAsync();

            // Show users
            searchColleges.ItemsSource = college;


        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
            await conn.InsertAsync(newColleges);

            // Add to the user list
            college.Add(newColleges);

            // Refresh user list
            searchColleges.ItemsSource = null;
            searchColleges.ItemsSource = college;
        }
        public async void MessageBox(String message)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message);
            await dialog.ShowAsync();
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            College seg = searchColleges.SelectedItem as College;
            if (seg != null)
            {
                this.Frame.Navigate(typeof(ViewPage), seg.Name);

            }
        }

        private void back_main_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Search));
        }
    }
}
