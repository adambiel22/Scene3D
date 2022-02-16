using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Animating
{
    public class RouteAnimation : IAnimation
    {
        public StraightPathAnimation[] Paths { get; private set; }
        public double Period { get; private set; }
        public TransformatedBlock TransformatedBlock { get; private set; }

        public RouteAnimation(StraightPathAnimation[] paths, 
            TransformatedBlock transformatedBlock)
        {
            Paths = paths;
            Period = 0;
            foreach (var path in Paths)
            {
                Period += path.Period;
                path.TransformatedBlock = transformatedBlock;
            }
            TransformatedBlock = transformatedBlock;

        }

        public void UpdateFrame(TimeSpan elapsedTime)
        {
            double time = elapsedTime.TotalSeconds % Period;

        }
    }
}
