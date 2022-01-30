﻿using System.Collections.Generic;

namespace _3DAdamBielecki.Shading
{
    public class Scene
    {
        public List<TransformatedBlock> TransformatedBlocks { get; private set; }
        public Camera Camera { get; private set; }
        public Projection Projection { get; private set; }
        public Light[] Lights { get; private set; }
    }
}