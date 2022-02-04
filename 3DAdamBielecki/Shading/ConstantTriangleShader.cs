//using _3DAdamBielecki._3DScene;
//using MathNet.Numerics.LinearAlgebra.Double;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _3DAdamBielecki.Shading
//{
//    public class ConstantTriangleShader : PixelShader
//    {
//        Triangle triangle;
//        Surface material;
//        Light[] lights;
//        PixelTester pixelTester;
//        TriangleDrawer triangleDrawer;
//        Action<int, int, Color> putPixel;

//        public override void ShadeTriangle(
//            Triangle triangle,
//            Surface material,
//            Light[] lights,
//            PixelTester pixelTester,
//            TriangleDrawer triangleDrawer,
//            Action<int, int, Color> putPixel)
//        {
//            triangleDrawer.DrawTriangle(triangle, shadePixel);
//        }
        
//        private void shadePixel(int x, int y)
//        {
//            Vector pixelPosition = computePixelPosition(x, y); // obliczenie współrzędnej z  
//            if (!pixelTester.isPixelToDraw(pixelPosition))
//            {
//                return;
//            }
//            Color color = computeColor(pixelPosition, material, lights);
//            putPixel((int)pixelPosition[0], (int)pixelPosition[2], color);
//        }

//        private Vector computePixelPosition(int x, int y)
//        {
//            throw new NotImplementedException();
//        }

//        protected override Color computeColor(double alfa, double beta, double gamma)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
