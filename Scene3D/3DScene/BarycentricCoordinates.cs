using Algebra;

namespace Scene3D
{
    public static class BarycentricCoordinates
    {
        public static (double alpha, double beta, double gamma)
            CartesianToBarycentric(Triangle triangle, double x, double y)
        {
            double denominator =
                  (triangle.Verticies[1].PositionVector[1] - triangle.Verticies[2].PositionVector[1])
                * (triangle.Verticies[0].PositionVector[0] - triangle.Verticies[2].PositionVector[0])
                + (triangle.Verticies[2].PositionVector[0] - triangle.Verticies[1].PositionVector[0])
                * (triangle.Verticies[0].PositionVector[1] - triangle.Verticies[2].PositionVector[1]);

            double alpha = ((triangle.Verticies[1].PositionVector[1] - triangle.Verticies[2].PositionVector[1])
                * (x - triangle.Verticies[2].PositionVector[0])
                + (triangle.Verticies[2].PositionVector[0] - triangle.Verticies[1].PositionVector[0])
                * (y - triangle.Verticies[2].PositionVector[1])) / denominator;
            double beta = ((triangle.Verticies[2].PositionVector[1] - triangle.Verticies[0].PositionVector[1])
                * (x - triangle.Verticies[2].PositionVector[0])
                + (triangle.Verticies[0].PositionVector[0] - triangle.Verticies[2].PositionVector[0])
                * (y - triangle.Verticies[2].PositionVector[1])) / denominator;

            return (alpha, beta, 1 - alpha - beta);
        }

        public static (double alpha, double beta, double gamma)
            EuclideanToBarycentric(Triangle triangle, double x, double y, double z)
        {
            Vector euclideanVector = new Vector(x, y, z);

            Vector v0Vector = 
                (new Vector(
                    triangle.Verticies[0].PositionVector[0],
                    triangle.Verticies[0].PositionVector[1],
                    triangle.Verticies[0].PositionVector[2]
                ) - euclideanVector);
            Vector v1Vector =
                (new Vector(
                    triangle.Verticies[1].PositionVector[0],
                    triangle.Verticies[1].PositionVector[1],
                    triangle.Verticies[1].PositionVector[2]
                ) - euclideanVector);
            Vector v2Vector =
                (new Vector(
                    triangle.Verticies[2].PositionVector[0],
                    triangle.Verticies[2].PositionVector[1],
                    triangle.Verticies[2].PositionVector[2]
                ) - euclideanVector);

            double v0 = Vector.Cross(v2Vector, v1Vector).Norm() / 2;
            double v1 = Vector.Cross(v0Vector, v2Vector).Norm() / 2;
            double v2 = Vector.Cross(v1Vector, v0Vector).Norm() / 2;
            double sum = v0 + v1 + v2;

            double alpha = v0 / sum;
            double beta = v1 / sum;
            double gamma = v2 / sum;

            return (alpha, beta, gamma);
        }

        public static (double x, double y, double z)
            BarycentricToEuclidean(Triangle triangle, double alpha, double beta, double gamma)
        {
            double x =
                  alpha * triangle.Verticies[0].PositionVector[0]
                + beta * triangle.Verticies[1].PositionVector[0]
                + gamma * triangle.Verticies[2].PositionVector[0];

            double y =
                  alpha * triangle.Verticies[0].PositionVector[1]
                + beta * triangle.Verticies[1].PositionVector[1]
                + gamma * triangle.Verticies[2].PositionVector[1];

            double z =
                  alpha * triangle.Verticies[0].PositionVector[2]
                + beta * triangle.Verticies[1].PositionVector[2]
                + gamma * triangle.Verticies[2].PositionVector[2];

            return (x, y, z);
        }
    }
}
