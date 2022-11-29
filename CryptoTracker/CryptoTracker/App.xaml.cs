using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace CryptoTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=3a16f7c4-4b79-46f0-ab6a-d78e11e4dc97",
                  typeof(Analytics), typeof(Crashes));

            try
            {
                Crashes.GenerateTestCrash();
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }

        }
        
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
