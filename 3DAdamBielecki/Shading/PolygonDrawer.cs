using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdamBielecki.Shading
{
    public static class PolygonDrawer
    {
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
    }
}
