
//For Prachi to Review

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
        public string Name { get; set; }
        List<Song> SongList;
        string CoverImagePath;
        //private PlayList name;


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
        
        //define functions
        //add song to playlist
        public void AddSong(Song newsong)
        {
            SongList.Add(newsong);
        }
        //delete song in playlist
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
