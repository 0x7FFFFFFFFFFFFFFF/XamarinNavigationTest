using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
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

        private async void goback2(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void goback3(object sender, EventArgs e)
        {
            Navigation.PopUntilLastPageType(typeof(Page1));
        }
    }
}