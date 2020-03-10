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
    public partial class Page1 : ContentPage
    {
        public Page1(string title)
        {
            InitializeComponent();
            this.Title = title;
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

        private void goback2(object sender, EventArgs e)
        {
            Navigation.PopUntilFirstPageType(typeof(Page1));
        }

        private void goback3(object sender, EventArgs e)
        {
            Navigation.PopUntilLastPageType(typeof(Page1));
        }
    }


    public static class XamarinHelper
    {
        /*
         * Navigation.PopUntilLastPageType(typeof(Page1));
         */
        public static async Task PopUntilFirstPageType(this INavigation nav, Type DestinationPageType)
        {
            var pages_count = nav.NavigationStack.Count;
            int mark = pages_count;
            bool remove_page = false;
            List<int> remove_us = new List<int> { };

            for (int i = 0; i < pages_count; i++)
            {
                if (!remove_page && nav.NavigationStack[i].GetType().Equals(DestinationPageType))
                {
                    if (i == pages_count - 1)
                    {
                        return;
                    }
                    mark = i;
                    remove_page = true;
                    continue;
                }

                if (remove_page && i < (pages_count - 1))
                {
                    remove_us.Add(i);
                }
            }

            for (int i = remove_us.Count - 1; i >=0 ; i--)
            {
                nav.RemovePage(nav.NavigationStack[remove_us[i]]);
            }
            await nav.PopAsync();
        }

        public static async Task PopUntilLastPageType(this INavigation nav, Type DestinationPageType)
        {
            var pages_count = nav.NavigationStack.Count;
            int mark = pages_count;
            bool remove_page = false;
            List<int> remove_us = new List<int> { };

            for (int i = pages_count - 1; i >=0; i--)
            {
                if (nav.NavigationStack[i].GetType().Equals(DestinationPageType))
                {
                    if (i == pages_count - 1)
                    {
                        return;
                    }

                    mark = i;
                    break;
                }
            }

            for (int i = mark+1; i < (pages_count-1); i++)
            {
                remove_us.Add(i);
            }

            for (int i = remove_us.Count - 1; i >= 0; i--)
            {
                nav.RemovePage(nav.NavigationStack[remove_us[i]]);
            }
            await nav.PopAsync();
        }
    }
}