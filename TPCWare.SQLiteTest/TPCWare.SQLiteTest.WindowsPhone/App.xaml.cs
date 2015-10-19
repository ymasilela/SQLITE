using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TPCWare.SQLiteTest.Model;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace TPCWare.SQLiteTest
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        public string DBPath { get; set; }
#if WINDOWS_PHONE_APP
        private TransitionCollection transitions;
#endif

        public static SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
    


        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            DBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "institutionFinder.db");
            // Create Db if not exist
            bool dbExist = await CheckDbAsync("institutionFinder.db");
            if (!dbExist)
            {
                await CreateDatabaseAsync();
                await AddUniversitiesAsync();
                await AddUsersAsync();
                await AddCoursesAsync();             
                await AddCollegeAsync();
             
            }
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
#if WINDOWS_PHONE_APP
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;
#endif

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(Search), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

#if WINDOWS_PHONE_APP
        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        /// <param name="sender">The object where the handler is attached.</param>
        /// <param name="e">Details about the navigation event.</param>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }
#endif

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }
        
        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
            await conn.CreateTableAsync<Campuses>();
            await conn.CreateTableAsync<Courses>();
            await conn.CreateTableAsync<College>();
            await conn.CreateTableAsync<Universities>();
        }
      
        private async Task AddUsersAsync()
        {
            // Create a users list
            var CampusesList = new List<Campuses>()
            {
                new Campuses()
                {

            
                    City = "Tshwane University of Technology",
                    Name = "Soshanguve South Campus",
                    WebsiteLink = "www.tut.ac.za",
                    Latitude = -25.540486,
                    Longitude = 28.096136
                    
                },
                new Campuses()
                {
                    City = "Tshwane University of Technology",
                    Name = "Soshanguve North Campus",
                   WebsiteLink = "www.tut.ac.za",
                    Latitude = -25.540486,
                    Longitude = 28.096136
                },
                new Campuses()
                {
                    City = "Tshwane University of Technology",
                    Name = "Pretoria Campus",
                    WebsiteLink = "www.tut.ac.za",
                      Latitude = -25.732208,
                    Longitude = 28.161872
                },
                 new Campuses()
                {
                    City = "Tshwane University of Technology",
                    Name = "Malahleni Campus",
                    WebsiteLink = "www.tut.ac.za",
                     Latitude = -25.8777006,
                    Longitude = 29.2365414
                },
                 new Campuses()
                {
                    City = "Tshwane University of Technology",
                    Name = "Nelspruit Campus",
                    WebsiteLink = "www.tut.ac.za",
                     Latitude = -25.540486,
                    Longitude = 28.096136
                },
                 new Campuses()
                {
                    City = "Tshwane University of Technology",
                    Name = "Ga-Rankuwa Campus",
                    WebsiteLink = "www.tut.ac.za",
                     Latitude =  32.165622,
                    Longitude =  -82.900075
                },
                 new Campuses()
                {
                    City = "University Of Johannesburg",
                    Name = "Bunting Road Campus",
                    WebsiteLink = "www.uj.ac.za",
                     Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    //TNC
                 new Campuses()
            
                {
                    City = "University Of Johannesburg",
                    Name = "Soweto Campus",
                    WebsiteLink = "www.uj.ac.za",
                     Latitude =-26.26078,
                    Longitude = 27.92357 
                },
                 new Campuses()
                {
                    City = "University Of Johannesburg",
                    Name = "Auckland Park Campus ",
                    WebsiteLink = "www.uj.ac.za",
                     Latitude = -26.183590,
                    Longitude = 27.997681
                },
                 new Campuses()
                {
                   City = "Port Elizabeth TVET College",
                    Name = "Mthatha Campus",
                    WebsiteLink = "www.tnc.ac.za",
                     Latitude = -33.962005,
                    Longitude = 25.610333
                },
                 new Campuses()
                {
                    City = "Port Elizabeth TVET College",
                    Name = "Dower Campus ",
                    WebsiteLink = "www.rosebank.ac.za",
                     Latitude = -33.962005,
                    Longitude = 25.610333
                },
                  new Campuses()
                {
                    City = "University Of Limpopo",
                    Name = "Polokwane campus",
                    WebsiteLink = "www.ul.ac.za",
                     Latitude = -23.90877,
                    Longitude =  29.45807
                },
                   new Campuses()
                {
                    City = "University Of Limpopo",
                    Name = "Medunsa campus",
                    WebsiteLink = "www.ul.ac.za",
                     Latitude = -25.540486,
                    Longitude = 28.096136
                },





                 new Campuses()
                {
                    City = "University Of Pretoria",
                    Name = "Onderstepoort Campus",
                    WebsiteLink = "www.tut.ac.za" ,
                     Latitude = -25.7545492,
                    Longitude = 28.2314476
                },
                new Campuses()
                {
                    City = "University Of Pretoria",
                    Name = "Groenkloof Campus",
                   WebsiteLink = "www.tut.ac.za",
                       Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                {
                    City = "University Of Pretoria",
                    Name = "Prinshof Campus",
                    WebsiteLink = "www.tut.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "University of South Africa",
                    Name = "Middelburg Campus",
                    WebsiteLink = "www.tut.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "University of South Africa",
                    Name = "Pretoria Campus",
                    WebsiteLink = "www.tut.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "University of South Africa",
                    Name = " Muckleneuk Campus ",
                    WebsiteLink = "www.tut.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses() 
                {
                    City = "University of Kwazulu Natal",
                    Name = "Durban Campus",
                    WebsiteLink = "www.uj.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    //TNC
                 new Campuses()
            
                {
                    City = "University of Kwazulu Natal",
                    Name = "Pietermaritzburg Campus",
                    WebsiteLink = "www.uj.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "University of Kwazulu Natal",
                    Name = "Westville Campus",
                    WebsiteLink = "www.uj.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                   City = "University of Stellenbosch",
                    Name = "Tygerberg Campus",
                    WebsiteLink = "www.tnc.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "University of Stellenbosch",
                    Name = "Saldanha Bay campus",
                    WebsiteLink = "www.rosebank.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                  new Campuses()
                {
                    City = "University of Stellenbosch",
                    Name = "Bellville campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                   new Campuses()
                {
                    City = "University of Venda",
                    Name = "Russell Road campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                   new Campuses()
                {
                    City = "University of Venda",
                    Name = "Thohoyandou Campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                {
                    City = "University of Venda",
                    Name = "Thohoyandou Campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },





                 new Campuses()
                {
                    City = "Tshwane North TVET College",
                    Name = "Soshanguve South Campus",
                    WebsiteLink = "www.tut.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                    
                },
                new Campuses()
                {
                    City = "Tshwane North TVET College",
                    Name = "Soshanguve North Campus",
                   WebsiteLink = "www.tut.ac.za",
                       Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                {
                    City = "Tshwane North TVET College",
                    Name = "Pretoria Campus",
                    WebsiteLink = "www.tut.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "Central JHB TVET College",
                    Name = "Ellis Park Campus",
                    WebsiteLink = "www.tut.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "Central JHB TVET College",
                    Name = "Alexandra Campus",
                    WebsiteLink = "www.tut.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "Central JHB TVET College",
                    Name = "Parktown Campus",
                    WebsiteLink = "www.tut.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "Sedibeng TVET College",
                    Name = "Heidelberg Satelite  Campus",
                    WebsiteLink = "www.uj.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    //TNC
                 new Campuses()
            
                {
                    City = "Sedibeng TVET College",
                    Name = "Vereeniging Campus",
                    WebsiteLink = "www.uj.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "Sedibeng TVET College",
                    Name = "Sebokeng Campus",
                    WebsiteLink = "www.uj.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                   City = "CN Mahlangu",
                    Name = "Nkangala Campus",
                    WebsiteLink = "www.tnc.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                {
                    City = "CN Mahlangu",
                    Name = "Siysbuswa campus",
                    WebsiteLink = "www.rosebank.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                  new Campuses()
                {
                    City = "CN Mahlangu",
                    Name = "Middleburg campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                   new Campuses()
                {
                    City = "False Bay TVET College",
                    Name = "Muizenberg campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                   new Campuses()
                {
                    City = "False Bay TVET College",
                    Name = "Khayelitsha  Campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                      new Campuses()
                {
                    City = "False Bay TVET College",
                    Name = "Mitchell’s Plain  Campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                {
                    City = "South Cape TVET College",
                    Name = "George Campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                  new Campuses()
                {
                    City = "South Cape TVET College",
                    Name = "Bitou Campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                   new Campuses()
                {
                    City = "South Cape TVET College",
                    Name = "Mossel Bay Campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                   new Campuses()
                {
                    City = "Buffalo City TVET College",
                    Name = "Southeast Technical College Campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                     new Campuses()
                {
                    City = "Buffalo City TVET College",
                    Name = "St Teresa Campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                {
                    City = "Buffalo City TVET College",
                    Name = "Luther College Rochester Campus",
                    WebsiteLink = "www.ul.ac.za",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },



               //////////////////////////new

                     new Campuses()
                  {
                  
                    City = "North West University",
                    Name = "Mafikeng Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                
                },
                new Campuses()
                  {
                  
                    City = "University of the Witwatersrand",
                    Name = "West Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                
                },
                new Campuses()
             {
                  
                    City = "University of Cape Town",
                    Name = "Breakwater Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                
                },
                  new Campuses()
                {
                    
                    City = "Durban University of Technology",
                Name = "ML Sultan Campus",
                    Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                  {
                  
                    City = "University of the Western Cape",
                Name = "Bellville Campus",
                    Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                  {
                  
                    City = "Walter Sisulu University",
                Name = "Mthatha campus",
                    Latitude = -26.1892543,
                    Longitude = 28.0132699
                },

                 new Campuses()
                  {
                  
                    City = "Cape Peninsula University of Technology",
                    Name = "Cape Town Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                  {
                  
                    City = "Vaal University of Technology",
                    Name = "Vanderbijlpark Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
             {
                  
                    City = "Sol Plaatje University",
                    Name = "Luther College Rochester Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },


                 //////////////////////////new

                     new Campuses()
                  {
                  
                    City = "North West University",
                    Name = "Potchefstroom Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                  {
                  
                    City = "University of the Witwatersrand",
                    Name = "East Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
             {
                  
                    City = "University of Cape Town",
                    Name = "Hiddingh Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                  new Campuses()
                {
                    
                    City = "Durban University of Technology",
                    Name = "Steve Biko Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                  {
                  
                    City = "University of the Western Cape",
                    Name = "Tygerberg Hospital Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                  {
                  
                    City = "Walter Sisulu University",
                    Name = "Butterworth campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },

                 new Campuses()
                  {
                  
                    City = "Cape Peninsula University of Technology",
                    Name = "Granger Bay Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                  {
                  
                    City = "Vaal University of Technology",
                    Name = "Secunda Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
             {
                  
                    City = "Sol Plaatje University",
                    Name = "Mossel Bay Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                

                 //////////////////////////new

                     new Campuses()
                  {
                  
                    City = "North West University",
                    Name = "Vaal Triangle Campus",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                  {
                  
                    City = "University of the Witwatersrand",
                     Name = "Parktown Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
             {
                  
                    City = "University of Cape Town",
                     Name = "Medical Groote Schuur Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                  new Campuses()
                {
                    
                    City = "Durban University of Technology",
                     Name = "Brickfield Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                 new Campuses()
                  {
                  
                    City = "University of the Western Cape",
                     Name = "Mitchell’s Plain Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                  {
                  
                    City = "Walter Sisulu University",
                     Name = "Buffalo City campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },

                 new Campuses()
                  {
                  
                    City = "Cape Peninsula University of Technology",
                     Name = "Mowbray Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                  {
                  
                    City = "Cape Peninsula University of Technology",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                new Campuses()
                  {
                  
                    City = "Sol Plaatje University",
                     Name = "Kimberley",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
             
                 ///////////////////new

                  new Campuses()
                {
                     
                    City = "Ikhala FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                   
                    City = "King Hintsa FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                   
                    City = "Goldfields FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
              
                    new Campuses()
                {
                   
                    City = "Elangeni FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                    Name = "Bellville Campus",
                    City = "Majuba FET College",
                        Latitude = -26.1892543,
                    Longitude = 28.0132699
                
                },
                    new Campuses()
                {
                   
                    City = "Letaba FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },

                  ///////////////////new

                  new Campuses()
                {
                     
                    City = "Ikhala FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                   
                    City = "King Hintsa FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                   
                    City = "Goldfields FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
              
                    new Campuses()
                {
                   
                    City = "Elangeni FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                   
                    City = "Majuba FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                   
                    City = "Letaba FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },

                  ///////////////////new

                  new Campuses()
                {
                     
                    City = "Ikhala FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                   
                    City = "King Hintsa FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                   
                    City = "Goldfields FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
              
                    new Campuses()
                {
                   
                    City = "Elangeni FET College",
                     Name = "Bellville Campus" ,   
                     Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                   
                    City = "Majuba FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },
                    new Campuses()
                {
                   
                    City = "Letaba FET College",
                     Name = "Bellville Campus",
                         Latitude = -26.1892543,
                    Longitude = 28.0132699
                },



            };



            // Add rows to the User Table
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
            await conn.InsertAllAsync(CampusesList);
        }
        private async Task AddCoursesAsync()
        {
            // Create a users list
            var userList = new List<Courses>()
            {
                new Courses()
                {
                    Id = 21,
                    courses = "IT",
                    
                },
                new Courses()
                {
                    Id = 24,
                    courses = "International Law and Global Justice - LLM",
                   
                },
                  new Courses()
                {
                    Id = 20,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 19,
                    courses = "Legal Practice - MA",
                
                },
                 new Courses()
                {
                    Id = 20,
                    courses = "Translation Studies - MA",
                
                },
                 new Courses()
                {
                    Id = 18,
                    courses = "Political Theory - MA",
                   
                },
                new Courses()
                {
                    Id = 22,
                    courses = "English Studies (online) - MA (distance learning)",
                
                },
                 new Courses()
                {
                    Id = 28,
                    courses = "Ethnomusicology - MA",
                
                },
                 new Courses()
                {
                    Id = 21,
                    courses = "Creative Writing - MA",
                   
                },
                new Courses()
                {
                    Id = 29,
                    courses = "Translational Neuroscience - MSc",
                
                },
                 new Courses()
                {
                    Id = 30,
                    courses = "Periodontics - DClinDent",
                
                },
                 new Courses()
                {
                    Id = 25,
                    courses = "Health Economics and Decision Modelling - MSc",
                   
                },
                new Courses()
                {
                    Id = 19,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 15,
                    courses = "Dental Technology - MSc",
                
                },
                    new Courses()
                {
                    Id = 18,
                    courses = "Dementia Studies - MA",
                   
                },
                new Courses()
                {
                    Id = 25,
                    courses = "Cancer Care - PG Cert",
                
                },
                 new Courses()
                {
                    Id = 22,
                    courses = "Data Communications - MSc(Eng)",
                
                },
                    new Courses()
                {
                    Id = 31,
                    courses = "Civil Engineering – MSc",
                   
                },
                new Courses()
                {
                    Id = 26,
                    courses = "Dental Materials Science - MSc",
                
                },
                 new Courses()
                {
                    Id = 30,
                    courses = "Advanced Mechanical Engineering - MSc(Res)",
                
                },
                    new Courses()
                {
                    Id = 31,
                    courses = "Architectural Engineering Design - MSc(Eng)",
                   
                },
                new Courses()
                {
                    Id = 22,
                    courses = "Finance - MSc",
                
                },
                 new Courses()
                {
                    Id = 21,
                    courses = "Marketing Management Practice - MSc",
                
                },
                    new Courses()
                {
                    Id = 20,
                    courses = "Leadership and Management - MSc",
                   
                },
                new Courses()
                {
                    Id = 26,
                    courses = "Political Communication",
                
                },
                 new Courses()
                {
                    Id = 26,
                    courses = "Department of Geography, Faculty of Social Sciences",
                
                },
                    new Courses()
                {
                    Id = 17,
                    courses = "School of Languages and Cultures, Faculty of Arts and Humanities",
                   
                },
                new Courses()
                {
                    Id = 20,
                    courses = "Information Management",
                
                },
                 new Courses()
                {
                    Id = 16,
                    courses = "Human Resource Management",
                
                },
                    new Courses()
                {
                    Id = 20,
                    courses = "Global Journalism ",
                   
                },
                new Courses()
                {
                    Id = 21,
                    courses = "Financial Economics ",
                
                },
                 new Courses()
                {
                    Id = 28,
                    courses = "Educational Studies ",
                
                },
                    new Courses()
                {
                    Id = 28,
                    courses = "Education ",
                   
                },
                new Courses()
                {
                    Id = 26,
                    courses = "Creative Writing",
                
                },
                 new Courses()
                {
                    Id = 21,
                    courses = "Computer Science, Advanced (Enterprise Computing)",
                
                },
                    new Courses()
                {
                    Id = 24,
                    courses = "Business Administration",
                   
                },
                new Courses()
                {
                    Id = 30,
                    courses = "Quantity Survey Engineering",
                
                },
                 new Courses()
                {
                    Id = 19,
                    courses = "Applied Linguistics with TESOL - MA/Diploma",
                
                },
                    new Courses()
                {
                    Id = 26,
                    courses = "Advanced Software Engineering - MSc(Eng)",
                   
                },
                new Courses()
                {
                    Id = 25,
                    courses = "Utility Lineworker Technology",
                
                },
                 new Courses()
                {
                    Id = 17,
                    courses = "Health Care Assistant",
                
                },
                    new Courses()
                {
                    Id = 16,
                    courses = "Commercial Truck Driving",
                   
                },
                new Courses()
                {
                    Id = 24,
                    courses = "Business & Marketing Management",
                
                },
                 new Courses()
                {
                    Id = 23,
                    courses = "Automation & Control",
                
                }

            };



            // Add rows to the User Table
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
            await conn.InsertAllAsync(userList);
        }
        private async Task AddCollegeAsync()
        {
            // Create a users list
            var CollegeLists = new List<College>()
            {
                new College()
                {
                   
                    Name = "Port Elizabeth TVET College",
                    
                },
                new College()
                {
                     
                    Name = "Central JHB TVET College",
                   
                },
                new College()
                {
                    
                    Name = "Sedibeng TVET College",
                
                },
             
                 new College()
                {
                   
                    Name = "Tshwane North TVET College",
                
                },
                   new College()
                {
                     
                    Name = "CN Mahlangu",
                
                },
                    new College()
                {
                   
                    Name = "Sekhu-khune TVET College",
                
                },
                    new College()
                {
                   
                    Name = "Thekwini TVET College",
                
                },
              
                    new College()
                {
                   
                    Name = "False Bay TVET College",
                
                },
                    new College()
                {
                   
                    Name = "South Cape TVET College",
                
                },
                    new College()
                {
                   
                    Name = "Buffalo City TVET College",
                
                },
                ///////////////////new

                  new College()
                {
                     
                    Name = "Ikhala FET College",
                
                },
                    new College()
                {
                   
                    Name = "King Hintsa FET College",
                
                },
                    new College()
                {
                   
                    Name = "Goldfields FET College",
                
                },
              
                    new College()
                {
                   
                    Name = "Elangeni FET College",
                
                },
                    new College()
                {
                   
                    Name = "Majuba FET College",
                
                },
                    new College()
                {
                   
                    Name = "Letaba FET College",
                
                },
                 
            };

            // Add rows to the User Table
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
            await conn.InsertAllAsync(CollegeLists);
        }

        private async Task AddUniversitiesAsync()
        {
            // Create a Universities list
            var universitiesLists = new List<Universities>()
            {
                new Universities()
                {
                    
                    Name = "Tshwane University of Technology",

                    
                },
                new Universities()
                {
                     
                    Name = "University Of Johannesburg",
                   
                },
                new Universities()
                {
                    
                    Name = "University Of Pretoria",
                
                },
                  new Universities()
                {
                  
                    Name = "University Of Limpopo",
                
                },
                      new Universities()
                {
                  
                    Name = "University of South Africa",
                
                },
                      new Universities()
                {
                  
                    Name = "University of Kwazulu Natal",
                
                },
                new Universities()
                  {
                  
                    Name = "University of Stellenbosch",
                
                },
                new Universities()
                  {
                  
                    Name = "University of Mpumalanga",
                
                },
                new Universities()
             {
                  
                    Name = "University of Venda",
                
                },
                  new Universities()
                {
                    
                    Name = "Nelson Mandela Metropolitan Univesity",
                
                },

                /////////////////////////////////////////////////////////New

                 new Universities()
                  {
                  
                    Name = "North West University",
                
                },
                new Universities()
                  {
                  
                    Name = "University of the Witwatersrand",
                
                },
                new Universities()
             {
                  
                    Name = "University of Cape Town",
                
                },
                  new Universities()
                {
                    
                    Name = "Durban University of Technology",
                
                },
                 new Universities()
                  {
                  
                    Name = "University of the Western Cape",
                
                },
                new Universities()
                  {
                  
                    Name = "Walter Sisulu University",
                
                },

                 new Universities()
                  {
                  
                    Name = "Cape Peninsula University of Technology",
                
                },
                new Universities()
                  {
                  
                    Name = "Vaal University of Technology",
                
                },
                new Universities()
             {
                  
                    Name = "Sol Plaatje University",
                
                },
              
                 
            };

            // Add rows to the User Table
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
            await conn.InsertAllAsync(universitiesLists);
        }
    }
      
}