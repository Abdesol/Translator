using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Translator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel();
            InitializeComponent();

            var all_lang = (BindingContext as MainViewModel).AllLang;
            foreach (string lang in all_lang)
            {
                from_picker.Items.Add(lang);
                to_picker.Items.Add(lang);
            }
        }

        public async void ButtonTapped(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            await btn.ScaleTo(0.7, 70);
            await btn.ScaleTo(1, 70);
            if (btn != trans_btn)
            { 
                
                if(btn == from_btn)
                {
                    from_picker.Focus();
                }
                else
                {
                    to_picker.Focus();
                }
            }
        }

        public void LanguageSelected(object sender, EventArgs e)
        {
            Console.WriteLine("picked");
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            Device.BeginInvokeOnMainThread(() =>
            {
                if (picker == from_picker)
                {
                    (BindingContext as MainViewModel).from_lang = (BindingContext as MainViewModel).AllLang[selectedIndex];
                }
                else
                {
                    (BindingContext as MainViewModel).to_lang = (BindingContext as MainViewModel).AllLang[selectedIndex];
                }
            });
        }
    }
}
