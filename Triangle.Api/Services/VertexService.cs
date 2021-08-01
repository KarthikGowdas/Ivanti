using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleApi.Contracts;
using TriangleApi.Util;
using Unity;

namespace TriangleApi.Service
{
    public class VertexService : IVertexService
    {
        const int ROWSIZE = 6;
        const int COLSIZE = 6;
        
        private IVertexGeneratorService VertexGenerator;

        private ConcurrentDictionary<string,ITriangle> dataSource { get; set; }


        public VertexService(IVertexGeneratorService vertexGenerator)
        {
            this.VertexGenerator = vertexGenerator;
            dataSource = VertexGenerator.GenerateVertex(ROWSIZE,COLSIZE).ConvertToKeyValuePair();
        }


        public IEnumerable<ITriangle> GetAllVertex()
        {
            if (dataSource == null && dataSource.Count == 0)
            {
                throw new NullReferenceException("Source Collection is empty");
            }
            return dataSource.Where(row =>  row.Key.IsNumber() == false).Select(row => row.Value).OrderBy(row => row, new TriangleComparer());
        }


        public ITriangle GetTriangleByLabel(string label)
        {
            if (dataSource == null && dataSource.Count == 0)
            {
                throw new NullReferenceException("Source Collection is empty");
            }

            if (string.IsNullOrEmpty(label) || string.IsNullOrWhiteSpace(label))
                throw new ArgumentNullException("Label cannot be null or empty");

            label = label.Trim().ToUpper();

            if (!dataSource.ContainsKey(label))
                throw new KeyNotFoundException("Label not found");


            var result = dataSource[label];
            return result;
        }

        public ITriangle GetTriangleByVertex(IVertex[] vertices)
        {
            if (dataSource == null && dataSource.Count == 0)
            {
                throw new NullReferenceException("Source Collection is empty");
            }

            if (vertices == null || vertices.Length <= 0)
                throw new ArgumentNullException("Label cannot be null or empty");


            int hashSum = vertices.Sum(row => row.GetHashCode());

            if (!dataSource.ContainsKey(hashSum.ToString()))
                throw new KeyNotFoundException("Verticex not found");

            var result = dataSource[hashSum.ToString()];
            return result;

        }
    }
}
