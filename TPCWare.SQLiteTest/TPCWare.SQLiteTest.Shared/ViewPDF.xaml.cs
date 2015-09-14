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
                 Uri targetUris = new Uri(@"http://www.pecollege.edu.za/index.php/2013-03-01-07-32-34/application-form1");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University Of Johannesburg"))
             {
                 Uri targetUris = new Uri(@"http://www.uj.ac.za/EN/StudyatUJ/StudentEnrolmentCentre/ApplicationProcess/Pages/home.aspx");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University Of Limpopo"))
             {
                 Uri targetUris = new Uri(@"http://www.ul.ac.za/index.php?Entity=Admission%20Requirements#");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of South Africa"))
             {
                 Uri targetUris = new Uri(@"http://www.unisa.ac.za/Default.asp?Cmd=ViewContent&ContentID=24624");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of Kwazulu Natal"))
             {
                 Uri targetUris = new Uri(@"http://applications.ukzn.ac.za/ApplicationProcedures/Undergraduate-Applicants/How-to-Apply-First-Time-Applicants.aspx");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of Mpumalanga"))
             {
                 Uri targetUris = new Uri(@"http://www.ump.ac.za/appform.html#.VdwyZvmqpBc");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of Stellenbosch"))
             {
                 Uri targetUris = new Uri(@"http://web-apps.sun.ac.za/eAansoek2/alg2.jsp");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of Venda"))
             {
                 Uri targetUris = new Uri(@"http://www.univen.ac.za/index.php?Entity=Student%20Info");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Nelson Mandela Metropolitan Univesity"))
             {
                 Uri targetUris = new Uri(@"http://www.nmmu.ac.za/Apply/Admission/How-do-I-apply");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Central JHB TVET College"))
             {

                 Uri targetUris = new Uri(@"http://www.cjc.edu.za/pre-enrolments-for-engineering-studies/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Sedibeng TVET College"))
             {
                 Uri targetUris = new Uri(@"http://www.sedcol.co.za/Home.aspx");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Tshwane North TVET College"))
             {
                 Uri targetUris = new Uri(@"http://www.tnc4fet.co.za/how-enrol-tnc");
                 webView1.Navigate(targetUris);
             }
            else if (part.Equals("CN Mahlangu"))
             {
                 MessageBox("No Application form for " + part + " you need to apply manual at the Campus. View campus location to see directions. In the mean time you can visit their website.");
                 Uri targetUris = new Uri(@"http://www.nkangalafet.edu.za/cn-mahlangu-campus-");
                 webView1.Navigate(targetUris);
             }

             else if (part.Equals("Sekhu-khune TVET College"))
             {

                 Uri targetUris = new Uri(@"http://www.sekfetcol.org/index.php?page=ncv-programmes-2");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Thekwini TVET College"))
             {

                 MessageBox("No Application form for " + part + " you need to apply manual at the Campus. View campus location to see directions. In the mean time you can visit their website.");
                 Uri targetUris = new Uri(@"http://www.thekwinicollege.co.za/");
                 webView1.Navigate(targetUris);

             }
             else if (part.Equals("False Bay TVET College"))
             {
                 Uri targetUris = new Uri(@"http://www.falsebaycollege.co.za/index.php?option=com_content&view=article&id=63&Itemid=194");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("South Cape TVET College"))
             {
                 MessageBox("No Application form for " + part + " you need to apply manual at the Campus. View campus location to see directions. In the mean time you can visit their website.");
                 Uri targetUris = new Uri(@"http://sccollege.co.za/index.php?p=1");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Buffalo City TVET College"))
             {
                 Uri targetUris = new Uri(@"http://www.bccollege.co.za/index.php?option=com_content&view=article&id=7&Itemid=6");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University Of Pretoria"))
             {
                 Uri targetUris = new Uri(@"http://www.up.ac.za/new-students-undergraduate/article/268803/laai-pdf-aansoekvorm-2016-af");
                 webView1.Navigate(targetUris);
             }
                 //////////////////////////////////new
                  else if (part.Equals("North West University"))
             {

                 Uri targetUris = new Uri(@"http://www.nwu.ac.za/content/vtc-academic-administration-admissions");
                 webView1.Navigate(targetUris);
             }

             else if (part.Equals("Cape Peninsula University of Technology"))
             {

                 Uri targetUris = new Uri(@"http://www.cput.ac.za/study/apply/step-2-get-an-application-form");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Walter Sisulu University"))
             {

               
                 Uri targetUris = new Uri(@"http://www.wsu.ac.za/waltersisulu/index.php/recruitment-2015/");
                 webView1.Navigate(targetUris);

             }
             else if (part.Equals("University of the Western Cape"))
             {
                 MessageBox("No Application form for " + part + " they prefer students to apply online.");
                 Uri targetUris = new Uri(@"https://www.uwc.ac.za/Students/Admin/Pages/Applications-Information.aspx");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Durban University of Technology"))
             {
                 MessageBox("No Application form for " + part + " you need to apply onlines.");
                 Uri targetUris = new Uri(@"http://www.dut.ac.za/student_portal/student_registration/how_to/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of Cape Town"))
             {
                 Uri targetUris = new Uri(@"http://www.uct.ac.za/apply/applications/forms/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("University of the Witwatersrand"))
             {
                 Uri targetUris = new Uri(@"http://www.wits.ac.za/prospective/postgraduate/11580/applications.html");
                 webView1.Navigate(targetUris);
             }
                   else if (part.Equals("Vaal University of Technology"))
             {
                 Uri targetUris = new Uri(@"http://www.vut.ac.za/index.php/admissions/undergraduate/how-do-i-apply");
                 webView1.Navigate(targetUris);
             }

             else if (part.Equals("Ikhala FET College"))
             {


                 Uri targetUris = new Uri(@"http://www.wsu.ac.za/waltersisulu/index.php/recruitment-2015/");
                 webView1.Navigate(targetUris);

             }
             else if (part.Equals("King Hintsa FET College"))
             {
                 MessageBox("No Application form for " + part + " they prefer students to apply online.");
                 Uri targetUris = new Uri(@"https://www.uwc.ac.za/Students/Admin/Pages/Applications-Information.aspx");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Goldfields FET College"))
             {
                 MessageBox("No Application form for " + part + " you need to apply onlines.");
                 Uri targetUris = new Uri(@"http://www.dut.ac.za/student_portal/student_registration/how_to/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Elangeni FET College"))
             {
                 Uri targetUris = new Uri(@"http://www.uct.ac.za/apply/applications/forms/");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Majuba FET College"))
             {
                 Uri targetUris = new Uri(@"http://www.wits.ac.za/prospective/postgraduate/11580/applications.html");
                 webView1.Navigate(targetUris);
             }
             else if (part.Equals("Letaba FET College"))
             {
                 Uri targetUris = new Uri(@"http://www.vut.ac.za/index.php/admissions/undergraduate/how-do-i-apply");
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
