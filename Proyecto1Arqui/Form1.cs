using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace Proyecto1Arqui
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public string fileName = null;
        private static MetodoSecuencial metS = new MetodoSecuencial();
        private static MetodoParalelo metP = new MetodoParalelo();
		static Stopwatch temporizador;

		private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void explorarButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|doc files (*.doc)|*.doc|docx files (*.docx)|*.docx";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog1.FileName;
                    ArchivoNombre.Paste(fileName);
                    openFileDialog1.Dispose();
                    //Console.WriteLine(fileName);
                }
            }
        }

        public static int ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 200;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return (int)inputBox.Value;
        }

        public static String ShowDialog2(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 200;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return inputBox.Text;
        }

        public static String ShowDialog3(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 200;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            //TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            //prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            //return inputBox.Text;
            return "";
        }

        private void ejecutarSeleccionButton_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            if (checkBox9.Checked == true)
            {
                //De forma secuencial
                if (fileName != null)
                {
					cargando.Text = "Preparando archivo...";
                    //Do something with the file, for example read text from it
                    string ext = Path.GetExtension(fileName);
                    if (ext.Equals(".txt"))
                    {
                        metS.leerWord(fileName);
                    }
                    else if (ext.Equals(".doc") || ext.Equals(".docx"))
                    {
                        metS.leerWord(fileName);
                    }
					cargando.Text = "";
				}

				int valor = 0;
				if(checkBox2.Checked == true)valor = ShowDialog("Cantidad de palabras:", "Cantidad de Palabras a buscar");
				string valor2 = null;
				if(checkBox3.Checked == true)valor2 = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
                
                cargando.Text = "Ejecutando funciones...";
                if (checkBox1.Checked == true)
                {
                    temporizador = Stopwatch.StartNew();
                //llamese al metodo de palabra de mayor longitud
                ArrayList list = metS.getPalabraLarga(metS.data);

                    string resultado = "Palabra más larga: ";
                    foreach (var item in list)
                    {
                        resultado += item + ", ";
                    }
                    resultado += "-Tiempo = " + temporizador.ElapsedMilliseconds.ToString();
                    rMayorLongitud.Text = resultado;
                }
                    
                   
                if (checkBox2.Checked == true)
                {
                    temporizador = Stopwatch.StartNew();
                //llamese al metodo de "N" palabras mas comunes
                metS.descomponerLineaS(metS.data);

                    
                    metS.PalabrasRepetidas(valor);

                    Func<KeyValuePair<string, int>, int> ordenar = delegate (KeyValuePair<string, int> item2)
                    {
                        return item2.Value;
                    };
                    IOrderedEnumerable<KeyValuePair<string, int>> ordenado = metS.diccionarioRepetidas.OrderByDescending(ordenar);
                    int cont2 = 0;
                    string resultado = "Palabras más comunes: ";
                    foreach (var itemx1 in ordenado)
                    {
                        if (cont2 < valor)
                        {
                        //Modificar Para que imprima en la pantalla de impresion
                        cont2 += 1;
                            resultado += itemx1.Key + " " + itemx1.Value + ", ";
                        }
                    }
                    resultado += "-Tiempo = " + temporizador.ElapsedMilliseconds.ToString();
                    rPalabrasComunes.Text = resultado;
                }
                    
                    
                if (checkBox3.Checked == true)
                {
					
                    temporizador = Stopwatch.StartNew();
					//llamese al metodo de numero de veces que aparece una palabra
                    int x = metS.cantPalabraParticular(metS.data, valor2);
                    rPalabraVeces.Text = valor2 + " Número veces que aparece: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                }
                    
                if (checkBox4.Checked == true)
                {
                    temporizador = Stopwatch.StartNew();
					//llamese al metodo de Total de palabras
					int x = metS.getTotalPalabras(metS.data);
                    rTotalPalabras.Text = "Número total de palabras: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                }
                   
                if (checkBox5.Checked == true)
                {
                    temporizador = Stopwatch.StartNew();
					//llamese al metodo de numero de palabras diferentes
					int x = metS.getPalabrasDiferentes(metS.data);
                    rPalabrasDiferentes.Text = "Número palabras diferentes: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                }
                    
                if (checkBox6.Checked == true)
                {
                    temporizador = Stopwatch.StartNew();
					//llamese al metodo de numero total de caracteres
					int x = metS.getTotalCaracters(metS.data);
                    rTotalCaracteres.Text = "Número total de caracteres: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                }
                    
                if (checkBox7.Checked == true)
                {
                    temporizador = Stopwatch.StartNew();
					//llamese al metodo de numero de caracteres sin espacio
					int x = metS.getCaracteresEspacios(metS.data);
                    rEspacios.Text = "Número total de caracteres sin espacios: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                }
                    
            
                if (checkBox8.Checked == true)
                {
                    temporizador = Stopwatch.StartNew();
					//llamese al metodo de recuento de oraciones
					int x = metS.getTotalOraciones(metS.data);
                    rOraciones.Text = "Número de oraciones: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                }
                cargando.Text = "Utilizado Método Secuencial";
                    
               
            }
            else if (checkBox10.Checked == true)
            {
                //hacer de manera concurrente
                if (fileName != null)
                {
					cargando.Text = "Preparando archivo...";
					//Do something with the file, for example read text from it
					string ext = Path.GetExtension(fileName);
                    if (ext.Equals(".txt"))
                    {
                        metP.leerWord(fileName);
                    }
                    else if (ext.Equals(".doc") || ext.Equals(".docx"))
                    {
                        metP.leerWord(fileName);
                    }
					cargando.Text = "";

				}
				int valor = 0;
				if (checkBox2.Checked == true) valor = ShowDialog("Cantidad de palabras:", "Cantidad de Palabras a buscar");
				string valor2 = null;
				if (checkBox3.Checked == true) valor2 = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
				//Preguntar Cuales Checkbox estan activas
				cargando.Text = "Ejecutando funciones...";
                try
                {
                    Parallel.Invoke(() =>
                    {
                        try
                        {
                            if (checkBox1.Checked == true)
                            {
                                temporizador = Stopwatch.StartNew();
								//llamese al metodo de palabra de mayor longitud
								string resultado = "Palabra más larga: ";
                                ArrayList list = metP.palabraLarga();
                                foreach (var item in list)
                                {
                                    resultado += item + ", ";
                                }
                                resultado += "-Tiempo = " + temporizador.ElapsedMilliseconds;
                                rMayorLongitud.Text = resultado;

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }, () =>
                     {
                         try
                         {
                             if (checkBox2.Checked == true)
                             {
                                 temporizador = Stopwatch.StartNew();
								 //llamese al metodo de "N" palabras mas comunes
								 metP.descomponerLineaP(metP.data);

                                 metP.PalabrasRepetidas(valor);

                                 Func<KeyValuePair<string, int>, int> ordenar = delegate (KeyValuePair<string, int> item2)
                                 {
                                     return item2.Value;
                                 };
                                 IOrderedEnumerable<KeyValuePair<string, int>> ordenado = metP.diccionarioRepetidas.OrderByDescending(ordenar);
                                 int cont2 = 0;
                                 string result = "Palabras más comunes: ";
                                 foreach (var itemx1 in ordenado)
                                 {
                                     if (cont2 < valor)
                                     {
                                         cont2 += 1;
                                         result += itemx1.Key + " " + itemx1.Value + ", ";
                                     }
                                 }
                                 result += "-Tiempo = " + temporizador.ElapsedMilliseconds;
                                 rPalabrasComunes.Text = result;
                             }
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message);
                         }
                     }, () =>
                     {
                         try
                         {
                             if (checkBox3.Checked == true)
                             {
								 //llamese al metodo de numero de veces que aparece una palabra
								 temporizador = Stopwatch.StartNew();
								 int x = metP.palabraParticular(valor2);
                                 rPalabraVeces.Text = valor2 + "Número veces que aparece: " + x.ToString()+" -Tiempo = "+temporizador.ElapsedMilliseconds;
                             }
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message);
                         }
                     }, () =>
                     {
                         try
                         {
                             if (checkBox4.Checked == true)
                             {
								 temporizador = Stopwatch.StartNew();
								 //llamese al metodo de Total de palabras
								 int x = metP.totalPalabrasParalelo();
                                 rTotalPalabras.Text = "Número total de palabras: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                             }
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message);
                         }

                     }, () =>
                     {
                         try
                         {
                             if (checkBox5.Checked == true)
                             {
								 temporizador = Stopwatch.StartNew();
								 //llamese al metodo de numero de palabras diferentes
								 int x = metP.palabrasDiferentesParalelo();
                                 rPalabrasDiferentes.Text = "Número palabras diferentes: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                             }
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message);
                         }
                     }, () =>
                     {
                         try
                         {
                             if (checkBox6.Checked == true)
                             {
								 temporizador = Stopwatch.StartNew();
								 //llamese al metodo de numero total de caracteres
								 int x = metP.totalCaracteresParalelo();
                                 rTotalCaracteres.Text = "Número total de caracteres: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                             }
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message);
                         }
                     }, () =>
                     {
                         try
                         {
                             if (checkBox7.Checked == true)
                             {
								 temporizador = Stopwatch.StartNew();
								 //llamese al metodo de numero de caracteres sin espacio
								 int x = metP.caracteresEspaciosParalelo();
                                 rEspacios.Text = "Número caracteres sin espacio: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                             }
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message);
                         }
                     }, () =>
                     {
                         try
                         {
                             if (checkBox8.Checked == true)
                             {
								 temporizador = Stopwatch.StartNew();
								 //llamese al metodo de recuento de oraciones
								 int x = metP.totalOracionesParalelo();
                                 rOraciones.Text = "Número total de oraciones: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                             }
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message);
                         }
                     });
                    cargando.Text = "Utilizado Método Concurrente";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ejecutarTodoButton_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            //llamese a todos los metodos uno por uno
            if (checkBox9.Checked == true)
            {
                //De forma secuencial
                if (fileName != null)
                {
					cargando.Text = "Preparando archivo...";
					//Do something with the file, for example read text from it
					string ext = Path.GetExtension(fileName);
                    if (ext.Equals(".txt"))
                    {
                        metS.leerWord(fileName);
                    }
                    else if (ext.Equals(".doc") || ext.Equals(".docx"))
                    {
                        metS.leerWord(fileName);
                    }
					cargando.Text = "";
				}
				int valor = ShowDialog("Cantidad de palabras:", "Cantidad de Palabras a buscar");
				string valor2 = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");

				cargando.Text = "Ejecutando funciones...";
				temporizador = Stopwatch.StartNew();
				//llamese al metodo de palabra de mayor longitud
				ArrayList list = metS.getPalabraLarga(metS.data);

				string resultado = "Palabra más larga: ";
				foreach (var item in list)
				{
					resultado += item + ", ";
				}
				rMayorLongitud.Text = resultado+" Tiempo = "+temporizador.ElapsedMilliseconds;
                    
                
				//llamese al metodo de "N" palabras mas comunes
				temporizador = Stopwatch.StartNew();
				metS.descomponerLineaS(metS.data);
				metS.PalabrasRepetidas(valor);

				Func<KeyValuePair<string, int>, int> ordenar = delegate (KeyValuePair<string, int> item2)
				{
					return item2.Value;
				};
				IOrderedEnumerable<KeyValuePair<string, int>> ordenado = metS.diccionarioRepetidas.OrderByDescending(ordenar);
				int cont2 = 0;
				string result = "Palabras más comunes: ";
				foreach (var itemx1 in ordenado)
				{
					if (cont2 < valor)
					{
						//Modificar Para que imprima en la pantalla de impresion
						cont2 += 1;
						result += itemx1.Key + " " + itemx1.Value + ", ";
					}
				}
				rPalabrasComunes.Text = result + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                    
               
               
				//llamese al metodo de numero de veces que aparece una palabra
				temporizador = Stopwatch.StartNew();
				int x = metS.cantPalabraParticular(metS.data, valor2);
				rPalabraVeces.Text = valor2 + " Número veces que aparece: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                    
                
				temporizador = Stopwatch.StartNew();
				//llamese al metodo de Total de palabras
				int x2 = metS.getTotalPalabras(metS.data);
				rTotalPalabras.Text = "Número total de palabras: " + x2.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                   
                
				temporizador = Stopwatch.StartNew();
				//llamese al metodo de numero de palabras diferentes
				int x3 = metS.getPalabrasDiferentes(metS.data);
				rPalabrasDiferentes.Text = "Número palabras diferentes: " + x3.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                  
               
				temporizador = Stopwatch.StartNew();
				//llamese al metodo de numero total de caracteres
				int x4 = metS.getTotalCaracters(metS.data);
				rTotalCaracteres.Text = "Número total de caracteres: " + x4.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                  
               
				temporizador = Stopwatch.StartNew();
				//llamese al metodo de numero de caracteres sin espacio
				int x5 = metS.getCaracteresEspacios(metS.data);
				rEspacios.Text = "Número caracteres sin espacio: " + x5.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                   
               
				temporizador = Stopwatch.StartNew();
				//llamese al metodo de recuento de oraciones
				int x6 = metS.getTotalOraciones(metS.data);
				rOraciones.Text = "Número total de oraciones: " + x6.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                   

				cargando.Text = "Utilizado Método Secuencial";
                
			}
            else if (checkBox10.Checked == true)
            {
                //hacer de manera concurrente
                if (fileName != null)
                {
					cargando.Text = "Preparando archivo...";
					//Do something with the file, for example read text from it
					string ext = Path.GetExtension(fileName);
                    if (ext.Equals(".txt"))
                    {
                        metP.leerWord(fileName);
                    }
                    else if (ext.Equals(".doc") || ext.Equals(".docx"))
                    {
                        metP.leerWord(fileName);
                    }
					cargando.Text = "";
				}
                try
                {
					int valor = ShowDialog("Cantidad de palabras:", "Cantidad de Palabras a buscar");
					string valor2 = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
					cargando.Text = "Ejecutando funciones...";
                    Parallel.Invoke(() =>
                    {
						temporizador = Stopwatch.StartNew();
						//llamese al metodo de palabra de mayor longitud
						string resultado = "Palabra más larga: ";
                        ArrayList list = metP.palabraLarga();
                        foreach (var item in list)
                        {
                            resultado += item + ", ";
                        }
                        rMayorLongitud.Text = resultado + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                    }, () =>
                    {
						temporizador = Stopwatch.StartNew();
						//llamese al metodo de "N" palabras mas comunes
						metP.descomponerLineaP(metP.data);
                        metP.PalabrasRepetidas(valor);

                        Func<KeyValuePair<string, int>, int> ordenar = delegate (KeyValuePair<string, int> item2)
                        {
                            return item2.Value;
                        };
                        IOrderedEnumerable<KeyValuePair<string, int>> ordenado = metP.diccionarioRepetidas.OrderByDescending(ordenar);
                        int cont2 = 0;
                        string result = "Palabras más comunes: ";
                        foreach (var itemx1 in ordenado)
                        {
                            if (cont2 < valor)
                            {
                                cont2 += 1;
                                result += itemx1.Key + " " + itemx1.Value + ", ";
                            }
                        }
                        rPalabrasComunes.Text = result + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                    }, () =>
                    {
                    //llamese al metodo de numero de veces que aparece una palabra
						temporizador = Stopwatch.StartNew();
						int x = metP.palabraParticular(valor2);
                        rPalabraVeces.Text = valor2 + " Número veces que aparece: " + x.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                    }, () =>
                    {
						temporizador = Stopwatch.StartNew();
						//llamese al metodo de Total de palabras
						int x1 = metP.totalPalabrasParalelo();
                        rTotalPalabras.Text = "Número total de palabras: " + x1.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                    }, () =>
                    {
						temporizador = Stopwatch.StartNew();
						//llamese al metodo de numero de palabras diferentes
						int x2 = metP.palabrasDiferentesParalelo();
                        rPalabrasDiferentes.Text = "Número palabras diferentes: " + x2.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                    }, () =>
                    {
						temporizador = Stopwatch.StartNew();
						//llamese al metodo de numero total de caracteres
						int x3 = metP.totalCaracteresParalelo();
                        rTotalCaracteres.Text = "Número total de caracteres: " + x3.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;
                    }, () =>
                    {
						temporizador = Stopwatch.StartNew();
						//llamese al metodo de numero de caracteres sin espacio
						int x4 = metP.caracteresEspaciosParalelo();
                        rEspacios.Text = "Número caracteres sin espacio: " + x4.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;

                    }, () =>
                    {
						temporizador = Stopwatch.StartNew();
						//llamese al metodo de recuento de oraciones
						int x5 = metP.totalOracionesParalelo();
                        rOraciones.Text = "Número total de oraciones: " + x5.ToString() + " -Tiempo = " + temporizador.ElapsedMilliseconds;

                        cargando.Text = "Utilizado Método Concurrente";
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void rendimientoButton_Click(object sender, EventArgs e)
        {
            Rendimiento rendi = new Rendimiento();
            rendi.Show();
        }
    }
}
