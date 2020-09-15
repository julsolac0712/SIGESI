using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

[assembly: CLSCompliant(true)]
namespace Error_Handling
{
    public class Error_Handling
    {
        private string logPath;
        private string archivo;

        public Error_Handling(string logPath)
        {
            this.logPath = logPath;

            archivo = Inicializar_Log();
        }

        private string Inicializar_Log()
        {
            string nombreArchivo = logPath + DateTime.Now.ToString("yyyy-M-d") + "_log.txt";

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(logPath)))//Verifico si existe el directorio y si no existe lo creo
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(logPath));

            if (!File.Exists(HttpContext.Current.Server.MapPath(nombreArchivo)))//Verifico si ya hay un archivo para el día actual, si no hay, lo creo.
                File.Create(HttpContext.Current.Server.MapPath(nombreArchivo));

            return nombreArchivo;
        }

        public void Escribir_Log(string error)
        {
            string errorPrint = DateTime.Now.ToString("T") + " --> Error: " + error;

            using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(archivo), FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(errorPrint);
            }
        }

        public void Escribir_Log(System.Exception ex, string mensajeError)
        {
            string errorPrint = DateTime.Now.ToString("T") + " --> Error: ";

            if (ex.GetType().Name.Equals("SqlException"))
            {
                SqlException x = (SqlException)ex;
                errorPrint += "SqlException: " + x.Server + " Procedure " + x.Procedure + " State = " + x.State.ToString() + " Line Number = " + x.LineNumber + " Message = " + x.Message;
            }
            else if (ex.GetType().Name.Equals("FileNotFoundException"))
            {
                FileNotFoundException x = (FileNotFoundException)ex;
                errorPrint += "FileNotFoundException: File Name = " + x.FileName + " Message = " + x.Message;
            }
            else
            {
                errorPrint += "Mensaje: " + ex.Message;
            }

            if (string.IsNullOrEmpty(mensajeError))
            {
                errorPrint += mensajeError;
            }

            using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(archivo), FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(errorPrint);
                sw.WriteLine("____________________________________________________");
            }
        }
    }
}
