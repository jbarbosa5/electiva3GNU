using Microsoft.EntityFrameworkCore;
using api.Modelos;
using System;


namespace api.Modelos
{
    public class ApiContext:DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options) : base(options){}
        
        public DbSet<Blog> Blogs  {get; set; } //mapea tabla en la bbdd
        
    }
}