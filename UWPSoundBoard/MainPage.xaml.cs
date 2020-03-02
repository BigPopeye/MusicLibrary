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
        public MainPage()
        {
            this.InitializeComponent();

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
    }
}
