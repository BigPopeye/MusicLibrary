using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary
{
    class Song
    {
        //define properties
        Guid songID;//
        string Name { get; set; }
        string SongFile { get; set; }
        string Artist { get; set; }
        string Genre { get; set; }
        string Album { get; set; }
        int Length { get; set; }
        string CoverImageFile { get; set; }

        //Define Constructor 1 for Song class
        public Song(string name)
        {
            songID = Guid.NewGuid();//Guid function generate a unique id for each song. 
            Name = name;
            SongFile = $"Assets/Songs/{Name}.mp3";
        }

        //Define Constructor2 for Song Class
        public Song(string name, string artist, string genre, string album, int length)
        {
            songID = Guid.NewGuid();
            Name = name;
            Artist = artist;
            Genre = genre;
            Album = album;
            Length = length;
        }

        //to get the id for song 
        public Guid getSongID()
        {
            return songID;
        }

        //get the name of the song
        public string getName()
        {
            return Name;
        }
        public string getartist()
        {
            return Artist;
        }
        public string getalbum()
        {
            return Album;
        }
        public string getgenre()
        {
            return Genre;
        }
    }
}
