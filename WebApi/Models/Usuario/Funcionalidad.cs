using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Usuario
{
    public class Funcionalidad
    {
        public int Id { get; set; }

        public String Nombre { get; set; }

        public String Path { get; set; }

        public int IdPadre { get; set; }
        
    }
}