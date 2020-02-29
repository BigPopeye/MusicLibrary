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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> sounds;
        private List<MenuItem> menuItems;
        string p;
        DataSource currentDataSource;
        public MainPage()
        {
            this.InitializeComponent();
            //sounds = new ObservableCollection<Sound>();
            //SoundManager.GetAllSounds(sounds);

            //menuItems = new List<MenuItem>();
            ////Load pane
            //menuItems.Add(new MenuItem
            //{
            //    IconFile = "Assets/Icons/animals.png",
            //    Category = SoundCategory.Animals
            //});
            //menuItems.Add(new MenuItem
            //{
            //    IconFile = "Assets/Icons/cartoon.png",
            //    Category = SoundCategory.Cartoons
            //});
            //menuItems.Add(new MenuItem
            //{
            //    IconFile = "Assets/Icons/taunt.png",
            //    Category = SoundCategory.Taunts
            //});
            //menuItems.Add(new MenuItem
            //{
            //    IconFile = "Assets/Icons/warning.png",
            //    Category = SoundCategory.Warnings
            //});

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
            contentFrame.Navigate(typeof(AllSongsPage));
        }
        private void GenresMenu_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(GenresPage));
            contentFrame.Navigate(typeof(GenresPage), new Params() { MyProperty = 42 });
        }

        private void PlaylistMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SingleAddPlaylistButton_Click(object sender, RoutedEventArgs e)
        {

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
        private void DeletePlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            
            string item = Delete1.SelectedValue.ToString();
                  
            currentDataSource.DeletePlayList(item);
        }

        //private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var menuItem = (MenuItem)e.ClickedItem;
        //    CategoryTextBlock.Text = menuItem.Category.ToString();
        //    SoundManager.GetSoundsByCategory(sounds, menuItem.Category);
        //    BackButton.Visibility = Visibility.Visible;
        //}

        //private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var sound = (Sound)e.ClickedItem;
        //    MyMediaElement.Source = new Uri(this.BaseUri, sound.AudioFile);
        //}


    }
    public class Params
    {
        public int MyProperty { get; set; }
    }
}
