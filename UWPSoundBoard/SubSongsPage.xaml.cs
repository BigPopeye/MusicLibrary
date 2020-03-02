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
    public sealed partial class SubSongsPage : Page
    {
        public ObservableCollection<Sound> sounds;
        public PlayList playlist;
        public SubSongsPage()
        {
            this.InitializeComponent();
            sounds = new ObservableCollection<Sound>();
            playlist = new PlayList();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            playlist = (PlayList)e.Parameter;
            DataSource.GetSoundsByPlaylist(sounds, playlist);
            PlaylistTextBlock.Text = playlist.Name;
            base.OnNavigatedTo(e);
        }
        private void SoundListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, sound.AudioFile);
        }

        // When hover songs list item, the button "Add to Playlist" will show up
        private void ListViewSwipeContainer_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse || e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Pen)
            {
                VisualStateManager.GoToState(sender as Control, "HoverButtonsShown", true);
            }
        }

        private void ListViewSwipeContainer_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(sender as Control, "HoverButtonsHidden", true);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(SoundListView.SelectedItem != null)
            {
                var songToDel = (Sound)SoundListView.SelectedItem;
                var playlistName = PlaylistTextBlock.Text;
                DataSource.DeleteSongFromPlaylist(songToDel, playlistName);
                DataSource.GetSoundsByPlaylist(sounds, playlist);
            }
        }

        private void DeletePlayList_Click(object sender, RoutedEventArgs e)
        {
            DataSource.DeletePlayList(PlaylistTextBlock.Text);
            this.Frame.GoBack();
        }
    }
}
