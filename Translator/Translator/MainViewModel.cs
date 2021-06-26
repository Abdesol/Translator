using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Translator
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> AllLang = new List<string>(){
            "English", "French", "Amharic", "Spanish", "Portugesse", "Arabic", "Hindi", "Punjabi"
        };

        public MainViewModel()
        {
            from_lang = AllLang[0];
            to_lang = AllLang[1];
            place_holder_text = "Your translation";
        }
        

        public ICommand  TranslateCommand => new Command(Translate);

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _from_lang { get; set; }
        public string from_lang
        {
            get
            {
                return _from_lang;
            }
            set
            {
                if (value != this._from_lang)
                {
                    _from_lang = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _to_lang { get; set; }
        public string to_lang
        {
            get
            {
                return _to_lang;
            }
            set
            {
                if (value != this._to_lang)
                {
                    _to_lang = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _from_text { get; set; }
        public string from_text
        {
            get
            {
                return _from_text;
            }
            set
            {
                if (value != this._from_text)
                {
                    _from_text = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _translated_text { get; set; }
        public string translated_text
        {
            get
            {
                return _translated_text;
            }
            set
            {
                if (value != this._translated_text)
                {
                    _translated_text = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private string _place_holder_text { get; set; }
        public string place_holder_text
        {
            get
            {
                return _place_holder_text;
            }
            set
            {
                if (value != this._to_lang)
                {
                    _place_holder_text = value;
                    NotifyPropertyChanged();
                }
            }
        }

        async void Translate()
        {
            place_holder_text = "Loading...";
            await Task.Delay(TimeSpan.FromSeconds(2));
            // the translation will be done here
            translated_text = from_text;
        }


        public ICommand ExchangeCommand => new Command(Exchange);
        public async void Exchange(object sender)
        {
            var btn = sender as ImageButton;
            await btn.ScaleTo(0.6, 70);
            await btn.RotateTo(180, 500, Easing.CubicInOut);
            btn.Rotation = 0;
            await btn.ScaleTo(0.7, 70);

            var previous_from = from_lang;
            from_lang = to_lang;
            to_lang = previous_from;
        }

        public ICommand CopyCommand => new Command(Copy);
        public async void Copy(object sender)
        {
            var btn = (ImageButton)sender;
            await btn.RotateTo(10, 300, Easing.CubicInOut);
            await btn.RotateTo(-10, 300, Easing.CubicInOut);
            await Clipboard.SetTextAsync(translated_text);
            await btn.RotateTo(0, 300, Easing.CubicInOut);
            DependencyService.Get<IToast>().ToastShow("Text copied to clipboard");
        }
    }
}
