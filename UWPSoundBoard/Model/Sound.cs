using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicLibrary.Model
{
    public enum SoundCategory
    {
        Electronic,
        HipHop,
        Instrumental,
        Metal,
        Pop,
        Rock
    }
    public class Sound
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public SoundCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
        public ICommand Command { get; set; }
        
        Guid songID;

        public Sound(string name, SoundCategory category)
        {
            Name = name;
            Category = category;
            AudioFile = $"/Assets/Audio/{category}/{name}.mp3";
            ImageFile = $"/Assets/Images/{category}/{name}.png";
        }

        //New constructor to include artist and album
        public Sound(string name, string artist, string album, SoundCategory category)
        {
            Name = name;
            Artist = artist;
            Album = album;
            Category = category;
            AudioFile = $"/Assets/Audio/{category}/{name}.mp3";
            ImageFile = $"/Assets/Images/{category}/{name}.png";
        }
        public Guid getSongID()
        {
            return songID;
        }
    }
}
