using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TriangleApi.Contracts
{
    public interface IPolygonBuilder<T> where T:IPolygon
    {

        IPolygonBuilder<T> AddVertex(int x, int y);

        T Build();

    }
}