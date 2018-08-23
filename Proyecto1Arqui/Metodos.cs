using System;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Collections;

namespace Proyecto1Arqui
{
    class Metodos
    {
        /// <summary>
        /// Leeer archivos de texto, word.
        /// </summary>
        ArrayList listaPalabras = new ArrayList();

        public void leerWord(String fileName)
        {
            //variable para representar variables perdidas cuando
            //se llamen metodos mediante el interop.
            object missing = System.Reflection.Missing.Value;
            //preparamos la clase Word
            Word.Application wordApp =
                new Word.Application();
            //preparamos la clase documento de word
            Word.Document doc = null;
            object readOnly = false;
            object isVisible = false;
            //ponemos la aplicacion word invisible
            wordApp.Visible = false;
            //obtenemos la ruta del archivo word
            object ruta = fileName;
            //abrimos el archivo word
            doc = wordApp.Documents.Open(ref ruta, ref missing, ref readOnly, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref isVisible, ref missing, ref missing,
                ref missing, ref missing);

            //activamos el archivo word
            doc.Activate();
            //obtenemos el texto del archivo
            String data = doc.Content.Text.ToString();
            //cerramos el archivo
            doc.Close(ref missing, ref missing, ref missing);

            descomponerLinea(data);
            
        }

        public void leerTexto(String fileName)
        {
            String linea = null;
            using (StreamReader leer = new StreamReader(fileName))
            {
                while (!leer.EndOfStream)
                {
                    linea = leer.ReadLine();
                    descomponerLinea(linea);
                }
                
            }

        }

        public void descomponerLinea(String linea)
        {
            ArrayList palabra = new ArrayList();
            Char[] palabraArray;
            String resultado;
            Boolean palGuardada = false;
            var chars = linea.ToCharArray();
            foreach (char letra in chars)
            {
                if (letra.Equals(' '))
                {
                    palabraArray = new char[palabra.Count];
                    palabra.CopyTo(palabraArray);
                    resultado = string.Join(null, palabraArray);
                    listaPalabras.Add(resultado);
                    palabra = new ArrayList();
                    palGuardada = true;
                }
                else
                {
                    palabra.Add(letra);
                    palGuardada = false;
                }
            }
            if (palGuardada == false)
            {
                palabraArray = new char[palabra.Count];
                palabra.CopyTo(palabraArray);
                resultado = string.Join(null, palabraArray);
                listaPalabras.Add(resultado);
                palabra = new ArrayList();
            }

        }
    }
}
