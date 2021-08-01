using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TriangleApi.App_Start;
using Unity.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TriangleApi.App_Start.UnityWebApiActivator), nameof(TriangleApi.App_Start.UnityWebApiActivator.Init))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(TriangleApi.App_Start.UnityWebApiActivator), nameof(TriangleApi.App_Start.UnityWebApiActivator.Destroy))]
namespace TriangleApi.App_Start
{
    public static class UnityWebApiActivator
    {
        public static void Init()
        {
            var resolver = new UnityDependencyResolver(UnityConfig.Container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        public static void Destroy()
        {
            UnityConfig.Container.Dispose();
        }

    }
}