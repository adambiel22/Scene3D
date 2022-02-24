using Algebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene3D
{
    public class PhongPixelShader : PixelShader
    {
        private Triangle triangle;
        public override void SetTriangleInWorld(Triangle triangle)
        {
            this.triangle = triangle;
        }

        protected override Color computeColor(double alfa, double beta, double gamma)
        {
            (double x, double y, double z) =
                BarycentricCoordinates.BarycentricToEuclidean(triangle, alfa, beta, gamma);

            Vector normalVector = new Vector(
                triangle.Verticies[0].NormalVector[0] * alfa
                    + triangle.Verticies[1].NormalVector[0] * beta
                    + triangle.Verticies[2].NormalVector[0] * gamma,
                triangle.Verticies[0].NormalVector[1] * alfa
                    + triangle.Verticies[1].NormalVector[1] * beta
                    + triangle.Verticies[2].NormalVector[1] * gamma,
                triangle.Verticies[0].NormalVector[2] * alfa
                    + triangle.Verticies[1].NormalVector[2] * beta
                    + triangle.Verticies[2].NormalVector[2] * gamma);
            normalVector.Normalize();

            return PhongIllumination.ComputeIllumination(
                new Vector(x, y, z, 1),
                normalVector,
                Camera.CameraPosition,
                Surface,
                Lights);
        }
    }
}
