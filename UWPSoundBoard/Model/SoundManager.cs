using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    public static class SoundManager
    {
        private static List<Sound> getSounds()
        {
            var sounds = new List<Sound>();

            sounds.Add(new Sound("Constellation Of Tatyana", SoundCategory.Electronic, "Stars Of The Pacific Ocean"));
            sounds.Add(new Sound("Memories Of You", SoundCategory.Electronic, "Album Name"));

            sounds.Add(new Sound("Hey Mama", SoundCategory.HipHop, "Album Name"));
            sounds.Add(new Sound("Sky High", SoundCategory.HipHop, "Album Name"));
            sounds.Add(new Sound("La La Land", SoundCategory.HipHop, "Album Name"));

            sounds.Add(new Sound("Second Waltz", SoundCategory.Instrumental, "Album Name"));

            sounds.Add(new Sound("Last Of The Wilds", SoundCategory.Metal, "Album Name"));

            sounds.Add(new Sound("3", SoundCategory.Pop, "Album Name"));
            sounds.Add(new Sound("Catch My Breath", SoundCategory.Pop, "Album Name"));
            sounds.Add(new Sound("The Tide is High", SoundCategory.Pop, "Album Name"));
            sounds.Add(new Sound("Wrecking Ball", SoundCategory.Pop, "Album Name"));

            sounds.Add(new Sound("I Hate Myself For Loving You", SoundCategory.Rock, "Album Name"));

            return sounds;
        }
        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allSounds = getSounds();
            sounds.Clear();
            allSounds.ForEach(s => sounds.Add(s));
        }

        public static void GetSoundsByCategory(
            ObservableCollection<Sound> sounds, SoundCategory category)
        {
            var allSounds = getSounds();
            var filteredSounds = allSounds.Where(s => s.Category == category).ToList();
            sounds.Clear();
                filteredSounds.ForEach(s => sounds.Add(s));
        }
    }
}
