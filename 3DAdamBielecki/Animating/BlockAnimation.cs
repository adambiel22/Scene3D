using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public abstract class BlockAnimation
    {
        public TransformatedBlock TransformatedBlock { get; set; }
        public BlockAnimation(TransformatedBlock transformatedBlock)
        {
            TransformatedBlock = transformatedBlock;
        }

        public abstract void NextFrame(double timeOffset);
    }
}
