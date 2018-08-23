using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Word = Microsoft.Office.Interop.Word;


namespace Proyecto1Arqui
{
	public partial class Form1 : Form
	{
		ArrayList listaPalabras = new ArrayList();
		public Form1()
		{
			InitializeComponent();
			//leerTexto();
			leerWord();
		}

		public void leerWord() {
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
			object ruta = @"C:\Users\USER\Documents\TEC\Arqui\pruebaPrograDocx.docx";
			//abrimos el archivo word
			doc = wordApp.Documents.Open(ref ruta,ref missing,ref readOnly,ref missing,
				ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,
				ref missing,ref isVisible, ref missing,ref missing,
				ref missing, ref missing);

			//activamos el archivo word
			doc.Activate();
			//obtenemos el texto del archivo
			String data = doc.Content.Text.ToString();
			//cerramos el archivo
			doc.Close(ref missing, ref missing, ref missing);
			
			descomponerLinea(data);
			label1.Text = listaPalabras.Count.ToString();
		}

		public void leerTexto() {
			String linea = null;
			using(StreamReader leer = new StreamReader(@"C:\Users\USER\Documents\TEC\Arqui\pruebaPrograDocx.docx"))
			{
				while(!leer.EndOfStream){
					linea = leer.ReadLine();
					descomponerLinea(linea);
				}
				label1.Text = listaPalabras.Count.ToString();
			}
			
		}

		public void descomponerLinea(String linea) {
			ArrayList palabra = new ArrayList();
			Char[] palabraArray;
			String resultado;
			Boolean palGuardada = false;
			var chars = linea.ToCharArray();
			foreach (char letra in chars) {
				if (letra.Equals(' '))
				{
					palabraArray = new char[palabra.Count];
					palabra.CopyTo(palabraArray);
					resultado = string.Join(null, palabraArray);
					listaPalabras.Add(resultado);
					palabra = new ArrayList();
					palGuardada = true;
				}
				else {
					palabra.Add(letra);
					palGuardada = false;
				}
			}
			if (palGuardada == false) {
				palabraArray = new char[palabra.Count];
				palabra.CopyTo(palabraArray);
				resultado = string.Join(null, palabraArray);
				listaPalabras.Add(resultado);
				palabra = new ArrayList();	
			}
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		
	}
}
