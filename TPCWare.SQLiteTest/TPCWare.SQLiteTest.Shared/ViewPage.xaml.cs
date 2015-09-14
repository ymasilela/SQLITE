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
        String selection = "";
   
        public ViewPage()
        {
            this.InitializeComponent();

           
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


             part = e.Parameter as string;

            
             campName.Text = part;


             if (part.Equals("Tshwane University of Technology"))
             {

                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/tut.jpg"));
             }
             else if (part.Equals("Port Elizabeth TVET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/Port-Elizabeth.jpg"));
             }
             else if (part.Equals("University Of Johannesburg"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/uj.jpg"));
             }
             else if (part.Equals("University Of Limpopo"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/UL.jpg"));
             }
             else if (part.Equals("University of South Africa"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/Unisa.png"));
             }
             else if (part.Equals("University of Kwazulu Natal"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/UKZN.jpg"));
             }
             else if (part.Equals("University of Mpumalanga"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/UM.jpg"));
             }
             else if (part.Equals("University of Stellenbosch"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/US.jpg"));
             }
             else if (part.Equals("University of Venda"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/UV.jpg"));
             }
             else if (part.Equals("Nelson Mandela Metropolitan Univesity"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/nmmu.jpg"));
             }
             else if (part.Equals("Central JHB TVET College"))
             {

                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/central.jpg"));
             }
             else if (part.Equals("Sedibeng TVET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/sedibeng.jpg"));
             }
             else if (part.Equals("Tshwane North TVET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/tnc.jpg"));
             }
             else if (part.Equals("CN Mahlangu"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/Nkangala-FET-College.jpg"));
             }

             else if (part.Equals("Sekhu-khune TVET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/sekhukhune.jpg"));
             }
             else if (part.Equals("Thekwini TVET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/Thekwini-FET-College.jpg"));

             }
             else if (part.Equals("False Bay TVET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/False.png"));
             }
             else if (part.Equals("South Cape TVET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/south-Cape.jpg"));
             }
             else if (part.Equals("Buffalo City TVET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/buffalo.jpg"));
             }
             else if (part.Equals("University Of Pretoria"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/UP.jpg"));
             }

             else if (part.Equals("North West University"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/unw.jpg"));
             }


             else if (part.Equals("University of the Witwatersrand"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/wits.png"));

             }
             else if (part.Equals("University of Cape Town"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/uct.jpg"));
             }
             else if (part.Equals("Durban University of Technology"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/dut.png"));
             }
             else if (part.Equals("University of the Western Cape"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/uwc.jpg"));
             }
             else if (part.Equals("Walter Sisulu University"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/Walter-Sisulu.jpg"));
             }
             else if (part.Equals("Cape Peninsula University of Technology"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/cape.jpg"));
             }
             else if (part.Equals("Sol Plaatje University"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/sol.jpg"));
             }
             else if (part.Equals("Vaal University of Technology"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/vaal.png"));
             }
            /////////////////new
             else if (part.Equals("Ikhala FET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/Ikhala.jpeg"));
             }
             else if (part.Equals("King Hintsa FET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/king.jpg"));
             }
             else if (part.Equals("Goldfields FET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/Gold-Fields-FET-College.jpg"));
             }
             else if (part.Equals("Elangeni FET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/Elangeni-College.jpg"));
             }
             else if (part.Equals("Majuba FET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/majuba.jpeg"));
             }
             else if (part.Equals("Letaba FET College"))
             {
                 images.Source = new BitmapImage(new Uri("ms-appx:///ViewModels/pic.jpg"));
             }
            
            
           
     

       
            // Get users

          
                   



        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string name = part;
            this.Frame.Navigate(typeof(MainPage),part);
        }


        private async void pdf_Click(object sender, RoutedEventArgs e)
        {
            // Access isolated storage.
            string name = part;
            this.Frame.Navigate(typeof(ViewPDF),part);
          
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = part;
            this.Frame.Navigate(typeof(ViewCourses),part);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

          
                this.Frame.Navigate(typeof(SearchPage));
          
            
        
        }

        private void colleges_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchCollege));
        }

     

        

       
       
       
    }
}
