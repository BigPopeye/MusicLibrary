using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace MusicLibrary
{
    class DataSource
    {
        //define collections
        ObservableCollection<Song> allSongs;
        ObservableCollection<PlayList> allPlayLists;

        public DataSource()
        {
            allSongs = new ObservableCollection<Song>();
            allPlayLists = new ObservableCollection<PlayList>();
        }
        //to return all songs from playlist
        public ObservableCollection<Song> getAllSongs()
        {
            return allSongs;
        }
        // to return all created playlists
        public ObservableCollection<PlayList> getAllPlayLists()
        {
            return allPlayLists;
        }

        public void AddSong(Song newsong)
        {
            allSongs.Add(newsong);
        }
        //to add new playlists
        public void AddPlayList(PlayList newPlayList)
        {
            allPlayLists.Add(newPlayList);
        }
        //to delete playlist
        public void DeletePlayList(PlayList playlistobject)
        {
            allPlayLists.Remove(playlistobject);
        }

        public ObservableCollection<PlayList> GetPlayLists()
        {
            return allPlayLists;
        }

        public Guid GetSongID(string name)
        {
            Song selectedSong = null;
            foreach (Song s in allSongs)
            {
                if (string.Equals(s.getName(), name))
                {
                    selectedSong = s;
                }
            }

            return selectedSong.getSongID();

        }
    }
}
