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
    public sealed partial class QualifyCourses : Page
    {
        String aps = "";
       Courses course = null;
        public QualifyCourses()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {



            // Show users

            aps = e.Parameter as string;
           

            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("institutionFinder.db");
            var users = await connection.QueryAsync<Courses>("Select courses FROM Courses where Id = " + 21 + "");
            // Get users
            course = users.SingleOrDefault();

            qCourses.Text = "You Qualify for " + course.courses;

        }

        private void backToViewPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Calculate), aps);
        }
    }
}
