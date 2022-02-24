using Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene3D
{
    public class Cuboid : Block
    {

        public Cuboid(int triangulationLevel, double x = 1.0, double y = 1.0, double z = 1.0) : base(0)
        {
            //up face
            Block face = new RectangleFaceXY(x, y, triangulationLevel);
            Transformation faceTransformation = new Transformation();
            faceTransformation.AddOffset(0.0, 0.0, z);
            face = faceTransformation.TransformBlock(face);
            AddBlock(face);

            //down face            
            face = new RectangleFaceXY(x, y, triangulationLevel);
            face.InsideOutRotation();
            AddBlock(face);

            //front face
            face = new RectangleFaceYZ(y, z, triangulationLevel);
            faceTransformation = new Transformation();
            faceTransformation.AddOffset(x, 0.0, 0.0);
            face = faceTransformation.TransformBlock(face);
            AddBlock(face);

            //back face
            face = new RectangleFaceYZ(y, z, triangulationLevel);
            face.InsideOutRotation();
            AddBlock(face);

            //right face
            face = new RectangleFaceZX(z, x, triangulationLevel);
            faceTransformation = new Transformation();
            faceTransformation.AddOffset(0.0, y, 0.0);
            face = faceTransformation.TransformBlock(face);
            AddBlock(face);

            //left face
            face = new RectangleFaceZX(z, x, triangulationLevel);
            face.InsideOutRotation();
            AddBlock(face);



            //Verticies = new Vertex[]
            //{
            //    new Vertex(new Vector(0.0, 0.0, 0.0, 1.0),
            //        new Vector(-x / 2.0, -y / 2.0, -z / 2, 0)),
            //    new Vertex(new Vector(x, 0.0, 0.0, 1.0),
            //        new Vector(x / 2.0, -y / 2.0, -z / 2.0, 0.0)),
            //    new Vertex(new Vector(x, y, 0.0, 1.0),
            //        new Vector(x / 2.0, y / 2.0, -z / 2.0, 0.0)),
            //    new Vertex(new Vector(0.0, y, 0.0, 1.0),
            //        new Vector(-x / 2.0, y / 2.0, -z / 2.0, 0.0)),
            //    new Vertex(new Vector(0.0, 0.0, z, 1.0),
            //        new Vector(-x / 2.0, -y / 2.0, z / 2.0, 0.0)),
            //    new Vertex(new Vector(x, 0.0, z, 1.0),
            //        new Vector(x / 2.0, -y / 2.0, z / 2.0, 0.0)),
            //    new Vertex(new Vector(x, y, z, 1.0),
            //        new Vector(x / 2.0, y / 2.0, z / 2.0, 0.0)),
            //    new Vertex(new Vector(0.0, y, z, 1.0),
            //        new Vector(-x / 2.0, y / 2.0, z / 2.0, 0.0)),
            //};
            //foreach(Vertex vertex in Verticies)
            //{
            //    vertex.NormalVector.Normalize();
            //}

            //Triangles.AddRange(new (int, int, int)[]
            //{
            //    (0, 2, 1),
            //    (0, 3, 2),
            //    (6, 4, 5),
            //    (6, 7, 4),
            //    (1, 2, 5),
            //    (2, 6, 5),
            //    (0, 4, 3),
            //    (4, 7, 3),
            //    (2, 3, 6),
            //    (6, 3, 7),
            //    (5, 0, 1),
            //    (4, 0, 5),
            //});
        }

    }
}
