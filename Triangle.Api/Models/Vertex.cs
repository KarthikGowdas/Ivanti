using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TriangleApi.Contracts;

namespace TriangleApi.Models
{
    public class Vertex : IVertex
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Vertex()
        {

        }

        public Vertex(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Vertex)
            {
                Vertex v = obj as Vertex;
                bool result = v.X == X & v.Y == Y;
                return result;

            }
            else
                return false;

        }

        public override int GetHashCode()
        {
            return Tuple.Create(X, Y).GetHashCode();
        }
    }
}