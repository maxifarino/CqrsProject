using GAP.Base.Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.App_Start.Security
{
    public class FuncionalidadesSingleton
    {

        private static FuncionalidadesSingleton instance;

        IDictionary<string, IDictionary<string,Int16>> funcionalidades;

        private FuncionalidadesSingleton() 
        {
            funcionalidades = new Dictionary<string, IDictionary<string, Int16>>();
        }

        public static FuncionalidadesSingleton Instance
        {
            get 
            {
                if(instance == null)
                {
                    instance = new FuncionalidadesSingleton();
                }
                return instance;
            }
        }

        public void replaceFuncionalidades(string perfilId, List<FuncionalidadDto> funcionalidades)
        {
            IDictionary<string, Int16> pathHash = new Dictionary<string, Int16>();
            foreach (FuncionalidadDto funcionalidad in funcionalidades)
            {
                if (!pathHash.ContainsKey(funcionalidad.Path.ToUpper()))
                    pathHash.Add(funcionalidad.Path.ToUpper(), 0);
            }
            this.funcionalidades[perfilId] = pathHash;
        }

        public bool tienePermisos(string perfilId, string recurso)
        {
            if (funcionalidades != null && funcionalidades.Any())
            {
                IDictionary<string, Int16> pathHash = funcionalidades[perfilId];
                return pathHash != null && pathHash.ContainsKey(recurso.ToUpper());
            }
            return false;
        }
    }
}