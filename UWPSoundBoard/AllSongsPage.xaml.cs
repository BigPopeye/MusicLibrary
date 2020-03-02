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
using Windows.Storage.BulkAccess;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class AllSongsPage : Page
    {
        private ObservableCollection<Sound> sounds;
        private ObservableCollection<PlayList> playlists;
        //DataSource currentDataSource;
        string p;

        public AllSongsPage()
        {
            this.InitializeComponent();
            sounds = new ObservableCollection<Sound>();
            playlists = new ObservableCollection<PlayList>();
            DataSource.getAllPlayLists(ref playlists);
            SoundManager.GetAllSounds(sounds);
            //currentDataSource = new DataSource(); 
            
        }
        private void SoundListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, sound.AudioFile);
        }


        private void ListViewSwipeContainer_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse || e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Pen)
            {
                VisualStateManager.GoToState(sender as Control, "HoverButtonsShown", true);
            }
            var test = e.Pointer.GetType();
            
        }

        private void ListViewSwipeContainer_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(sender as Control, "HoverButtonsHidden", true);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var backButton = (NavigationView)e.Parameter;
            backButton.IsBackEnabled = false;

            base.OnNavigatedTo(e);
        }

        private async void MenuAddPlaylist_Click(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent(this);
            while(!(parent is UserControl))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            //var test = (parent as UserControl).GetValue();
            ContentDialog1 ct = new ContentDialog1();
            var result = await ct.ShowAsync();

            //if create button on dialog box is created then textbox content will go in text
            if (result == ContentDialogResult.Primary)
            {
                var text = ct.Text;
                
            }
            // if cancel button is clicked then textbox text will become null and dialog box window will be hidden
            else
            {
                ct.Text = " ";
                ct.Hide();
            }
            p = ct.Text;

            // to add playlist with the name typed in textbox in list of playlists
            if (p != " ")
            {
                PlayList UP = new PlayList(p);
                DataSource.AddPlayList(UP);
            }
        }

        private void HoverButton_Click(object sender, RoutedEventArgs e)
        {

            var flyoutMenu1 = new MenuFlyoutItem();
            flyoutMenu1.Text = "Create Playlist";
            flyoutMenu1.Click += MenuAddPlaylist_Click;
            var seperator = new MenuFlyoutSeparator();
            var flyoutMenu2 = new MenuFlyoutItem();
            flyoutMenu2.Text = "Add To >";

            var flyout = new MenuFlyout();
            flyout.Items.Add(flyoutMenu1);
            
            flyout.Items.Add(flyoutMenu2);

            foreach (PlayList playlist in playlists)
            {
                var flyoutmenu = new MenuFlyoutItem();
                flyoutmenu.Text = playlist.Name;
                flyoutmenu.Click += MenuFlyoutItem_Click;
                flyout.Items.Add(flyoutmenu);
            }
            var button = (Button)sender;
            button.Flyout = flyout;
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            if(SoundListView.SelectedItem != null)
            {
                var song = (Sound)SoundListView.SelectedItem;
                MenuFlyoutItem selectedItem = sender as MenuFlyoutItem;

                DataSource.AddSongToPlayList(song, selectedItem.Text.ToString());
            }
            
        }

        private void PalySong_Click(object sender, RoutedEventArgs e)
        {
            //var sound = (Sound)e;
            //MyMediaElement.Source = new Uri(this.BaseUri, sound.AudioFile);
        }
    }
}
