using System;
using System.Collections.Generic;
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
        private List<MenuItem> menuItems;
        public GenresPage()
        {
            this.InitializeComponent();
            menuItems = new List<MenuItem>();
            //Load pane
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/electronic.jpg",
                Category = SoundCategory.Electronic
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/hip-hop.jpg",
                Category = SoundCategory.HipHop
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/instrumental.jpg",
                Category = SoundCategory.Instrumental
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/metal.jpg",
                Category = SoundCategory.Metal
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/pop.jpg",
                Category = SoundCategory.Pop
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/rock.jpg",
                Category = SoundCategory.Rock
            });
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
    }
}
