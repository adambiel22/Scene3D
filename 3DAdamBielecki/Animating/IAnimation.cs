using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public interface IAnimation
    {
        public abstract void UpdateFrame(TimeSpan elapsedTime);
    }
}
