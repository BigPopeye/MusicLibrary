using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    public enum SoundCategory
    {
        Electronic,
        HipHop,
        Instrumental,
        Metal,
        Pop,
        Rock,
    }
    public class Sound
    {
        public string Name { get; set; }
        public SoundCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
        public string Album { get; set; }
        public Sound(string name, SoundCategory category, string album)
        {
            Name = name;
            Category = category;
            Album = album;
            AudioFile = $"/Assets/Audio/{category}/{name}.mp3";
            ImageFile = $"/Assets/Images/{category}/{name}.png";
        }
    }
}
