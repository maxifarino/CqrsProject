

using GAP.Base.ResultValidation;
using GAP.Domain;
using GAP.Domain.IVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Visitor.Implementation.ServiceBusinessStructure
{
    public abstract class ServiceBusinessEstructureBase<TEntity> : ElementBase where TEntity : ElementBase
    {
        private IList<ElementBase> listElement;
        private IList<List<TEntity>> listElements;

        public Result result;

        public ServiceBusinessEstructureBase()
        {
            listElement = new List<ElementBase>();
            listElements = new List<List<TEntity>>();

            result = new Result();
        }

        /// <summary>
        /// will execute the visitor class passed as parameter, to all the elements
        /// </summary>
        /// <param name="visitor"></param>
        public override void Accept(VisitorBase visitor)
        {
            foreach (var element in listElement)
            {
                if (element != null)
                {
                    element.Accept(visitor);
                    if (visitor.HasError())
                        result.AddErrorsRange(visitor.GetErrors());
                }
            }

            foreach (var element in listElements)
            {
                if (element != null)
                {
                    visitor.Visit(element);
                    if (visitor.HasError())
                        result.AddErrorsRange(visitor.GetErrors());
                }
            }
        }

        /// <summary>
        /// This method, add elements to validate
        /// </summary>
        /// <param name="element"></param>
        public void addElementoToValidate(ElementBase element)
        {
            this.listElement.Add(element);
        }

        public void addElementoToValidate(List<TEntity> elements)
        {
            this.listElements.Add(elements);
        }

        public virtual Result ValidateSave(TEntity element) { return result; }

        public virtual Result ValidateSave(List<TEntity> element) { return result; }

        public virtual Result ValidateUpdate(TEntity element) { return result; }

        public virtual Result ValidateDelete(TEntity element) { return result; }

        public virtual void ValidateDeleteFisic(TEntity element) { }

    }
}
