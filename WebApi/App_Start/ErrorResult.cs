using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.App_Start
{
    public class ErrorResult
    {
        public List<string> Errors { get; set; }
        public string Error { get; set; }
    }
}