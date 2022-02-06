using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki
{
    public static class PolygonDrawer
    {
        public static void DrawPolygon(Point[] vericies, Action<int, int> setPixel)
        {
            for (int i = 0; i < vericies.Length; i++)
            {
                drawLine(vericies[i], vericies[(i + 1) % vericies.Length], setPixel);
            }
        }
        public static void FillPolygon(Point[] vericies, Action<int, int> SetPixel)
        {
            int n = vericies.Length;
            int[] ind = new int[n];
            ActiveEdge[] edges = new ActiveEdge[n];
            List<ActiveEdge> AET = new List<ActiveEdge>();

            for (int i = 0; i < n; i++)
            {
                ind[i] = i;
                edges[i] = new ActiveEdge(vericies[i], vericies[(i + 1) % n], i);
            }
            Array.Sort(ind, (int i, int j) => {
                return vericies[i].Y - vericies[j].Y == 0 ? 0 :
                (vericies[i].Y - vericies[j].Y < 0 ? -1 : 1);
            });

            int k = 0;
            for (int y = vericies[ind[0]].Y + 1; y <= vericies[ind[n - 1]].Y; y++)
            {
                while (vericies[ind[k]].Y == y - 1)
                {
                    Point p = vericies[(ind[k] + n - 1) % n];
                    if (p.Y > vericies[ind[k]].Y)
                    {
                        AET.Add(edges[(ind[k] + n - 1) % n]);
                    }
                    else if (p.Y < vericies[ind[k]].Y)
                    {
                        AET.Remove(edges[(ind[k] + n - 1) % n]);
                    }

                    p = vericies[(ind[k] + 1) % n];
                    if (p.Y > vericies[ind[k]].Y)
                    {
                        AET.Add(edges[ind[k]]);
                    }
                    else if (p.Y < vericies[ind[k]].Y)
                    {
                        AET.Remove(edges[ind[k]]);
                    }
                    k++;
                }

                AET.Sort();
                for (int i = 0; i < AET.Count; i += 2)
                {
                    for (int x = (int)AET[i].X + 1; x <= AET[(i + 1)].X; x++)
                    {
                        SetPixel(x, y - 1);
                    }
                }

                foreach (ActiveEdge edge in AET)
                {
                    edge.Increment();
                }
            }
        }
        private class ActiveEdge : IComparable<ActiveEdge>
        {
            public int Ymax { get; }
            public double X { get; private set; }
            public double XIncrement { get; }
            public int Id { get; }

            public ActiveEdge(Point p1, Point p2, int id)
            {
                Ymax = Math.Max(p1.Y, p2.Y);
                X = p1.Y < p2.Y ? p1.X : p2.X;
                XIncrement = p1.Y == p2.Y ? 0 : (double)(p1.X - p2.X) / (p1.Y - p2.Y);
                Id = id;
            }

            public void Increment()
            {
                X += XIncrement;
            }

            public int CompareTo(ActiveEdge other)
            {
                return this.X - other.X == 0 ? 0 :
                (this.X - other.X < 0 ? -1 : 1);
            }
        }

        private static void drawLine(Point p1, Point p2, Action<int, int> setPixel)
        {
            //Point p1 = new Point((int)point1.X, (int)point1.Y);
            //Point p2 = new Point((int)point2.X, (int)point2.Y);

            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            int x = p1.X;
            int y = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            setPixel(x,y);
            //[0, pi/4)
            if (dx > 0 && dy >= 0 && dy < dx)
            {
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);

                while (x < x2)
                {
                    x++;
                    if (d < 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrNE;
                        y++;
                    }
                    setPixel(x,y);
                }
            }
            //[pi/4, pi/2)
            else if (dx > 0 && dy > 0 && dy >= dx)
            {
                int d = dy - 2 * dx;
                int incrN = -2 * dx;
                int incrNE = 2 * (dy - dx);

                while (y < y2)
                {
                    y++;
                    if (d > 0)
                    {
                        d += incrN;
                    }
                    else
                    {
                        d += incrNE;
                        x++;
                    }
                    setPixel(x,y);
                }
            }
            //[pi/2, 3pi/4)
            else if (dx <= 0 && dy > 0 && dy >= -dx)
            {
                int d = -dy - 2 * dx;
                int incrN = -2 * dx;
                int incrNW = -2 * dy - 2 * dx;

                while (y < y2)
                {
                    y++;
                    if (d < 0)
                    {
                        d += incrN;
                    }
                    else
                    {
                        d += incrNW;
                        x--;
                    }
                    setPixel(x,y);
                }
            }
            //[3pi/4, pi)
            else if (dx < 0 && dy > 0 && dy <= -dx)
            {
                int d = -2 * dy - dx;
                int incrW = -2 * dy;
                int incrNW = -2 * dy - 2 * dx;

                while (x > x2)
                {
                    x--;
                    if (d > 0)
                    {
                        d += incrW;
                    }
                    else
                    {
                        d += incrNW;
                        y++;
                    }
                    setPixel(x,y);
                }
            }
            //[pi, 5pi/4)
            else if (dx < 0 && dy <= 0 && dy > dx)
            {
                int d = -2 * dy + dx;
                int incrW = -2 * dy;
                int incrSW = -2 * dy + 2 * dx;

                while (x > x2)
                {
                    x--;
                    if (d < 0)
                    {
                        d += incrW;
                    }
                    else
                    {
                        d += incrSW;
                        y--;
                    }
                    setPixel(x,y);
                }
            }
            //[5pi/4, 3pi/2)
            else if (dx < 0 && dy < 0 && dy <= dx)
            {
                int d = -dy + 2 * dx;
                int incrS = 2 * dx;
                int incrSW = -2 * dy + 2 * dx;

                while (y > y2)
                {
                    y--;
                    if (d > 0)
                    {
                        d += incrS;
                    }
                    else
                    {
                        d += incrSW;
                        x--;
                    }
                    setPixel(x, y);
                }
            }
            //[3pi/2, 7pi/4)
            else if (dx >= 0 && dy < 0 && -dy > dx)
            {
                int d = dy + 2 * dx;
                int incrS = 2 * dx;
                int incrSE = 2 * dy + 2 * dx;

                while (y > y2)
                {
                    y--;
                    if (d < 0)
                    {
                        d += incrS;
                    }
                    else
                    {
                        d += incrSE;
                        x++;
                    }
                    setPixel(x, y);
                }
            }
            //[7pi/4, 2pi)
            else if (dx > 0 && dy < 0 && -dy <= dx)
            {
                int d = 2 * dy + dx;
                int incrE = 2 * dy;
                int incrSE = 2 * dy + 2 * dx;

                while (x < x2)
                {
                    x++;
                    if (d > 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrSE;
                        y--;
                    }
                    setPixel(x, y);
                }
            }
        }
    }
}
