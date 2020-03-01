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
        private ObservableCollection<Sound> sounds;
        private List<MenuItem> menuItems;
        string p;
        //DataSource currentDataSource;
        public MainPage()
        {
            this.InitializeComponent();
            //currentDataSource = new DataSource();

        }



        private void Navigator_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            Navigator.IsBackEnabled = contentFrame.CanGoBack;
            var item = sender.MenuItems.OfType<NavigationViewItem>()
                .First(x => (string)x.Content == (string)args.InvokedItem);
            NaviView_Navigate(item as NavigationViewItem);

        }
        private void NaviView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "AllSongsMenu":
                    contentFrame.Navigate(typeof(AllSongsPage), Navigator);
                    break;
                case "GernesMenu":
                    contentFrame.Navigate(typeof(GenresPage), Navigator);
                    break;
                case "PlaylistMenu":
                    contentFrame.Navigate(typeof(PlaylistPage));
                    break;
            }
        }

        // Deal with Back Button logic
        private void Navigator_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();
        }
        private bool On_BackRequested()
        {
            if (!contentFrame.CanGoBack)
                return false;

            if (Navigator.IsPaneOpen &&
                (Navigator.DisplayMode == NavigationViewDisplayMode.Compact ||
                Navigator.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;


            contentFrame.GoBack();
            return true;
        }

        //private void SingleAddPlaylistButton_Click(object sender, RoutedEventArgs e)
        //{

        //}


        //private async void AddPlaylistButton_Click(object sender, RoutedEventArgs e)
        //{

        //    ContentDialog1 ct = new ContentDialog1();
        //    var result = await ct.ShowAsync();

        //    //if create button on dialog box is created then textbox content will go in text
        //    if (result == ContentDialogResult.Primary)
        //    {
        //        var text = ct.Text;
        //        // ListBox1.DataContext = text;
        //        // ListBox1.Items.Add(text);
        //    }
        //    // if cancel button is clicked then textbox text will become null and dialog box window will be hidden
        //    else
        //    {
        //        ct.Text = " ";
        //        //ct.Hide();
        //    }
        //    p = ct.Text;

        //    // to add playlist with the name typed in textbox in list of playlists
        //    if (p != " ")
        //    {
        //        PlayList UP = new PlayList(p);
        //        currentDataSource.AddPlayList(UP);


        //    }
        //}

        //private void DeletePlaylistButton_Click(object sender, RoutedEventArgs e)
        //{
            
        //    if(PlayLists.SelectedValue != null)
        //    {
        //        string item = PlayLists.SelectedValue.ToString();
        //        currentDataSource.DeletePlayList(item);
        //    }          
        //}

      

        //private void PlayLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}



    }
}
