using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.Models
{
    public class Sound
    {
        public string Name { get; set; }
        public SoundCategory Category { get; set; }
        public string AudoFile { get; set; }
        public String ImageFile { get; set; }

        public Sound(string name, SoundCategory category)
        {
            Name = name;
            Category = category;
            AudoFile = $"Assets/Audio/{category}/{name}.wav";
            ImageFile =$"Assets/Images/{category}/{name}.png";
        }
    }

    public enum SoundCategory
    {
        Animals,
        Cartoons,
        Warnings,
        Taunts
    }
}
