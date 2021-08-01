using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleApi.Contracts
{
    public interface IVertexService
    {

       IEnumerable<ITriangle> GetAllVertex();

        ITriangle GetTriangleByLabel(string label);

        ITriangle GetTriangleByVertex(IVertex[] vertices);

    }
}
