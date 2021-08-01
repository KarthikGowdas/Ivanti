using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using TriangleApi.Contracts;
using TriangleApi.Models;
using Unity;

namespace TiangleApi.Controllers
{
    public class VertexController : ApiController
    {

        [Dependency]
        public IVertexService VertexService { get; set; }

        public VertexController()
        {
        }

        [Route("api/GetAllTrianglesVertex")]
        [HttpGet]
        public IHttpActionResult GetAllTriangleVertex()
        {
            try
            {
                IEnumerable<ITriangle> result = VertexService.GetAllVertex();

                return Ok(result);
            }
            catch(Exception ex)
            {
                Debugger.Log(1, "Error", ex.Message);
                return NotFound();
            }
           
        }

        [HttpPost]
        [Route("api/GetTriangleByVertices")]
        public IHttpActionResult GetTriangleByVertices(Vertex[] vertices)
        {
            try
            {

                if (vertices == null || vertices.Length != 3)
                    return BadRequest("Invalid Request");

                ITriangle triangle = VertexService.GetTriangleByVertex(vertices);
                return Ok(triangle);
            }
            catch (Exception ex)
            {
                Debugger.Log(1, "Error", ex.Message);
                return NotFound();
            }
        }


        [HttpGet]
        [Route("api/GetTriangleByLabel")]
        public IHttpActionResult GetTriangleByLabel(string lable)
        {
            if (string.IsNullOrEmpty(lable) || string.IsNullOrWhiteSpace(lable))
                return BadRequest("Invalid Triangle Label");

            lable = lable.Trim().ToUpper();

            try
            {
                ITriangle triangle = VertexService.GetTriangleByLabel(lable);
                return Ok(triangle);
            }
            catch(Exception ex)
            {
                Debugger.Log(1,"Error",ex.Message);
                return NotFound();
            }

           
        }

    }
}
