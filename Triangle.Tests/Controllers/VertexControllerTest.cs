using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using TiangleApi.Controllers;
using TriangleApi.Contracts;
using TriangleApi.Models;

namespace TriangleApiTests.Controllers
{
    [TestClass]
    public class VertexControllerTest
    {



        [TestMethod]
        public void GetAllTriangleByVertexTest()
        {


            List<ITriangle> mockList = new List<ITriangle>();
            mockList.Add(new Triangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1)));
            mockList.Add(new Triangle(new Vertex(0, 0), new Vertex(0, 1), new Vertex(1, 1)));
            mockList.Add(new Triangle(new Vertex(0, 1), new Vertex(1, 1), new Vertex(1, 2)));
            mockList.Add(new Triangle(new Vertex(0, 1), new Vertex(0, 2), new Vertex(1, 2)));
            mockList.Add(new Triangle(new Vertex(0, 2), new Vertex(1, 2), new Vertex(1, 3)));
            mockList.Add(new Triangle(new Vertex(0, 2), new Vertex(0,3), new Vertex(1, 3)));

            var VertexServiceMoc = new Mock<IVertexService>();
            VertexServiceMoc.Setup(prop => prop.GetAllVertex()).Returns(mockList);

            VertexController vertexController = new VertexController();
            vertexController.VertexService = VertexServiceMoc.Object;
            vertexController.Request = new System.Net.Http.HttpRequestMessage();
            vertexController.Configuration = new HttpConfiguration();

            IHttpActionResult response = vertexController.GetAllTriangleVertex();

            var contentResult = response as OkNegotiatedContentResult<IEnumerable<ITriangle>>;

            Assert.IsNotNull(response);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(mockList.Count, (contentResult.Content as List<ITriangle>).Count);
        }


        [TestMethod]
        public void GetTriangleByVertexTest()
        {

            Vertex[] RequestPrameterMock = new Vertex[] { new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1) };
            Triangle triangleResponseMock = new Triangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1)) { Label = "A1" };
            Vertex[] RequestPrameter = new Vertex[] { new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1) };

            var VertexServiceMoc = new Mock<IVertexService>();
            VertexServiceMoc.Setup(prop => prop.GetTriangleByVertex(RequestPrameterMock)).Returns(triangleResponseMock);

            VertexController vertexController = new VertexController();
            vertexController.VertexService = VertexServiceMoc.Object;
            vertexController.Request = new System.Net.Http.HttpRequestMessage();
            vertexController.Configuration = new HttpConfiguration();

            IHttpActionResult response = vertexController.GetTriangleByVertices(RequestPrameter);

            var contentResult = response as OkNegotiatedContentResult<ITriangle>;

            Assert.IsNotNull(response);
            Assert.IsNotNull(contentResult.Content);
            var apiResponse = contentResult.Content as ITriangle;
            Assert.IsNotNull(apiResponse);
            Assert.AreEqual(triangleResponseMock.Label, apiResponse.Label);
            Assert.AreEqual(triangleResponseMock.GetHashCode(), apiResponse.GetHashCode());
        }


        [TestMethod]
        public void GetTriangleByLabelTest()
        {

            string RequestPrameterMock = "A1";
            Triangle triangleResponseMock = new Triangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1)) { Label = "A1" };
            string RequestPrameter = "A1";

            var VertexServiceMoc = new Mock<IVertexService>();
            VertexServiceMoc.Setup(prop => prop.GetTriangleByLabel(RequestPrameterMock)).Returns(triangleResponseMock);

            VertexController vertexController = new VertexController();
            vertexController.VertexService = VertexServiceMoc.Object;
            vertexController.Request = new System.Net.Http.HttpRequestMessage();
            vertexController.Configuration = new HttpConfiguration();

            IHttpActionResult response = vertexController.GetTriangleByLabel(RequestPrameter);

            var contentResult = response as OkNegotiatedContentResult<ITriangle>;

            Assert.IsNotNull(response);
            Assert.IsNotNull(contentResult.Content);
            var apiResponse = contentResult.Content as ITriangle;
            Assert.IsNotNull(apiResponse);
            Assert.AreEqual(triangleResponseMock.Label, apiResponse.Label);
            Assert.AreEqual(triangleResponseMock.GetHashCode(), apiResponse.GetHashCode());

        }

        [TestMethod]
        public void GetTriangleByInvalidVertexTest()
        {
            Vertex[] RequestPrameterMock = new Vertex[] { new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1) };
            Triangle triangleResponseMock = new Triangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1)) { Label = "A1" };
            Vertex[] RequestPrameter = new Vertex[] { new Vertex(0, 0), new Vertex(1, 1), new Vertex(1, 1) };

            var VertexServiceMoc = new Mock<IVertexService>();
            VertexServiceMoc.Setup(prop => prop.GetTriangleByVertex(RequestPrameterMock)).Returns(triangleResponseMock);

            VertexController vertexController = new VertexController();
            vertexController.VertexService = VertexServiceMoc.Object;
            vertexController.Request = new System.Net.Http.HttpRequestMessage();
            vertexController.Configuration = new HttpConfiguration();

            IHttpActionResult response = vertexController.GetTriangleByVertices(RequestPrameter);

            var contentResult = response as OkNegotiatedContentResult<ITriangle>;

            Assert.IsNotNull(response);
            Assert.IsNull(contentResult.Content);
        }

        [TestMethod]
        public void GetTriangleByInvalidLabelTest()
        {
            string RequestPrameterMock = "A1";
            Triangle triangleResponseMock = new Triangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1)) { Label = "A1" };
            string RequestPrameter = "A3";

            var VertexServiceMoc = new Mock<IVertexService>();
            VertexServiceMoc.Setup(prop => prop.GetTriangleByLabel(RequestPrameterMock)).Returns(triangleResponseMock);

            VertexController vertexController = new VertexController();
            vertexController.VertexService = VertexServiceMoc.Object;
            vertexController.Request = new System.Net.Http.HttpRequestMessage();
            vertexController.Configuration = new HttpConfiguration();

            IHttpActionResult response = vertexController.GetTriangleByLabel(RequestPrameter);

            var contentResult = response as OkNegotiatedContentResult<ITriangle>;

            Assert.IsNotNull(response);
            Assert.IsNull(contentResult.Content);

        }

    }
}
