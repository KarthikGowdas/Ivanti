using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TriangleApi.Contracts;
using TriangleApi.Models;

namespace TriangleApi.Services
{
    public class Builder : IPolygonBuilder<ITriangle>
    {
        private ITriangle triangle { get; set; }
        private IList<IVertex> vertices { get; set; }


        public Builder()
        {
            vertices = new List<IVertex>();
        }


        public IPolygonBuilder<ITriangle> AddVertex(int x, int y)
        {
            vertices.Add(new Vertex(x, y));
            return this;
        }

        public ITriangle Build()
        {
            if (vertices.Count != 3)
            {
                throw new InvalidOperationException("Invalid vertex count to create a triangle");
            }

            return new Triangle(vertices[0], vertices[1], vertices[2]);
        }



    }
}