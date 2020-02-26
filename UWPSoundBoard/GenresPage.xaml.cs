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
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/taunt.png",
                Category = SoundCategory.Taunts
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/warning.png",
                Category = SoundCategory.Warnings
            });
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Params result = (Params)e.Parameter;
            base.OnNavigatedTo(e);
        }

    }
}
