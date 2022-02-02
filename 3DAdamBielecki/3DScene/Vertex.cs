﻿using Algebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace _3DAdamBielecki._3DScene
{
    public class Vertex
    {
        public Vector PositionVector { get; private set; }
        public Vector NormalVector { get; private set; }

        public Vertex(Vector positionVector, Vector normalVector)
        {
            PositionVector = positionVector;
            NormalVector = normalVector;
        }

        public Vertex(Vector positionVector)
        {
            PositionVector = positionVector;
        }
    }
}