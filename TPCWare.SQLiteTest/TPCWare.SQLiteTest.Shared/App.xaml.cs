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
                    WebsiteLink = "www.tut.ac.za"
                    
                },
                new Campuses()
                {
                    City = "Tshwane University of Technology",
                    Name = "Soshanguve North Campus",
                   WebsiteLink = "www.tut.ac.za"
                },
                new Campuses()
                {
                    City = "Tshwane University of Technology",
                    Name = "Pretoria Campus",
                    WebsiteLink = "www.tut.ac.za"
                },
                 new Campuses()
                {
                    City = "Tshwane University of Technology",
                    Name = "Malahleni Campus",
                    WebsiteLink = "www.tut.ac.za"
                },
                 new Campuses()
                {
                    City = "Tshwane University of Technology",
                    Name = "Nelpruit Campus",
                    WebsiteLink = "www.tut.ac.za"
                },
                 new Campuses()
                {
                    City = "Tshwane University of Technology",
                    Name = "Ga-Rankuwa Campus",
                    WebsiteLink = "www.tut.ac.za"
                },
                 new Campuses()
                {
                    City = "University Of Johannesburg",
                    Name = "Randburg Campus",
                    WebsiteLink = "www.uj.ac.za"
                },
                    //TNC
                 new Campuses()
            
                {
                    City = "University Of Johannesburg",
                    Name = "Soweto Campus",
                    WebsiteLink = "www.uj.ac.za"
                },
                 new Campuses()
                {
                    City = "University Of Johannesburg",
                    Name = "Johannesburg Campus",
                    WebsiteLink = "www.uj.ac.za"
                },
                 new Campuses()
                {
                   City = "TNC",
                    Name = "Arcadia Campus",
                    WebsiteLink = "www.tnc.ac.za"
                },
                 new Campuses()
                {
                    City = "ROSEBANK",
                    Name = "Only Pretoria campus",
                    WebsiteLink = "www.rosebank.ac.za"
                },
                  new Campuses()
                {
                    City = "University Of Limpopo",
                    Name = "Polokwane campus",
                    WebsiteLink = "www.ul.ac.za"
                },
                   new Campuses()
                {
                    City = "University Of Limpopo",
                    Name = "Medunsa campus",
                    WebsiteLink = "www.ul.ac.za"
                },
                   new Campuses()
                {
                    City = "University Of Limpopo",
                    Name = "Turfloop Campus",
                    WebsiteLink = "www.ul.ac.za"
                }
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
                    Id = 1,
                    courses = "IT",
                    
                },
                new Courses()
                {
                    Id = 2,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 2,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 4,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 5,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 6,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 4,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 5,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 6,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
                },
                    new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
                },
                    new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
                },
                    new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
                },
                    new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
                },
                    new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
                },
                    new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
                },
                    new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
                },
                    new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
                },
                    new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
                },
                    new Courses()
                {
                    Id = 1,
                    courses = "Public Management",
                   
                },
                new Courses()
                {
                    Id = 3,
                    courses = "Language Practise",
                
                },
                 new Courses()
                {
                    Id = 1,
                    courses = "Language Practise",
                
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
                   
                    Name = "Tshwane South TVET College",
                
                },
                    new College()
                {
                   
                    Name = "Thekwini TVET College",
                
                },
                    new College()
                {
                   
                    Name = "Nkangala TVET College",
                
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
              
                 
            };

            // Add rows to the User Table
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("institutionFinder.db");
            await conn.InsertAllAsync(universitiesLists);
        }
    }
      
}