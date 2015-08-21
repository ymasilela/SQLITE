using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TPCWare.SQLiteTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewPage : Page
    {
        string part;
        public ViewPage()
        {
            this.InitializeComponent();

           
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


             part = e.Parameter as string;
            campName.Text = part;
            // Get users
         

                   



        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string name = part;
            this.Frame.Navigate(typeof(ViewLocation),part);
        }


        private async void pdf_Click(object sender, RoutedEventArgs e)
        {
            // Access isolated storage.
            string name = part;
            this.Frame.Navigate(typeof(ViewPDF),part);
          
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewCourses));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        
            
            this.Frame.Navigate(typeof(SearchPage));
        }

     

        

       
       
       
    }
}
