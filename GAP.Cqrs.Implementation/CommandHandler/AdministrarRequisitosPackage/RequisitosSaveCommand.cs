using GAP.CqrsCore.Commands;
using GAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Command.AdministrarRequisitos
{
  public class RequisitosSaveCommand : ICommand
    {
      public List<Requisito> ListaRequisitos { get; set; }
      public int idUsuarioLogueado { get; set; }
    }
}
