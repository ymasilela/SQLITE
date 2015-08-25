using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TPCWare.SQLiteTest.Model;
using TPCWare.SQLiteTest.ViewModels;
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
    public sealed partial class ViewPDF : Page
    {
        private CampusModels Model = null;
        public Campuses users { get; set; }
        string part = "";
        public ViewPDF()
        {
           
            
            this.InitializeComponent();
         
            
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

     
             part = e.Parameter as string;


             if (part.Equals("Tshwane University of Technology"))
             {

                 Uri targetUris = new Uri(@"http://www.tut.ac.za/enrol/apply/Pages/default.aspx");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Port Elizabeth TVET College"))
             {
                 Uri targetUris = new Uri(@"http://www.pecollege.edu.za/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University Of Johannesburg"))
             {
                 Uri targetUris = new Uri(@"http://www.uj.ac.za/EN/StudyatUJ/StudentEnrolmentCentre/ApplicationProcess/Pages/home.aspx");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University Of Limpopo"))
             {
                 Uri targetUris = new Uri(@"http://www.ul.ac.za/index.php?Entity=Admission%20Requirements");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of South Africa"))
             {
                 Uri targetUris = new Uri(@"http://www.unisa.ac.za/Default.asp?Cmd=ViewContent&ContentID=24624");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of Kwazulu Natal"))
             {
                 Uri targetUris = new Uri(@"http://applications.ukzn.ac.za/Homepage.aspx");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of Mpumalanga"))
             {
                 Uri targetUris = new Uri(@"http://www.ump.ac.za/appform.html#.VdwyZvmqpBc");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of Stellenbosch"))
             {
                 Uri targetUris = new Uri(@"http://www.sun.ac.za/english");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of Venda"))
             {
                 Uri targetUris = new Uri(@"http://www.univen.ac.za/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Nelson Mandela Metropolitan Univesity"))
             {
                 Uri targetUris = new Uri(@"http://www.nmmu.ac.za/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Central JHB TVET College"))
             {

                 Uri targetUris = new Uri(@"http://www.cjc.edu.za/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Sedibeng TVET College"))
             {
                 Uri targetUris = new Uri(@"http://www.sedcol.co.za/Home.aspx");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Tshwane North TVET College"))
             {
                 Uri targetUris = new Uri(@"http://www.tnc4fet.co.za/tshwane-north-tvet-college-overview");
                 webView1.Navigate(targetUris);
             }
            else if (part.Equals("CN Mahlangu"))
             {
                 Uri targetUris = new Uri(@"http://www.nkangalafet.edu.za/cn-mahlangu-campus-");
                 webView1.Navigate(targetUris);
             }

             else if (part.Equals("Sekhu-khune TVET College"))
             {

                 Uri targetUris = new Uri(@"http://www.sekfetcol.org/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Thekwini TVET College"))
             {
                 Uri targetUris = new Uri(@"http://www.thekwinicollege.co.za/#");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("False Bay TVET College"))
             {
                 Uri targetUris = new Uri(@"http://www.falsebaycollege.co.za/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("South Cape TVET College"))
             {
                 Uri targetUris = new Uri(@"http://sccollege.co.za/index.php?p=1");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Buffalo City TVET College"))
             {
                 Uri targetUris = new Uri(@"http://www.bccollege.co.za/index.php?option=com_content&view=article&id=19&Itemid=38");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University Of Pretoria"))
             {
                 Uri targetUris = new Uri(@"http://www.up.ac.za/");
                 webView1.Navigate(targetUris);
             }
             else
             {
                 MessageBox("No website for "+ part);
             }
     

        }
        public async void MessageBox(String message)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message);
            await dialog.ShowAsync();
        }

        private void back_web_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewPage),part);
        }

        private void webView1_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

    
    }
}
