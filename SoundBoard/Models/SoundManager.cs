using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class SoundManager
    {
        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allSounds = GetSounds();
            sounds.Clear();
            foreach (var sound in allSounds)
            {
                sounds.Add(sound);
            }
        }

        public static void GetSoundByCategory(ObservableCollection<Sound> sounds, SoundCategory category)
        {
            var allSounds = GetSounds();
            var filteredSounds = allSounds.Where(p => p.Category.Equals(category)).ToList();
            sounds.Clear();
            foreach (var sound in filteredSounds)
            {
                sounds.Add(sound);
            }
        }

        private static List<Sound> GetSounds()
        {
            var sounds = new List<Sound>()
            {
                new Sound("Cow", SoundCategory.Animals),
                new Sound("Cat", SoundCategory.Animals),

                new Sound("Gun", SoundCategory.Cartoons),
                new Sound("Spring", SoundCategory.Cartoons),

                new Sound("Clock", SoundCategory.Taunts),
                new Sound("LOL", SoundCategory.Taunts),

                new Sound("Ship", SoundCategory.Warnings),
                new Sound("Siren", SoundCategory.Warnings),
            };
            return sounds;
        }
    }
}
