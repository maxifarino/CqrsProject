using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Command.InmueblePackage
{
    public class InmuebleSaveCommand : ICommand
    {
        public Inmueble Inmueble { get; set; }
        public int SalaCunaId { get; set; }
        public int UsuarioLogueadoId { get; set; }
    }
}
