using System;
using System.Collections.Generic;
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
    public sealed partial class PlaylistPage : Page
    {
        string p;
        DataSource currentDataSource;
        public PlaylistPage()
        {
            this.InitializeComponent();
            currentDataSource = new DataSource();
        }
        private async void AddPlaylistButton_Click(object sender, RoutedEventArgs e)
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
                //ct.Hide();
            }
            p = ct.Text;

            // to add playlist with the name typed in textbox in list of playlists
            if (p != " ")
            {
                PlayList UP = new PlayList(p);
                currentDataSource.AddPlayList(UP);


            }
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

        private void DeletePlaylistButton_Click(object sender, RoutedEventArgs e)
        {

            if (PlayLists.SelectedValue != null)
            {
                string item = PlayLists.SelectedValue.ToString();
                currentDataSource.DeletePlayList(item);
            }
        }
        private void PlayLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
