using GAP.Base.ResultValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Domain.IVisitor
{
    public abstract class VisitorBase:Result
    {
        /// <summary>
        /// this method will inject the element to the corresponding method of father class
        /// </summary>
        /// <param name="element"></param>
        public void Visit(Object element)
        {
            MethodInfo downPolymorphic = this.GetType().GetMethod("Visit", new Type[] { element.GetType() });

            if (downPolymorphic != null)
                downPolymorphic.Invoke(this, new Object[] { element });
        }
    }
}
