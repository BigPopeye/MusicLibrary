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
using System.Windows;
using System.Globalization;
using System.Drawing;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Data;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string p;
        DataSource currentDataSource;
        int c = 0;
        public MainPage()
        {
            this.InitializeComponent();


            currentDataSource = new DataSource();
            // Adding songs to Datasource
            Song s = new Song("CatchMyBreath");
            currentDataSource.AddSong(s);
            currentDataSource.AddSong(new Song("Sky High"));
            currentDataSource.AddSong(new Song("3"));
            currentDataSource.AddSong(new Song("Constellation of Tatyana"));
            currentDataSource.AddSong(new Song("Eisblume - Für immer (Instrumental).mp3"));
            currentDataSource.AddSong(new Song("Hey Mama"));
            currentDataSource.AddSong(new Song("I Hate Myself For Loving You"));
            currentDataSource.AddSong(new Song("Jax-La La land"));
            currentDataSource.AddSong(new Song("Last Of The Wilds"));
            currentDataSource.AddSong(new Song("Memories Of You"));
            currentDataSource.AddSong(new Song("Second Waltz"));
            currentDataSource.AddSong(new Song("The Tide Is High"));
            //currentDataSource.AddSong(new Song("Wrecking Ball"));



            // PlayList newPlaylist = new PlayList("UserList_1");
            // newPlaylist.AddSongID(currentDataSource.GetSongID("Sky High"), currentDataSource);
            // newPlaylist.AddSongID(currentDataSource.GetSongID("3"), currentDataSource);

        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            if (!MySplitView.IsPaneOpen)
            {
                SingleAddPlaylistButton.Visibility = Visibility.Visible;
            }
            else
            {
                SingleAddPlaylistButton.Visibility = Visibility.Collapsed;
            }

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //SoundManager.GetAllSounds(sounds);
            ////CategoryTextBlock.Text = "All Sounds";
            //MenuItemsListView.SelectedItem = null;
            //BackButton.Visibility = Visibility.Collapsed;
        }

        private void AllSongsMenu_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(GenresPage));
            //contentFrame.Navigate(typeof(AllSongsPage));
        }
        private void GenresMenu_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(GenresPage));
            //contentFrame.Navigate(typeof(GenresPage), new Params() { MyProperty = 42 });
        }

        private void PlaylistMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SingleAddPlaylistButton_Click(object sender, RoutedEventArgs e)
        {

        }


        
        private async void AddPlaylistButton_Click(object sender, RoutedEventArgs e)
        {
           // Frame.Navigate(typeof(ContentDialog1));
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

            // to add playlist with the name typed in texybox in list of playlists
            if (p != " ")
            {
                PlayList UP = new PlayList(p);
                currentDataSource.AddPlayList(UP);
                //ListBox listBox = new ListBox();


                // TextBox txtRun = new TextBox();
                // txtRun.Name = p + c++;
                // txtRun.Location = new Point(20, 18 + (20 * c));
                // txtRun.Size = new Size(200, 25);
                //this.Controls.Add(txtRun);
                //rootGrid.Children.Add(txtRun);


            }
        }


    }
    public class Params
    {
        public int MyProperty { get; set; }
    }
}
