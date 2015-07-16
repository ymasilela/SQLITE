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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TPCWare.SQLiteTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewPage : Page
    {
        public ViewPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewLocation));
        }

        private async void pdf_Click(object sender, RoutedEventArgs e)
        {
            // Access isolated storage.
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            // Access the PDF.
            StorageFile pdfFile = await local.GetFileAsync("D:/application.pdf");

            // Launch the bug query file.
           await Windows.System.Launcher.LaunchFileAsync(pdfFile);
           
        }


        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Uri targetUri = new Uri(@"http://www.tut.ac.za/enrol/apply/Documents");
           
        }

       
    }
}
