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
		ArrayList palabraLarga = new ArrayList();
		int totalCaracteres = 0, caracteresEspacio = 0, totalOraciones = 0, palabraLargaCont = 0;

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
			//lista para almacenar una palabra
			ArrayList palabra = new ArrayList();
			//cadena de chars para formar una palabra
			Char[] palabraArray;
			String resultado;
			//verifica si la palabra ya se ha guardado
			Boolean palGuardada = false;
			//convierte el string a cadena de chars
			var chars = linea.ToCharArray();
			//ciclo que recorre la cadena de chars
			foreach (char letra in chars)
			{
				//funcion de total de caracteres
				totalCaracteres += 1;
				

				//verifica que se a una letra
				if (Char.IsLetterOrDigit(letra) == false)
				{
					//funcion total de carcteres sin espacios
					if (letra.Equals(' ')) caracteresEspacio += 1;

					//funcion de recuento de oraciones
					if (letra.Equals('.')) totalOraciones += 1;

					//crea un arreglo de la cantidad de chars de la palabra
					palabraArray = new char[palabra.Count];
					//pasa los chars a una lista
					palabra.CopyTo(palabraArray);
					//se une la palabra formada
					resultado = string.Join(null, palabraArray);

					//funcion palabra mas larga
					if (palabra.Count > palabraLargaCont) { palabraLarga.Clear(); palabraLarga.Add(resultado); }
					else if (palabra.Count == palabraLargaCont) { palabraLarga.Add(resultado); }

					//verifica que la palabra no este vacia
					if (!resultado.Equals(""))
					{
						//se agrega la palabra a la lista total de palabras
						listaPalabras.Add(resultado);
					}
					//se setean los valores
					palabra = new ArrayList();
					palGuardada = true;

				}
				else
				{
					//agrega chars a la lista para conformar una palabra
					palabra.Add(letra);
					palGuardada = false;
				}
			}
			//verifica que la palabra se haya guardado
			if (palGuardada == false)
			{
				palabraArray = new char[palabra.Count];
				palabra.CopyTo(palabraArray);
				resultado = string.Join(null, palabraArray);
				listaPalabras.Add(resultado);
				palabra = new ArrayList();
			}

		}

		public int getPalabrasDiferentes() {
			ArrayList palabrasDiferentes = new ArrayList();
			foreach(String palabra in listaPalabras)
			{
				foreach(String repite in palabrasDiferentes)
				{
					if (palabra.Equals(repite)) break;

					palabrasDiferentes.Add(palabra);
				}
			}
			return palabrasDiferentes.Capacity;
		}

		public int getTotalCaracters() {
			return totalCaracteres;
		}

		public int getCaracteresEspacios() {
			return caracteresEspacio;
		}

		public int getTotalOraciones() {
			return totalOraciones;
		}

		public int getTotalPalabras() {
			return listaPalabras.Count;
		}

		public ArrayList getPalabraLarga() {
			return palabraLarga;
		}
	}
}
