using System;
using System.Linq;
using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using Xamarin.Forms;

namespace TextToSpeech
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            GetLanguages();
        }

        private async void GetLanguages()
        {
            var languages = await CrossTextToSpeech.Current.GetInstalledLanguages();
            LanguageListView.ItemsSource = languages.OrderBy(l => l.DisplayName);
        }

        private void SpeakButtonOnClicked(object sender, EventArgs e)
        {
            var textToSpeak = string.IsNullOrEmpty(TextToSpeechEntry.Text) ? "Please insert a text in the entry field." : TextToSpeechEntry.Text;
            CrossTextToSpeech.Current.Speak(textToSpeak);
        }

        private void LanguageListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is CrossLocale language)
            {
                var textToSpeak = string.IsNullOrEmpty(TextToSpeechEntry.Text)
                    ? "Please insert a text in the entry field."
                    : TextToSpeechEntry.Text;

                CrossTextToSpeech.Current.Speak(textToSpeak, language);
            }
        }
    }
}
