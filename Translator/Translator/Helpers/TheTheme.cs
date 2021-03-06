using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Translator.Helpers
{
    public static class TheTheme
    {
        public static void SetTheme()
        {
            switch (Settings.Theme)
            {
                //default
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                //light
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                //dark
                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }

            var nav = App.Current.MainPage as Xamarin.Forms.NavigationPage;

            var e = DependencyService.Get<IEnvironment>();
            if (App.Current.RequestedTheme == OSAppTheme.Dark)
            {
                e?.SetStatusBarColor(Color.FromHex("303135"), false);
                if (nav != null)
                {
                    nav.BarBackgroundColor = Color.FromHex("303135");
                    nav.BarTextColor = Color.White;
                }
            }
            else
            {
                e?.SetStatusBarColor(Color.FromHex("4286F5"), true);
                if (nav != null)
                {
                    nav.BarBackgroundColor = Color.FromHex("4286F5");
                    nav.BarTextColor = Color.White;
                }
            }
        }
    }
}
