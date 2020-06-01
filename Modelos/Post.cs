using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.XPath;

namespace api.Modelos
{
    public class Post
    {
        [Key]
        public int postId{get;set;} //poner termino ID va a ser tomad como llave
        [Required(ErrorMessage="Debe ingresar el nombre del autor.")]
        //[DataType(DataType.Text)]
        public string creador {get;set;}
        public string titulo {get;set;}
        public string contenido {get;set;}
        [Required]
        //[Datetype (DataType.Date)]
        public DateTime fecha {get;set;}
    
    }
    
}
