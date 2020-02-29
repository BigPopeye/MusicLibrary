using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary
{
    class PlayList
    {
        //define properties of playlist
        List<Song> SongList;
        string CoverImagePath;
        public string Name { get; set; }


        public PlayList(string name)
        {
            Name = name;
            SongList = new List<Song>();
        }

        public PlayList(string name, string coverimagepath)
        {
            Name = name;
            SongList = new List<Song>();
            CoverImagePath = coverimagepath;
        }

        public string getName()
        {
            return Name;
        }

        //define functions
        //add song to playlist
        public void AddSong(Song newsong)
        {
            SongList.Add(newsong);
        }

        public void DeleteSong(Song songobject)
        {
            SongList.Remove(songobject);
        }


        public void AddSongID(Guid songID, DataSource source)
        {
            foreach (Song s in source.getAllSongs())
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
