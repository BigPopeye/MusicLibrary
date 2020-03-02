using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using MusicLibrary.Model;

namespace MusicLibrary
{
    public static class DataSource
    {
        //define collections
        private static ObservableCollection<Sound> allSongs;
        private static ObservableCollection<PlayList> allPlayLists;

        static DataSource()
        {
            allSongs = new ObservableCollection<Sound>();
            allPlayLists = new ObservableCollection<PlayList>();
        }

        public static ObservableCollection<Sound> getAllSongs()
        {
            return allSongs;
        }

        public static void  getAllPlayLists(ref ObservableCollection<PlayList> playlists)
        {
            playlists = allPlayLists;
        }

        public static void AddSongToPlayList(Sound newsong, string playlistName)
        {
            foreach(PlayList playlist in allPlayLists)
            {
                if (playlist.Name.Equals(playlistName))
                {
                    playlist.SongList.Add(newsong);
                }
            }
        }

        public static void AddPlayList(PlayList newPlayList)
        {
            allPlayLists.Add(newPlayList);
        }

        public static void DeletePlayList(string nameToDelete)
        {
            //allPlayLists.Remove(playlistobject);
            PlayList objectToDelete = null;
            foreach (PlayList p in allPlayLists)
            {
                if (string.Equals(p.getName(), nameToDelete))
                {
                    objectToDelete = p;
                    break;
                }
            }

            allPlayLists.Remove(objectToDelete);
            return;
        }

       
    }
}
