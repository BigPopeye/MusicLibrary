using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using MusicLibrary.Model;
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
    public sealed partial class GenresPage : Page
    {

        private ObservableCollection<Sound> sounds;

        public GenresPage()
        {
            this.InitializeComponent();
            sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(sounds);

        }
        public NavigationView backButton;
        private void GenreGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var item = (MenuItem)e.ClickedItem;
            this.Frame.Navigate(typeof(SubSongsPage), backButton);

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            backButton = (NavigationView)e.Parameter;
            backButton.IsBackEnabled = false;
            
            base.OnNavigatedTo(e);
        }
        private void Button_one_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ElectronicPage), backButton);
        }


        private void Button_two_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HipHopPage),backButton);
        }
        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Params result = (Params)e.Parameter;
            base.OnNavigatedTo(e);
        }*/

        private void Button_three_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InstrumentalPage),backButton);
        }

        private void Button_fourth_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MetalPage),backButton);
        }
        private void Button_fifth_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PopPage),backButton);
        }
        private void Button_sixth_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RockPage),backButton);
        }
    }
}
