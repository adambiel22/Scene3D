using System;
using Algebra;
namespace Scene3D
{
    public class Transformation
    {
        private Matrix transformationMatrix;
        private Matrix inversedTransposedTransformationMatrix;
        
        public Transformation()
        {
            transformationMatrix = Matrix.CreateIdentity();
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }

        public Transformation(Matrix matrix)
        {
            transformationMatrix = Matrix.CreateIdentity() * matrix;
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }

        public Transformation(double[,] marixArray)
        {
            transformationMatrix = new Matrix(marixArray);
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }

        public void AddTransformation(Matrix matrix)
        {
            transformationMatrix = (transformationMatrix * matrix);
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }

        public void AddTransformation(double[,] matrixArray)
        {
            transformationMatrix = transformationMatrix 
                * new Matrix(matrixArray);
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }

        public void AddOffset(double x, double y, double z)
        {
            transformationMatrix = transformationMatrix *
                new Matrix(new double[,]
                {
                    { 1, 0, 0, x },
                    { 0, 1, 0, y },
                    { 0, 0, 1, z },
                    { 0, 0, 0, 1 },
                });
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }
        public void AddXAxisRotation(double angle)
        {
            transformationMatrix = transformationMatrix *
                new Matrix(new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, Math.Cos(angle), -Math.Sin(angle), 0 },
                    { 0, Math.Sin(angle), Math.Cos(angle), 0 },
                    { 0, 0, 0, 1 },
                });
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }

        public void AddYAxisRotation(double angle)
        {
            transformationMatrix = transformationMatrix *
                new Matrix(new double[,]
                {
                    { Math.Cos(angle), 0, Math.Sin(angle), 0 },
                    { 0, 1, 0, 0 },
                    { -Math.Sin(angle), 0 , Math.Cos(angle), 0 },
                    { 0, 0, 0, 1 },
                });
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }

        public void AddZAxisRotation(double angle)
        {
            transformationMatrix = transformationMatrix *
                new Matrix(new double[,]
                {
                    { Math.Cos(angle), -Math.Sin(angle), 0, 0 },
                    { Math.Sin(angle), Math.Cos(angle), 0, 0 },
                    { 0, 0 , 1, 0 },
                    { 0, 0, 0, 1 },
                });
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();
        }

        public void AddXYZRotation(double xAngle, double yAngle, double zAngle)
        {
            AddXAxisRotation(xAngle);
            AddYAxisRotation(yAngle);
            AddZAxisRotation(zAngle);
        }

        public void SetTransformation(Matrix matrix)
        {
            transformationMatrix = matrix;
            inversedTransposedTransformationMatrix = transformationMatrix.Inverse().Transpose();

        }

        public Vector TransformPoint(Vector positionVector)
        {
            return transformationMatrix * positionVector;
        }

        public Vector TransformNormalVector(Vector normalVector)
        {
            Vector vector = inversedTransposedTransformationMatrix * normalVector;
            vector.Normalize();
            return vector;
        }

        public Vertex TransformVertex(Vertex vertex)
        {
            return new Vertex(
                TransformPoint(vertex.PositionVector),
                TransformNormalVector(vertex.NormalVector));
        }

        public Triangle TransformTriangle(Triangle triangle)
        {
            Vertex[] verticiesInWorld = new Vertex[3];
            for (int i = 0; i < 3; i++)
            {
                verticiesInWorld[i] = TransformVertex(triangle.Verticies[i]);
            }
            return new Triangle(verticiesInWorld[0], verticiesInWorld[1], verticiesInWorld[2]);
        }

        public Block TransformBlock(Block block)
        {
            Block transformedBlock = new Block(0);
            transformedBlock.Triangles.AddRange(block.Triangles);
            transformedBlock.Verticies = TransformVerticies(block.Verticies);
            return transformedBlock;
        }

        public Vertex[] TransformVerticies(Vertex[] verticies)
        {
            Vertex[] transformedVerticies = new Vertex[verticies.Length];
            for (int i = 0; i < verticies.Length; i++)
            {
                transformedVerticies[i] = TransformVertex(verticies[i]);
            }
            return transformedVerticies;
        }
    }
}
