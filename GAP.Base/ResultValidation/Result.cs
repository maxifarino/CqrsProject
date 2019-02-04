using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.ResultValidation
{
    public class Result
    {
        private List<string> errors = new List<string>();
        private List<string> warnings = new List<string>();


        public List<string> Errors
        {
            get
            {
                return errors;
            }

        }

        public List<string> Warnings
        {
            get
            {
                return warnings;
            }

        }

        public bool success { get { return !this.HasError(); } }

        public bool withWarnings { get { return this.HasWarning(); } }


        public List<object> Data { get; set; }
        public void Resolve(object value)
        {
            if (value != null)
            {
                if (value.GetType().IsArray)
                {
                    object[] arrayData = (object[])value;
                    var dataSuccess = arrayData.GetValue(0);
                    if (dataSuccess is String)
                    {
                        var option = dataSuccess.ToString();
                        switch (option.ToLower())
                        {
                            case "error":
                                AddError(arrayData.GetValue(1).ToString());
                                break;
                            case "warning":
                                AddWarning(arrayData.GetValue(1).ToString());
                                break;
                        }
                        this.Data = arrayData.Skip(2).Take(arrayData.Length).ToList();
                    }
                    else
                    {
                        this.Data = new List<object>(arrayData);
                    }

                }
                else
                {
                    this.Data = new List<object>();
                    this.Data.Add(value);
                }
            }
        }

        /// <summary>
        /// No se debe permitir agregar textos duplicados.
        /// Para evitar problemas de iteración en javascript.
        /// </summary>
        /// <param name="error"></param>
        public void AddError(string error)
        {
            if (!errors.Contains(error))
            {
                errors.Add(error);
            }

        }

        public void AddWarning(string warning)
        {
            if (!warnings.Contains(warning))
            {
                warnings.Add(warning);
            }

        }

        public virtual bool HasWarning()
        {
            return warnings.Any();
        }

        public virtual bool HasError()
        {
            return errors.Any();
        }

        public void AddErrorsRange(IList<string> errors)
        {
            this.errors = this.errors.Union(errors).ToList<string>();
        }

        public void AddWarningsRange(IList<string> warnings)
        {
            this.warnings = this.warnings.Union(warnings).ToList<string>();
        }

        public List<string> GetErrors()
        {
            return this.errors;
        }

        public Object GetDataValue(int index)
        {
            if (index < this.Data.Count)
            {
                return this.Data.ElementAt(index);
            }
            else
            {
                return null;
            }
        }

    }
}
