using Microsoft.EntityFrameworkCore;
using api.Modelos;
using System;


namespace api.Modelos
{
    public class ApiContext:DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options) : base(options){
            //PoblarDatos();
            Database.EnsureCreated();
            //Database.Migrate();
        }
        
        public DbSet<Blog> blogs  {get; set; } //mapea tabla en la bbdd

        protected override void OnModelCreating(ModelBuilder builder){ //Seeders o FactoryModel
            //Fluent API Ef Core
            builder.Entity<Blog>().ToTable("Blogs");
            builder.Entity<Blog>().HasKey(blog=>blog.id)/*.ValueGenerated.OnAdd()*/;
            builder.Entity<Blog>().Property(blog=>blog.nombre).HasMaxLength(50);

            builder.Entity<Blog>().HasData(
                new Blog{
                    id=1,
                    nombre="Blog de Fulano",
                    autor="Fulano"
                },
                new Blog{
                    id=2,
                    nombre="Blog de Sutano",
                    autor="Sutano"
                },
                new Blog{
                    id=3,
                    nombre="Blog de Juliana",
                    autor="Juliana"
                }
            );
        }

        
        private void PoblarDatos(){                  //seeders
           /*  this.blogs.Add(                         //Add funcion agregar a lista
                new Blog{
                    id=1,
                    nombre="Blog de Fulano",
                    autor="Fulano"
                }
            );
            this.blogs.Add(
                new Blog{
                    id=2,
                    nombre="Blog de Sutano",
                    autor="Sutano"
                }
            );
            this.SaveChanges(); */
        }
    }
}