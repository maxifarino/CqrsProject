using System;
using GAP.CqrsCore.Commands;
using Castle.Windsor;
using GAP.Base.ResultValidation;
using System.Reflection;
using GAP.Base;
using System.Collections.Generic;
using System.Collections;

namespace GAP.CqrsCore.Commands
{
    /// <summary>
    /// this module, has responsability to execute the commandHandler switch the TParameter type that implement
    /// </summary>
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IWindsorContainer _container;

        public CommandDispatcher(IWindsorContainer container)
        {
            this._container = container;
        }

        public virtual Result Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            
            this.UpperCase(command);
            var handler = this._container.Kernel.Resolve<ICommandHandler<TParameter>>();
            return handler.Execute(command);
        }

        ///// <summary>
        ///// Inspects recursively, every string property and changes it to upper case, 
        ///// except those that have a NoCAPS custom attribute. Uses reflection.
        ///// </summary>
        ///// <param name="obj">Object to inspect</param>
        //private void ToUpperCase(object obj)
        //{              
        //            //       Antes de comenzar:
        //            //       Un buda para cuidar esta porción de código. (A. Stoll)
        //            //                           _
        //            //                        _ooOoo_
        //            //                       o8888888o
        //            //                       88" . "88
        //            //                       (| -_- |)
        //            //                       O\  =  /O
        //            //                    ____/`---'\____
        //            //                  .'  \\|     |//  `.
        //            //                 /  \\|||  :  |||//  \
        //            //                /  _||||| -:- |||||_  \
        //            //                |   | \\\  -  /'| |   |
        //            //                | \_|  `\`---'//  |_/ |
        //            //                \  .-\__ `-. -'__/-.  /
        //            //              ___`. .'  /--.--\  `. .'___
        //            //           ."" '<  `.___\_<|>_/___.' _> \"".
        //            //          | | :  `- \`. ;`. _/; .'/ /  .' ; |
        //            //          \  \ `-.   \_\_`. _.'_/_/  -' _.' /
        //            //===========`-.`___`-.__\ \___  /__.-'_.'_.-'================
        //            //                        `=--=-'                    

        //    if (obj != null)
        //    {
        //        Type customType = obj.GetType();
        //        foreach (PropertyInfo pi in customType.GetProperties())
        //        {
        //            //verifico si la propiedad tiene especificado el custom attribute
        //            var noCaps = pi.GetCustomAttribute(typeof(NoCAPSAttribute));
        //            if (noCaps == null)
        //            {
        //                //si la propiedad es de tipo lista, debo recorrerla
        //                if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
        //                {
        //                    Type itemType = pi.PropertyType.GetGenericArguments()[0];
        //                    //solo itero si es entidad de negocio
        //                    if (itemType.Namespace.Equals("GAP.Domain.Entities"))
        //                    {
        //                        IEnumerable listaElementos = (IEnumerable)pi.GetValue(obj, null);
        //                        foreach (var item in listaElementos)
        //                        {
        //                            //llamo recursivamente
        //                            ToUpperCase(item);
        //                        }
        //                    }
        //                }
        //                //si es un objeto del namespace Entities, hacer recursividad para inspeccionarlo
        //                if (pi.PropertyType.Namespace.Equals("GAP.Domain.Entities"))    
        //                    //llamo recursivamente
        //                    ToUpperCase(pi.GetValue(obj, null));
        //                else if (pi.PropertyType == typeof(String))
        //                {
        //                    var propertyValue = pi.GetValue(obj);
        //                    if (propertyValue != null)
        //                        //seteo string a mayusculas
        //                        pi.SetValue(obj, propertyValue.ToString().ToUpper(), null);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}