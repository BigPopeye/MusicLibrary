using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicLibrary.Model;

namespace MusicLibrary
{
    class PlayList
    {
        //define properties of playlist
        List<Sound> SongList;
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

        //define functions
        //add song to playlist
        public void AddSong(Sound newsong)
        {
            SongList.Add(newsong);
        }
        //Delete song to playlist
        public void DeleteSong(Sound songobject)
        {
            SongList.Remove(songobject);
        }


        public void AddSongID(Guid songID, DataSource source)
        {
            foreach (Sound s in source.getAllSongs())
            {
                if (s.getSongID() == songID)
                {
                    SongList.Add(s);
                    return;
                }
            }

        }
    }
}
