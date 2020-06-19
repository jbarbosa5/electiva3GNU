using System.Net;
using System.Data.Common;
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
        public ActionResult<string> GetBlogs([FromRoute] int categoriaId){

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
                return BadRequest();

            }
            
            db.blogs.Add(blog);
            await db.SaveChangesAsync();

            return Ok();

        }

        //suple el paraemtro route con rutas personalizadas
        //[Route("~/api/blogs/{id}")]
        //[HttpDelete]


        //recibe un parametro y borra 
        [HttpDelete("{id}")]
        public ActionResult eliminarBlog(int id)
        {
            Blog existe=db.blogs.Find(id);
            if(existe ==null){
                return NotFound();
            }
            db.blogs.Remove(existe);
            db.SaveChanges();
            return Ok();
        }

        //[Route("~/api/blogs/{id}")]
        [HttpPut("{id}")]
        public ActionResult editarBlog(/* [FromRoute] */ int id, [FromBody] Blog blog){
            //valida la información y contrarestar CSRF
            if(id!=blog.id){
                return BadRequest();
            }
            //valida que el ID no se cambia
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 

            //Existe?
            Blog existe=db.blogs.Find(id);
            if(existe ==null){
                return NotFound();
            }

            //modifica, actualiza y commit
            db.Entry(blog).State=EntityState.Modified;
            db.Update(blog);
            db.SaveChanges();

            return Ok();


        }
    }
}