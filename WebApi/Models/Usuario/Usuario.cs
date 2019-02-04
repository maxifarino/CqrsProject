using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Usuario
{
    public class Usuario
    {
        public int Id { get; set; }

        public Int64 Cuil { get; set; }

        public string NombreCompleto {
            get
            {
                return Apellido + ", " + Nombre;
            } 
        }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string NombreRol { get; set; }

        public List<Funcionalidad> funcionalidades { get; set; }
    }
}