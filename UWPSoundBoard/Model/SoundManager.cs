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
            //sounds.Add(new Sound("Cow", SoundCategory.Animals));
            //sounds.Add(new Sound("Cat", SoundCategory.Animals));

            //sounds.Add(new Sound("Gun", SoundCategory.Cartoons));
            //sounds.Add(new Sound("Spring", SoundCategory.Cartoons));

            //sounds.Add(new Sound("Clock", SoundCategory.Taunts));
            //sounds.Add(new Sound("LOL", SoundCategory.Taunts));

            //sounds.Add(new Sound("Ship", SoundCategory.Warnings));
            //sounds.Add(new Sound("Siren", SoundCategory.Warnings));
            sounds.Add(new Sound("3", SoundCategory.Pop));
            sounds.Add(new Sound("Catch My Breath", SoundCategory.Pop));
            sounds.Add(new Sound("Constellation of Tatyana", SoundCategory.Electronic));
            sounds.Add(new Sound("Sky High", SoundCategory.HipHop));
            sounds.Add(new Sound("Für immer", SoundCategory.Instrumental));
            sounds.Add(new Sound("Hey Mama", SoundCategory.HipHop));
            sounds.Add(new Sound("I Hate Myself For Loving You", SoundCategory.Rock));
            sounds.Add(new Sound("La La Land", SoundCategory.HipHop));
            sounds.Add(new Sound("Memories Of You", SoundCategory.Electronic));
            sounds.Add(new Sound("Second Waltz", SoundCategory.Instrumental));
            sounds.Add(new Sound("The Tide Is High", SoundCategory.Pop));
            sounds.Add(new Sound("Wrecking Ball", SoundCategory.Pop));

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
