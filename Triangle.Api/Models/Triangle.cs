using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TriangleApi.Contracts;

namespace TriangleApi.Models
{
    public class Triangle : ITriangle
    {
        public string Label { get; set; }
        public IList<IVertex> Vertices { get; set; }

        public Triangle(IVertex V0, IVertex V1, IVertex V2)
        {
            Vertices = new List<IVertex>();
            Vertices.Add(V0);
            Vertices.Add(V1);
            Vertices.Add(V2);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Triangle)
            {
                Triangle t = obj as Triangle;
                if (t.Vertices.Sum(row => row.GetHashCode()) == this.Vertices.Sum(row => row.GetHashCode()) && Label == t.Label)
                    return true;

            }

            return false;
        }

        public override int GetHashCode()
        {
            return Vertices.Sum(row => row.GetHashCode());
        }




    }
}