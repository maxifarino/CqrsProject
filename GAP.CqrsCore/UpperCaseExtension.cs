using GAP.Base;
using GAP.CqrsCore.Commands;
using GAP.CqrsCore.Querys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GAP.CqrsCore
{

    public static class UpperCaseExtensions
    {

        public static void UpperCase(this CommandDispatcher iCommandDispacher, object obj)
        {
            ToUpperCase(obj);
        }

        public static void UpperCase(this QueryDispatcher iCommandDispacher, object obj)
        {
            ToUpperCase(obj);
        }

        public static void ToUpperCase(object obj)
        {

            //       Antes de comenzar:
            //       Un buda para cuidar esta porción de código. (A. Stoll)
            //                           _
            //                        _ooOoo_
            //                       o8888888o
            //                       88" . "88
            //                       (| -_- |)
            //                       O\  =  /O
            //                    ____/`---'\____
            //                  .'  \\|     |//  `.
            //                 /  \\|||  :  |||//  \
            //                /  _||||| -:- |||||_  \
            //                |   | \\\  -  /'| |   |
            //                | \_|  `\`---'//  |_/ |
            //                \  .-\__ `-. -'__/-.  /
            //              ___`. .'  /--.--\  `. .'___
            //           ."" '<  `.___\_<|>_/___.' _> \"".
            //          | | :  `- \`. ;`. _/; .'/ /  .' ; |
            //          \  \ `-.   \_\_`. _.'_/_/  -' _.' /
            //===========`-.`___`-.__\ \___  /__.-'_.'_.-'================
            //                        `=--=-'                    

            if (obj != null)
            {
                Type customType = obj.GetType();
                foreach (PropertyInfo pi in customType.GetProperties())
                {
                    //verifico si la propiedad tiene especificado el custom attribute
                    var noCaps = pi.GetCustomAttribute(typeof(NoCAPSAttribute));
                    if (noCaps == null)
                    {
                        //si la propiedad es de tipo lista, debo recorrerla
                        if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            Type itemType = pi.PropertyType.GetGenericArguments()[0];
                            //solo itero si es entidad de negocio
                            if (itemType.Namespace.Equals("GAP.Domain.Entities"))
                            {
                                IEnumerable listaElementos = (IEnumerable)pi.GetValue(obj, null);
                                foreach (var item in listaElementos)
                                {
                                    //llamo recursivamente
                                    ToUpperCase(item);
                                }
                            }
                        }
                        //si es un objeto del namespace Entities, hacer recursividad para inspeccionarlo
                        if (pi.PropertyType.Namespace.Equals("GAP.Domain.Entities"))
                            //llamo recursivamente
                            ToUpperCase(pi.GetValue(obj, null));
                        else if (pi.PropertyType == typeof(String))
                        {
                            if (pi.GetCustomAttribute(typeof(NoCAPSAttribute)) == null)
                            {
                                var propertyValue = pi.GetValue(obj);
                                if (propertyValue != null)
                                    //seteo string a mayusculas
                                    pi.SetValue(obj, propertyValue.ToString().ToUpper(), null);
                            }
                        }
                    }
                }
            }
        }
    }
}
