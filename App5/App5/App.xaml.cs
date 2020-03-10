using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    public partial class App : Application
    {
        public int Counter { get; set; } = 1;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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