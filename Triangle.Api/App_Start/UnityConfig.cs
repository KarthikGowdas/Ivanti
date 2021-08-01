using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TriangleApi.Contracts;
using TriangleApi.Models;
using TriangleApi.Service;
using TriangleApi.Services;
using Unity;

namespace TriangleApi.App_Start
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });


        public static IUnityContainer Container => container.Value;


       
        public static void RegisterTypes(IUnityContainer container)
        {
            
            container.RegisterType<IVertex,Vertex>();
            container.RegisterType<ITriangle,Triangle>();
            container.RegisterType<IVertexService,VertexService>(TypeLifetime.Singleton);
            container.RegisterType<IVertexGeneratorService,TriangleVertexGenerator>();

        }
    }
}