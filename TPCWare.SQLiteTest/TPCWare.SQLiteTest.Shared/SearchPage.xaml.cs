using System;
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
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            String name;
           name = txtName.Text;
           if (name == "" | name == null)
           {
              
               MessageBox("Please enter valid search criteria");
           }
              
           
           else if (name.Equals("Tut") || name.Equals("Tshwane University of Technology") || name.Equals("tut") || name.Equals("TUT"))
            {
                this.Frame.Navigate(typeof(MainPage));
            }
           
            else
            {
                MessageBox("Not Registered");
            }
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

       
      
    }
}
