using MusicLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InstrumentalPage : Page
    {
        private ObservableCollection<Sound> sounds;
        public InstrumentalPage()
        {
            this.InitializeComponent();
            sounds = new ObservableCollection<Sound>();
            SoundManager.GetSoundsByCategory(sounds, SoundCategory.Instrumental);

        }

        public static bool IsChecked { get; internal set; }

        private void pageTitle5_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GenresPage));
        }
        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, sound.AudioFile);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var backButton = (NavigationView)e.Parameter;
            backButton.IsBackEnabled = true;
            base.OnNavigatedTo(e);
        }
    }
}
