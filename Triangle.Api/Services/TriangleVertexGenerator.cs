using System;
using System.Collections.Generic;
using TriangleApi.Contracts;
using TriangleApi.Services;
using TriangleApi.Util;
using Unity;

namespace TriangleApi.Service
{
    public class TriangleVertexGenerator : IVertexGeneratorService
    {



        public IEnumerable<IPolygon> GenerateVertex(int RowSize, int ColSize)
        {
           List<ITriangle> triangles = new List<ITriangle>();
            if ((RowSize <= 0 && ColSize <= 0) || (RowSize != ColSize))
                throw new ArgumentException("Invalid Row and Column value to generate vertex");


            string alphabet = string.Empty;
           
            for (int i = 0; i < RowSize; i++)
            {
                int cellCounter = 1;
                alphabet = alphabet.GetNextAlphabet();
                for (int j = 0; j < ColSize; j++)
                {
                    ITriangle evenTriangle = new Builder()
                                 .AddVertex(j, i)
                                 .AddVertex(j + 1, i)
                                 .AddVertex(j + 1, i + 1)
                                 .Build();
                    evenTriangle.Label = alphabet + (cellCounter + 1); 

                    ITriangle oddTriangle = new Builder()
                                  .AddVertex(j, i)
                                  .AddVertex(j, i + 1)
                                  .AddVertex(j + 1, i + 1)
                                  .Build();
                    oddTriangle.Label = alphabet + cellCounter;

                    triangles.Add(oddTriangle);
                    triangles.Add(evenTriangle);
                    cellCounter +=2 ;
                }
            }

            return triangles;
        }


    }
}