using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fenesan_Razvan_Proiect.Data;
using System.IO;

namespace Fenesan_Razvan_Proiect
{
    public partial class App : Application
    {
        static JournalingDatabase database;
        public static JournalingDatabase Database
        {
            get
            {
                if(database==null)
                {
                    database = new
                        JournalingDatabase(Path.Combine(Environment.GetFolderPath(Environment
                        .SpecialFolder.LocalApplicationData), "Journaling.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new JournalEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
