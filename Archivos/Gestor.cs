using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

[assembly: CLSCompliant(true)]

namespace Archivos
{
    public class Gestor
    {
        public string CargarArchivo(string rootFilePath, HttpPostedFile upload, int? id)
        {
            string fileName = string.Empty;

            if (id == null)
                fileName = Guid.NewGuid().ToString() + "_" + RenombrarArchivo(System.IO.Path.GetFileName(upload.FileName));//Cambio mayusculas a minusculas y quito espacios (Crea un nuevo ID y se lo concatena antes)
            else
                fileName = id + "_" + RenombrarArchivo(System.IO.Path.GetFileName(upload.FileName));//Cambio mayusculas a minusculas y quito espacios (Agrega el ID del parametro y se lo concatena antes)

            string pathArchivo = rootFilePath + fileName;

            if (!System.IO.Directory.Exists(rootFilePath))
                System.IO.Directory.CreateDirectory(rootFilePath);

            //if (!Directory.Exists(HttpContext.Current.Server.MapPath(rootFilePath)))//Verifico si existe el directorio y si no existe lo creo
            //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(rootFilePath));

            upload.SaveAs(pathArchivo);//Guardo el archivo en el servidor

            return fileName;
        }
        public string CargarArchivo(string rootFilePath, HttpPostedFile upload, string identificador)
        {
            string fileName = string.Empty;

            if (string.IsNullOrEmpty(identificador))
                fileName = Guid.NewGuid().ToString() + "_" + RenombrarArchivo(System.IO.Path.GetFileName(upload.FileName));//Cambio mayusculas a minusculas y quito espacios (Crea un nuevo ID y se lo concatena antes)
            else
                fileName = identificador + "_" + RenombrarArchivo(System.IO.Path.GetFileName(upload.FileName));//Cambio mayusculas a minusculas y quito espacios (Agrega el ID del parametro y se lo concatena antes)

            string pathArchivo = rootFilePath + fileName;

            if (!System.IO.Directory.Exists(rootFilePath))
                System.IO.Directory.CreateDirectory(rootFilePath);

            //if (!Directory.Exists(HttpContext.Current.Server.MapPath(rootFilePath)))//Verifico si existe el directorio y si no existe lo creo
            //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(rootFilePath));

            upload.SaveAs(pathArchivo);//Guardo el archivo en el servidor

            return fileName;
        }

        //Elimina el archivo ya existente cuando un documento es borrado del sistema o editado
        public void EliminarArchivoViejo(string archivoViejo)
        {

            if (System.IO.File.Exists(archivoViejo))
               System.IO.File.Delete(archivoViejo);
        }

        public string RenombrarArchivo(string nombreArchivo)
        {
            string archivoNuevo = string.Empty;

            archivoNuevo = nombreArchivo.ToLower();

            return EliminarCaracteresEspeciales(archivoNuevo.Replace(" ", "_"));
        }

        public  string EliminarCaracteresEspeciales(string nombreArchivo)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in nombreArchivo)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
