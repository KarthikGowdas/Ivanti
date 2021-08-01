using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleApi.Contracts
{
    public interface IPolygon
    {

        IList<IVertex> Vertices { get; set; }

    }
}
