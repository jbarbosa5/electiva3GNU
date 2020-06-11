using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using api.Modelos;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // http://localhost:5000/api/blogs ojo aqui se define el enrutamiento
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
            var lista = db.blogs.ToList();
            return lista;
        }

        //http://localhost:5000/api/blogs/1
        [HttpGet("{id}")] // Un objeto con identificado (llave id)
        public ActionResult<string> GetBlogs(int id){

            // var resultado = db.Blogs.
            return "valor";
        }
    }
}