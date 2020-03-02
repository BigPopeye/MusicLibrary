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
          
            sounds.Add(new Sound("3", "Britney Spears", "3", SoundCategory.Pop));
            sounds.Add(new Sound("Catch My Breath", "Kelly Clarkson", "Remixes", SoundCategory.Pop));
            sounds.Add(new Sound("Constellation of Tatyana", "Yakuro", "Stars Of The Pacific Ocean", SoundCategory.Electronic));
            sounds.Add(new Sound("Sky High", "Thomas Prime", "Fallen Skyes", SoundCategory.HipHop));
            sounds.Add(new Sound("Für immer", "Eisblume", "Für immer", SoundCategory.Instrumental));
            sounds.Add(new Sound("Hey Mama", "Alexander The Phatos", "Phatosism: A21st Century Cavatina", SoundCategory.HipHop));
            sounds.Add(new Sound("I Hate Myself For Loving You", "Joan Jett & The Blackhearts", "Greatest Hits", SoundCategory.Rock));
            sounds.Add(new Sound("La La Land", "Jax", "La La Land", SoundCategory.HipHop));
            sounds.Add(new Sound("Memories Of You", "Approaching Nirvana", "ANimals", SoundCategory.Electronic));
            sounds.Add(new Sound("Second Waltz", "James Last", "Classics From Russia", SoundCategory.Instrumental));
            sounds.Add(new Sound("The Tide Is High", "Atomic Kitten", "Video Hits", SoundCategory.Pop));
            sounds.Add(new Sound("Wrecking Ball", "Miley Cyrus", "Smash 2014 Vol.1", SoundCategory.Pop));
            sounds.Add(new Sound("Last Of The Wilds", "Nightwish", "Dark Passion Play", SoundCategory.Metal));

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
