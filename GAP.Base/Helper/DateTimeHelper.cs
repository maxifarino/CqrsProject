using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Helper
{
    public class DateTimeHelper
    {

        public static string GetShortDateTime(DateTime? dateTime)
        {
            if (dateTime != null && Different(dateTime, new DateTime()))
            {
                return dateTime.Value.ToShortDateString();
            }
            return String.Empty;
        }

        public static string GetFullDateAsString()
        {
            DateTime fecha = DateTime.Today;
            Int32 dia = fecha.Day;
            string mes = new DateTime(2015, fecha.Month, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            mes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mes);
            Int32 anio = fecha.Year;
            return dia + " de " + mes + " del " + anio;
        }

        public static DateTime GetMinDateTime()
        {
            return new DateTime(0001, 01, 01);
        }

        public static DateTime GetMinDateTimeNullable(DateTime? dateTime)
        {
            return dateTime != null && dateTime.HasValue ? dateTime.Value.Date : DateTimeHelper.GetMinDateTime();
        }

        /// <summary>
        /// Compara si una fecha es mayor a la otra.
        /// </summary>
        /// <param name="d1">Fecha minuendo.</param>
        /// <param name="d2">Fecha sustraendo.</param>
        /// <returns>True si el primer parámetro es posterior al segundo parámetro.</returns>
        public static bool After(DateTime? d1, DateTime? d2)
        {
            if (d1 == null || d2 == null)
                return false;
            return DateTime.Compare(d1.Value.Date, d2.Value.Date) > 0;
        }

        /// <summary>
        /// Compara si una fecha es mayor o igual a la otra.
        /// </summary>
        /// <param name="d1">Fecha minuendo.</param>
        /// <param name="d2">Fecha sustraendo.</param>
        /// <returns>True si el primer parámetro es posterior o igual al segundo parámetro.</returns>
        public static bool SameOrAfter(DateTime? d1, DateTime? d2)
        {
            if (d1 == null || d2 == null)
                return false;
            return DateTime.Compare(d1.Value.Date, d2.Value.Date) >= 0;
        }

        /// <summary>
        /// Compara si una fecha es menor o igual a la otra
        /// </summary>
        /// <param name="d1">Fecha minuendo.</param>
        /// <param name="d2">Fecha sustraendo.</param>
        /// <returns>True si el primer parámetro es menor o igual al segundo parámetro.</returns>
        public static bool SameOrBefore(DateTime? d1, DateTime? d2)
        {
            if (d1 == null || d2 == null)
                return false;
            return DateTime.Compare(d1.Value.Date, d2.Value.Date) <= 0;
        }

        /// <summary>
        /// Compara si una fecha es diferente a la otra
        /// </summary>
        /// <param name="d1">Fecha minuendo.</param>
        /// <param name="d2">Fecha sustraendo.</param>
        /// <returns>True si el primer parámetro es menor o igual al segundo parámetro.</returns>
        public static bool Different(DateTime? d1, DateTime? d2)
        {
            if (d1 == null || d2 == null)
                return false;
            return DateTime.Compare(d1.Value.Date, d2.Value.Date) != 0;
        }


        /// <summary>
        /// Compara si una fecha es menor a la otra
        /// </summary>
        /// <param name="d1">Fecha minuendo.</param>
        /// <param name="d2">Fecha sustraendo.</param>
        /// <returns>True si el primer parámetro es menor al segundo parámetro.</returns>
        public static bool Before(DateTime? d1, DateTime? d2)
        {
            if (d1 == null || d2 == null)
                return false;
            return DateTime.Compare(d1.Value.Date, d2.Value.Date) < 0;
        }


    }
}
