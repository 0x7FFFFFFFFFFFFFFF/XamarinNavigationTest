using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void gotopage1(object sender, EventArgs e)
        {
            var counter = (Application.Current as App).Counter;
            await Application.Current.MainPage.Navigation.PushAsync(new Page1(counter.ToString()));
            (Application.Current as App).Counter++;
        }

        private async void gotopage2(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Page2());
        }

        private async void goback(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}