using System;
using System.ComponentModel.DataAnnotations;

namespace api.Modelos
{
    public class Blog
    {
        [Required]
        public int id {get;set;}
        public string nombre {get;set;}
        public string autor {get;set;}
    }
}

