using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.AttributeCustom
{
    public class CallSpAttribute : Attribute
    {
        public string NameSp { get; set; }
    }


    public static class GetAttributeFromEnum
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)

        where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }
    }

}
