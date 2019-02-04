using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GAP.Base
{
    public class ContextSingleton
    {
        private static ContextSingleton instance;

        public string TempReportsPath { get; private set; }
        public string BaseUrl { get; private set; }
        public string ApplicationPath { get; private set; }

        private ContextSingleton() { }

        private ContextSingleton(string _tempReportsPath, string _applicationPath) 
        {
            TempReportsPath = _tempReportsPath;
            ApplicationPath = _applicationPath;
        }

        public static ContextSingleton Instance
        {
            get{
                return instance;
            }
        }

        public static ContextSingleton InitInstance(string _tempReportsPath, string _applicationPath)
        {
            if (instance == null)
                instance = new ContextSingleton(_tempReportsPath, _applicationPath);
            return instance;
        }

        public static ContextSingleton InitBaseUrl()
        {
            if (instance != null && String.IsNullOrEmpty(instance.BaseUrl))
            {
                string _baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                    HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
                instance.BaseUrl = _baseUrl;
            }
            return instance;
        }
    }
}
