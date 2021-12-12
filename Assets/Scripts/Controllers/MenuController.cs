using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidS
{
    public class MenuController
    {
        public event Action<float> OnSoundVolumeChangebackground;
        public event Action<float> OnSoundVolume;
    }
}
