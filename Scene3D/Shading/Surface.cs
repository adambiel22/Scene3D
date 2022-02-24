using System.Drawing;

namespace Scene3D
{
    public class Surface
    {
        public double DiffuseConst { get; set; }
        public double SpecularConst { get; set; }
        public double AmbientConst { get; set; }
        public int NShiny { get; set; }
        public Color Color { get; set; }

        public Surface(double diffuseConst, double specularConst, double ambientConst, int nShiny, Color color)
        {
            DiffuseConst = diffuseConst;
            SpecularConst = specularConst;
            AmbientConst = ambientConst;
            NShiny = nShiny;
            Color = color;
        }
    }
}