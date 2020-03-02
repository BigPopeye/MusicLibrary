using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicLibrary.Model;

namespace MusicLibrary
{
   public class PlayList
    {
        //define properties of playlist
        public List<Sound> SongList;
        string CoverImagePath;
        public ICommand Command { get; set; }
        public string Name { get; set; }


        public PlayList(string name)
        {
            Name = name;
            SongList = new List<Sound>();
        }

        public PlayList(string name, string coverimagepath)
        {
            Name = name;
            SongList = new List<Sound>();
            CoverImagePath = coverimagepath;
        }

        public string getName()
        {
            return Name;
        }

       
    }
}
