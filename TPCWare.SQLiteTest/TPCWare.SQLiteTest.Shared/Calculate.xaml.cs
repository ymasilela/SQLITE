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
    public sealed partial class Calculate : Page
    {
        String part = "";
        int aps = 22;
        Courses course = null;
      
        public Calculate()
        {
            this.InitializeComponent();

            
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {



            // Show users

            part = e.Parameter as string;
            heading.Text = part;


            cHome.Items.Add("IsiNdebele");
            cHome.Items.Add("English");
            cHome.Items.Add("AFRIKAANS (1ST LANGUAGE)");
            cHome.Items.Add("SESOTHO (FIRST LANGUAGE)");
            cHome.Items.Add("ZULU (1ST LANGUAGE)");
            cHome.Items.Add("XHOSA (1ST LANGUAGE)");
            cHome.Items.Add("VENDA (1ST LANGUAGE)");
            cHome.Items.Add("TSWANA (1ST LANGUAGE)");
            cHome.Items.Add("TSONGA (1ST LANGUAGE)");
            cHome.Items.Add("SWAZI (1ST LANGUAGE)");
            cHome.Items.Add("SEPEDI (FIRST LANGUAGE)");


            cFirst.Items.Add("IsiNdebele");
            cFirst.Items.Add("English");
            cFirst.Items.Add("AFRIKAANS (1ST LANGUAGE)");
            cFirst.Items.Add("SESOTHO (FIRST LANGUAGE)");
            cFirst.Items.Add("ZULU (1ST LANGUAGE)");
            cFirst.Items.Add("RUSSIAN");
            cFirst.Items.Add("PORTUGESE");
          
            cMaths.Items.Add("English");
            cMaths.Items.Add("IsiNdebele");
            cMaths.Items.Add("English");
            cMaths.Items.Add("IsiNdebele");
            cMaths.Items.Add("English");
            cMaths.Items.Add("English");
            cMaths.Items.Add("IsiNdebele");
            cMaths.Items.Add("English");
            cMaths.Items.Add("IsiNdebele");
            cMaths.Items.Add("English");

            cLifeO.Items.Add("English");
            cLifeO.Items.Add("IsiNdebele");
            cLifeO.Items.Add("English");
            cLifeO.Items.Add("IsiNdebele");
            cLifeO.Items.Add("English");
            cLifeO.Items.Add("English");
            cLifeO.Items.Add("IsiNdebele");
            cLifeO.Items.Add("English");
            cLifeO.Items.Add("IsiNdebele");
            cLifeO.Items.Add("English");

            cSubject5.Items.Add("ENGINEERING SCIENCE N4");
            cSubject5.Items.Add("ENVIRONMENTAL SCIENCE A SUBSID");
            cSubject5.Items.Add("English");
            cSubject5.Items.Add("IsiNdebele");
            cSubject5.Items.Add("English");
            cSubject5.Items.Add("English");
            cSubject5.Items.Add("IsiNdebele");
            cSubject5.Items.Add("English");
            cSubject5.Items.Add("IsiNdebele");
            cSubject5.Items.Add("English");
            cSubject5.Items.Add("English");
            cSubject5.Items.Add("IsiNdebele");
            cSubject5.Items.Add("English");
            cSubject5.Items.Add("IsiNdebele");
            cSubject5.Items.Add("English");

            cSubject6.Items.Add("COMPUTER SCIENCE");
            cSubject6.Items.Add("CIVIL TECHNOLOGY");
            cSubject6.Items.Add("CONCRETE STRUCTURE");
            cSubject6.Items.Add("BUSINESS AFRIKAANS N2");
            cSubject6.Items.Add("BOOKKEEPING AND COMMERCIAL ARC");
            cSubject6.Items.Add("APPLIED SCIENCE III");
            cSubject6.Items.Add("APPLIED PHYSIOLOGY");
            cSubject6.Items.Add("ANATOMY AND MUSIC");
            cSubject6.Items.Add("AIRCRAFT ELECTRICAL THEORY N3");
            cSubject6.Items.Add("2-D DESIGN N2");
            cSubject6.Items.Add("ABATTOIR HYGIENE N3");
            cSubject6.Items.Add("AFRIKAANSE LITERATURE");
            cSubject6.Items.Add("AGRICULTURAL SCIENCES");
            cSubject6.Items.Add("APPLIED GENTS' HAIRDRESSING N3");
            cSubject6.Items.Add("ART DESIGN");
           
         

        }
        public async void MessageBox(String message)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message);
            await dialog.ShowAsync();
        }

        private async void calculate_Click(object sender, RoutedEventArgs e)
        {
            
              
            
            try
            {
                if (string.IsNullOrWhiteSpace(txtHomeL.Text) || string.IsNullOrWhiteSpace(txtFirstEL.Text) || string.IsNullOrWhiteSpace(txtMaths.Text) || string.IsNullOrWhiteSpace(txtLifeO.Text) || string.IsNullOrWhiteSpace(txtSubject5.Text) || string.IsNullOrWhiteSpace(txtSubject6.Text))
            {
                MessageBox("Please fill all the fields with the required value");
                   
                }
          
                      
  
               else
               {
                   int homeL = Int32.Parse(txtHomeL.Text);
                   int fisrtL = Int32.Parse(txtFirstEL.Text);
                   int maths = Int32.Parse(txtMaths.Text);
                   int lifeO = Int32.Parse(txtLifeO.Text);
                   int subject5 = Int32.Parse(txtSubject5.Text);
                   int subject6 = Int32.Parse(txtSubject6.Text);

                   aps = homeL + fisrtL + maths + subject5 + subject6;


                   SQLiteAsyncConnection connection = new SQLiteAsyncConnection("institutionFinder.db");
                   var users = await connection.QueryAsync<Courses>("Select courses FROM Courses where Id = " + aps + "");

                   if (users != null)
                   {
                       foreach (var obj in users)
                       {
                           qualifyFor.Items.Add("Your APS is " + aps + " Excluding Life Orientation. You Qualify for " + obj.courses);
                       }
                   }
                   else
                   {
                       qualifyFor.Items.Add("You dont Qualify to study at" + part);
                   }

               }
            }catch(Exception ex)
            {
              
            }


            // Get users
           
           
           
          //  this.Frame.Navigate(typeof(QualifyCourses), aps);

        }

        private void backToViewPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewPage),part);
        }

        private void qualifyFor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
