using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Archivos
{
    public class Gestor_Comprimidos
    {
       
        private string roothFilePath;
        private string tempFolder;
        private string fileName;
        public Gestor_Comprimidos(string roothFilePath)
        {
            this.roothFilePath = roothFilePath;
            tempFolder = roothFilePath + Guid.NewGuid() + "_Temp";

            if (!System.IO.Directory.Exists(tempFolder))
                System.IO.Directory.CreateDirectory(tempFolder);

            fileName = Guid.NewGuid() + "_files.zip";
        }
        //Mueve el archivo a una carpeta temporal que se comprimirá posteriormente.
        public void Mover_Archivo_Temporal(string archivo, string nombreArchivo)
        {
            System.IO.File.Copy(archivo, tempFolder + "\\" + nombreArchivo, true);
        }

        public string Crear_Archivo_Zip()
        {
            ZipFile.CreateFromDirectory(tempFolder, roothFilePath + "\\" + fileName);
            return roothFilePath + "\\" + fileName;
        }

        public void Eliminar_Temporales()
        {
            Directory.Delete(tempFolder, true);
        }
    }
}
