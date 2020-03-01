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
        DataSource currentDataSource;
        string p;

        public AllSongsPage()
        {
            this.InitializeComponent();
            sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(sounds);
            currentDataSource = new DataSource();
            
        }
        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
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
            ContentDialog1 ct = new ContentDialog1();
            var result = await ct.ShowAsync();

            //if create button on dialog box is created then textbox content will go in text
            if (result == ContentDialogResult.Primary)
            {
                var text = ct.Text;
                // ListBox1.DataContext = text;
                // ListBox1.Items.Add(text);
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
                currentDataSource.AddPlayList(UP);
            }
        }

        private void HoverButton_Click(object sender, RoutedEventArgs e)
        {

            var flyoutMenu1 = new MenuFlyoutItem();
            flyoutMenu1.Text = "Create Playlist";
            var flyoutMenu2 = new MenuFlyoutItem();
            flyoutMenu2.Text = "Add To >";

            var flyout = new MenuFlyout();
            flyout.Items.Add(flyoutMenu1);
            flyout.Items.Add(flyoutMenu2);

            var button = (Button)sender;
            button.Flyout = flyout;
        }

        //public List<MenuFlyoutItemBase> InitFlyoutItems()
        //{
        //    var list = new List<MenuFlyoutItemBase>
        //{
        //    new MenuFlyoutItem {Text="Create Playlist" },
        //    //new MenuFlyoutItem {Text="Add To Playlist" },
        //    new MenuFlyoutSubItem { Text="Add To Playlist"  }
        //};
        //    ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 1" });
        //    ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 2" });
        //    ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 3" });
        //    ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 4" });
        //    return list;
        //}

        //public MenuFlyoutItem GetPlaylist MenuFlyout(ObservableCollection<PlayList> playlists)
        //{
        //    MenuFlyoutItem menuFlyout = new MenuFlyoutItem();

        //    foreach(var playlist in playlists)
        //    {
        //        var item = new MenuFlyoutItem()
        //        {
        //            Text = playlist.Name
        //        };
        //        menuFlyout;
        //    }
        //    return menuFlyout;
        //}
    }
}
