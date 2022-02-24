using Algebra;

namespace Scene3D
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

        public override string ToString()
        {
            return $"{(PositionVector[0], PositionVector[1], PositionVector[2])}";
        }
    }
}