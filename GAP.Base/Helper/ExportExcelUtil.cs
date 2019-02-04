using GAP.Base.Dto.Beneficiario;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Base.Helper
{
    public class ExportExcelUtil
    {

        public static Int16 INTEROP = 1;
        public static Int16 EPPPLUS = 2;

        private Int16 libreria;
        private List<List<string>> encabezado;
        private List<FileExcel> contenido;
        private int filaActual;
        private int columnaActual;
        //Cuando el encabezado está compuesto por una única fila
        private const int filaEncabezadoPorDefecto = 1;
        private char[] abc;

        /// <summary>
        /// Utilizar este contructor cuando la cantidad de filas del encabezado sea 1.
        /// </summary>
        /// <param name="libreria"></param>
        public ExportExcelUtil(Int16 libreria)
        {
            Inicializacion(libreria, 1);
        }

        /// <summary>
        /// /// Utilizar este contructor cuando la cantidad de filas del encabezado sea mas de 1.
        /// </summary>
        /// <param name="libreria"></param>
        /// <param name="cantFilasEncabezado"></param>
        public ExportExcelUtil(Int16 libreria, Int16 cantFilasEncabezado)
        {
            Inicializacion(libreria, cantFilasEncabezado);
        }

        private void Inicializacion(Int16 libreria, Int16 cantFilasEncabezado){
            
            this.libreria = libreria;
            this.encabezado = new List<List<string>>(cantFilasEncabezado);
            InicializarEncabezado();
            this.contenido = new List<FileExcel>();
            this.filaActual = cantFilasEncabezado + 1;
            abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        }

        private void InicializarEncabezado(){
            for (int i = 0; i < this.encabezado.Capacity; i++)
                this.encabezado.Add(new List<string>());
        }

        /// <summary>
        /// Utilizar este método para especificar que la fila del encabezado que se está editando
        /// </summary>
        /// <param name="filaEncabezado"></param>
        /// <param name="columnHeader"></param>
        public void AgregrarColumnaEncabezado(Int16 filaEncabezado, string columnHeader)
        {
            this.encabezado[filaEncabezado - 1].Add(columnHeader);
        }

        public void AgregrarColumnaEncabezado(string columnHeader)
        {
            if (encabezado.Count > 1)
            {
                string msj = "Se definió mas de una fila para el encabezado."
                    + " Debe usar el método AgregrarColumnaEncabezado(Int16 filaEncabezado, string columnHeader)";
                throw new Exception(msj);
            }

            this.encabezado[filaEncabezadoPorDefecto - 1].Add(columnHeader);
        }

        public void AgregarFila(List<string> row, bool color)
        {
            FileExcel fileExcel = new FileExcel();
            fileExcel.celdas = row;
            if(color)
            {
                fileExcel.color = Color.DarkGray;
                fileExcel.colorFont = Color.White;
            }
            contenido.Add(fileExcel);
        }

        public string ExportarExcel()
        {
            string fileName = null;

            if (libreria == ExportExcelUtil.INTEROP)
            {
                fileName = ExportarExcelInterop();
            }
            else if (libreria == ExportExcelUtil.EPPPLUS)
            {
                fileName = ExportarExcelEpplus();
            }
            else
            {
                fileName = ExportarExcelEpplus();
            }
            return fileName;
        }


        private string ExportarExcelInterop()
        {

            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false;

            Microsoft.Office.Interop.Excel._Workbook worKbooK = excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel._Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet) worKbooK.ActiveSheet;

            //char[] abcArray = abc;    

            if (contenido.Count != 0)
            {
                columnaActual = 0;
                for (int filaEncabezado = 0; filaEncabezado < encabezado.Count; filaEncabezado++)
                {
                    for (int celdaEncabezado = 0; celdaEncabezado < encabezado[filaEncabezado].Count; celdaEncabezado++)
                    {
                        workSheet.Cells[filaEncabezado + 1, IncrementarColumna()] = encabezado[filaEncabezado][celdaEncabezado];
                    }
                }

                for (int r = 0; r < contenido.Count; r++)
                {
                    columnaActual = 0;
                    for (int c = 0; c < contenido[0].celdas.Count; c++)
                    {
                        string columnaDescriptor = IncrementarColumna();
                        if (contenido[r].color != null)
                        {
                            Range rng = workSheet.get_Range(columnaDescriptor + filaActual + ":" + columnaDescriptor + filaActual, Missing.Value);
                            rng.Interior.Color = contenido[r].color;
                            rng.Font.Color = contenido[r].colorFont;
                        }
                        workSheet.Cells[filaActual, columnaDescriptor] = contenido[r].celdas[c];
                    }
                    IncrementarFila();
                }
            }
            
            string result = Path.GetTempPath();

            var myUniqueFileName = string.Format(@"{0}.xlsx", DateTime.Now.Ticks);

            worKbooK.SaveAs(result + myUniqueFileName);
            worKbooK.Close();  
            excelApp.Quit();

            return result + myUniqueFileName;
        }


        private string ExportarExcelEpplus()
        {

            string result = Path.GetTempPath();

            //string result = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var myUniqueFileName = string.Format(@"{0}.xlsx", DateTime.Now.Ticks);

            String path = result + myUniqueFileName;
            string fichero = @path;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(fichero)))
            {
                package.Workbook.Properties.Title = "Reporte";
                
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("reporte");

                //char[] abcArray = abc;

                if (contenido.Count != 0)
                {
                    
                    for (int filaEncabezado = 0; filaEncabezado < encabezado.Count; filaEncabezado++)
                    {
                        columnaActual = 0;
                        for (int celdaEncabezado = 0; celdaEncabezado < encabezado[filaEncabezado].Count; celdaEncabezado++)
                        {
                            var cell = ws.Cells[IncrementarColumna() + (filaEncabezado + 1).ToString()];
                            cell.Value = encabezado[filaEncabezado][celdaEncabezado];
                            var fill = cell.Style.Fill;
                            fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(Color.Gray);
                            fill.PatternColor.SetColor(Color.White);
                        }
                    }

                    for (int r = 0; r < contenido.Count; r++)
                    {
                        columnaActual = 0;
                        for (int c = 0; c < contenido[0].celdas.Count; c++)
                        {
                            ws.Cells[IncrementarColumna() + filaActual].Value = contenido[r].celdas[c];
                        }
                        IncrementarFila();
                    }
                }

                package.Save();
            }
            return result + myUniqueFileName;
        }

        private int IncrementarFila()
        {
            return filaActual++;
        }

        private string IncrementarColumna()
        {
            //TODO Alvaro refactorizar 
            if (columnaActual == abc.Length)
                columnaActual++;    
            string descriptor = GetColumnDescriptor(columnaActual);
            columnaActual++;
            return descriptor;
        }
        
        private string GetColumnDescriptor(int index)
        {
            int tam = abc.Length;

            if (index < tam)
            {
                index = (index == -1) ? 0 : index;
                return abc[index].ToString();
            }
            else if (index > tam)
            {
                string pref = GetColumnDescriptor((int)((index - 1) / tam) - 1);
                return pref + GetColumnDescriptor((index - (int)((index - 1) / tam) * tam) - 1);
            }
            else
            {
                //TODO Alvaro refactorizar
                return "";
            }
        }


        class FileExcel
        {
            public Color? color { get; set; }

            public Color? colorFont { get; set; }

            public List<string> celdas { get; set; }
        }
    }
}
