using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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
        [HttpGet("{categoriaId}")] // Un objeto con identificado (llave id)
        public ActionResult<string> GetBlogs(int categoriaId){

            var resultado = db.blogs.Find(categoriaId);
            if(resultado==null){
                return NotFound(); //no encuentra ID devulve 404
            }
            return Ok(resultado);
        }
        //recibe un parametro de la pagina 
        [HttpPost]
        public async Task<IActionResult> CrearBlog([FromBody] Blog blog){

            if(!ModelState.IsValid){
                //si es valida


            }
            
            var guardado=db.blogs.Add(blog);
            await db.SaveChangesAsync();

            return new CreatedAtRouteResult("GetBlogs",new {categoriaId=blog.id});

        }


        [HttpPut("id")]
        public async Task<IActionResult> EditarBlog([FromRoute] int id, [FromBody] BlogsController blog){
            //valida la información
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            //valida que el ID no se cambia
            /* if(id != blog.id){
                return BadRequest();
            } */

            db.Entry(blog).State=EntityState.Modified;

            db.Update(blog);
            await db.SaveChangesAsync();

            return Redirect("Get");


        }
    }
}