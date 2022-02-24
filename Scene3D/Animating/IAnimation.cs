using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene3D
{
    public interface IAnimation
    {
        public abstract void NextFrame(TimeSpan timeOffset);
    }
}
