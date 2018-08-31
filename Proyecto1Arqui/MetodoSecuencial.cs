using System;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto1Arqui
{
	class MetodoSecuencial
	{
        ArrayList listaPalabrasTotal = new ArrayList();
        public Dictionary<string, int> diccionarioRepetidas = new Dictionary<string, int>();
        public String data = null;

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
			data = doc.Content.Text.ToString();
			//cerramos el archivo
			doc.Close(ref missing, ref missing, ref missing);

        }

		public void leerTexto(String fileName)
		{
			data = null;
			using (StreamReader leer = new StreamReader(fileName))
			{
				while (!leer.EndOfStream)
				{
					data += leer.ReadLine();
					
				}

			}

		}

        public void descomponerLineaS(String linea)
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
                //verifica que se a una letra
                if (Char.IsLetterOrDigit(letra) == false)
                {
                    //crea un arreglo de la cantidad de chars de la palabra
                    palabraArray = new char[palabra.Count];
                    //pasa los chars a una lista
                    palabra.CopyTo(palabraArray);
                    //se une la palabra formada
                    resultado = string.Join(null, palabraArray);
                    
                    //verifica que la palabra no este vacia
                    if (!resultado.Equals(""))
                    {
                        //se agrega la palabra a la lista total de palabras
                        listaPalabrasTotal.Add(resultado);
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
                listaPalabrasTotal.Add(resultado);
                palabra = new ArrayList();
            }

        }

		public int getPalabrasDiferentes(string texto)
		{
			ArrayList listaRepetidas = new ArrayList();
			ArrayList listaPalabras1 = new ArrayList();
			//lista para almacenar una palabra
			ArrayList palabra1 = new ArrayList();
			//cadena de chars para formar una palabra
			Char[] palabraArray1;
			String resultado1;
			//verifica si la palabra ya se ha guardado
			Boolean palGuardada1 = false;
			//convierte el string a cadena de chars
			var chars1 = texto.ToCharArray();
			foreach (char letra in chars1)
			{
				//verifica que se a una letra
				if (Char.IsLetterOrDigit(letra) == false)
				{
					//crea un arreglo de la cantidad de chars de la palabra
					palabraArray1 = new char[palabra1.Count];
					//pasa los chars a una lista
					palabra1.CopyTo(palabraArray1);
					//se une la palabra formada
					resultado1 = string.Join(null, palabraArray1);
					//verifica que la palabra no este vacia
					if (!resultado1.Equals(""))
					{
						if (listaPalabras1.Count == 0) listaPalabras1.Add(resultado1);
						//verifica que sea una palabra diferente
						else
						{
							foreach (String diferente in listaPalabras1)
							{
								if (diferente.Equals(resultado1))
								{
									listaPalabras1.Remove(resultado1);
									listaRepetidas.Add(resultado1);
									break;
								}

							}
							if (!listaRepetidas.Contains(resultado1))
							{
								//se agrega la palabra a la lista total de palabras
								listaPalabras1.Add(resultado1);
							}
						}

					}
					//se setean los valores
					palabra1 = new ArrayList();
					palGuardada1 = true;

				}
				else
				{
					//agrega chars a la lista para conformar una palabra
					palabra1.Add(letra);
					palGuardada1 = false;
				}
			}
			//verifica que la palabra se haya guardado
			if (palGuardada1 == false)
			{
				palabraArray1 = new char[palabra1.Count];
				palabra1.CopyTo(palabraArray1);
				resultado1 = string.Join(null, palabraArray1);
				foreach (String diferente in listaPalabras1)
				{
					if (diferente.Equals(resultado1))
					{
						listaPalabras1.Remove(resultado1);
						break;
					}

				}
				if (!listaRepetidas.Contains(resultado1))
				{
					//se agrega la palabra a la lista total de palabras
					listaPalabras1.Add(resultado1);
				}
				palabra1 = new ArrayList();
			}
			return listaPalabras1.Capacity;
		}

		public int getTotalCaracters(String texto)
		{
			return texto.Length;
		}

		public int getCaracteresEspacios(String texto)
		{
			int cantCaracteres = 0;
			//convierte el string a cadena de chars
			var chars = texto.ToCharArray();
			//ciclo que recorre la cadena de chars
			foreach (char letra in chars)
			{
				cantCaracteres += 1;
				//funcion total de carcteres sin espacios
				if (letra.Equals(' ')) cantCaracteres -= 1;
			}
			return cantCaracteres;
		}

		public int getTotalOraciones(String texto)
		{
			int cantOraciones = 0;
			//convierte el string a cadena de chars
			var chars = texto.ToCharArray();
			//ciclo que recorre la cadena de chars
			foreach (char letra in chars)
			{
				if (letra.Equals('.')) { cantOraciones += 1; }
			}
			return cantOraciones;
		}

		public int getTotalPalabras(String texto)
		{
			ArrayList listaPalabras = new ArrayList();
			//lista para almacenar una palabra
			ArrayList palabra = new ArrayList();
			//cadena de chars para formar una palabra
			Char[] palabraArray;
			String resultado;
			//verifica si la palabra ya se ha guardado
			Boolean palGuardada = false;
			//convierte el string a cadena de chars
			var chars = texto.ToCharArray();
			//ciclo que recorre la cadena de chars
			foreach (char letra in chars)
			{
				//verifica que se a una letra
				if (Char.IsLetterOrDigit(letra) == false)
				{
					//crea un arreglo de la cantidad de chars de la palabra
					palabraArray = new char[palabra.Count];
					//pasa los chars a una lista
					palabra.CopyTo(palabraArray);
					//se une la palabra formada
					resultado = string.Join(null, palabraArray);

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
			return listaPalabras.Count;
		}

		public ArrayList getPalabraLarga(String texto)
		{
			ArrayList palabraLarga = new ArrayList();
			int palabraLargaCont = 0;
			//lista para almacenar una palabra
			ArrayList palabra = new ArrayList();
			//cadena de chars para formar una palabra
			Char[] palabraArray;
			String resultado;
			//verifica si la palabra ya se ha guardado
			Boolean palGuardada = false;
			//convierte el string a cadena de chars
			var chars = texto.ToCharArray();
			//ciclo que recorre la cadena de chars
			foreach (char letra in chars)
			{
				//verifica que se a una letra
				if (Char.IsLetterOrDigit(letra) == false)
				{
					//crea un arreglo de la cantidad de chars de la palabra
					palabraArray = new char[palabra.Count];
					//pasa los chars a una lista
					palabra.CopyTo(palabraArray);
					//se une la palabra formada
					resultado = string.Join(null, palabraArray);

					//funcion palabra mas larga
					if (palabra.Count > palabraLargaCont)
					{
						palabraLarga.Clear();
						palabraLarga.Add(resultado);
						palabraLargaCont = resultado.Length;
					}
					else if (palabra.Count == palabraLargaCont)
					{
						if (!palabraLarga.Contains(resultado))
						{
							palabraLarga.Add(resultado);
						}
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
				//funcion palabra mas larga
				if (palabra.Count > palabraLargaCont) { palabraLarga.Clear(); palabraLarga.Add(resultado); }
				else if (palabra.Count == palabraLargaCont) { palabraLarga.Add(resultado); }
				palabra = new ArrayList();
			}
			return palabraLarga;
		}

		public int cantPalabraParticular(String texto, String seleccion) {

			int cantPalabra = 0;
			ArrayList palabra = new ArrayList();
			//cadena de chars para formar una palabra
			Char[] palabraArray;
			String resultado;
			//verifica si la palabra ya se ha guardado
			Boolean palGuardada = false;
			//convierte el string a cadena de chars
			var chars = texto.ToCharArray();
			//ciclo que recorre la cadena de chars
			foreach (char letra in chars)
			{
				//verifica que se a una letra
				if (Char.IsLetterOrDigit(letra) == false)
				{
					//crea un arreglo de la cantidad de chars de la palabra
					palabraArray = new char[palabra.Count];
					//pasa los chars a una lista
					palabra.CopyTo(palabraArray);
					//se une la palabra formada
					resultado = string.Join(null, palabraArray);

					if (resultado.Equals(seleccion)) {
						cantPalabra += 1;
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
				if (resultado.Equals(seleccion))
				{
					cantPalabra += 1;
				}
				palabra = new ArrayList();
			}
			return cantPalabra;
		}

        public void PalabrasRepetidas(int valor)
        {
            foreach (string item in listaPalabrasTotal)
            {
                if (diccionarioRepetidas.ContainsKey(item))
                {
                    continue;
                }
                else
                {
                    int cont = 0;
                    for (int x = 0; x < listaPalabrasTotal.Count; x++)
                    {
                        if (item.Equals(listaPalabrasTotal[x]))
                        {
                            cont += 1;
                        }
                    }

                    diccionarioRepetidas.Add(item, cont);
                }
            }

        }
    }
}
