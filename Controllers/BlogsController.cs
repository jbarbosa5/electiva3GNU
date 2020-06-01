using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using api.Modelos;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // http://localhost:5000/api/blogs
    public class BlogsController : ControllerBase
    {
        protected readonly ApiContext db;

        //Constructor
        public BlogsController(ApiContext context)
        {
            db = context;
        }

        [HttpGet] //Lista de objetos
        public ActionResult<IEnumerable<Blog>> Get(){
            //return new string[] { "value1", "value2" };
            var lista = db.Blogs.ToList();
            return lista;
        }

        //localhost:4564/api/Blogs/1
        [HttpGet("{id}")] // Un objeto con identificado (llave id)
        public ActionResult<string> GetBlogs(int id){

            // var resultado = db.Blogs.
            return "valor";
        }
    }
}