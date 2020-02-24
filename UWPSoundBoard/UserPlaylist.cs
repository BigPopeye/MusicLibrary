
//For Prachi to Review

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicLibrary
{
    class UserPlaylist
    {
        List<PlayList> userplaylist;

        public UserPlaylist()
        {
            userplaylist = new List<PlayList>();
        }

        public void AddPlaylist(string name)
        {
            userplaylist.Add(new PlayList(name));


        }

    }
}