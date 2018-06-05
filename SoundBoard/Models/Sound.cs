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
    }

    public enum SoundCategory
    {
        Animals,
        Cartoons,
        Warnings,
        Taunts
    }
}
