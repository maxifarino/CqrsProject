
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
    /// <summary>
    /// This module will validate requered data, as well also business rules
    /// </summary>
    public class VisitorPersonSave : IVisitorPerson
    {
        
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        public VisitorPersonSave(RepositoryLocalScheme irepository)
        {
            _repositryLocalScheme = irepository;
        }

        public override void Visit(Person person)
        {
            if (string.IsNullOrEmpty(person.Name))
                this.AddError("The Name is a value Requered ");

            
            if(!string.IsNullOrEmpty(person.Name) && existPersonByNombre(person.Name))
                this.AddError("the Person exist on Data Base");

            //if (string.IsNullOrEmpty(person.LastName))
            //    this.AddError("The LastName is a value Requered");

            //if (person.Address == null)
            //    this.AddError("The Address is a value Requered");
        }

        public override void Visit(Address address)
        {
            if (string.IsNullOrEmpty(address.City))
                this.AddError("The City is a value Requered");
        }

        public virtual bool existPersonByNombre(string name)
        {
            return ((_repositryLocalScheme.Session.QueryOver<Person>().Where(x => x.Name == name)) != null);
        }

    }
}
