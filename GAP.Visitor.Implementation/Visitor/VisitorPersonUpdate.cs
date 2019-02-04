
using GAP.Domain.Entities;
using GAP.Domain.IVisitor;
using GAP.Repository.LocalScheme;
using GAP.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.Visitor
{
    public class VisitorPersonUpdate : IVisitorPerson
    {
        private readonly IRepository _repositryLocalScheme;

        public VisitorPersonUpdate(RepositoryLocalScheme irepository)
        {
            _repositryLocalScheme = irepository;
        }

        public override void Visit(Person person)
        {
            
            if (string.IsNullOrEmpty(person.Name))
                Console.WriteLine("The Name is a value Requered");

            //if (string.IsNullOrEmpty(person.LastName))
            //    Console.WriteLine("The LastName is a value Requered");

        }

        public override void Visit(Address address)
        {
            if (string.IsNullOrEmpty(address.City))
                Console.WriteLine("The City is a value Requered");
        }
    }
}
