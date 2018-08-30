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

        public Form1()
        {
            InitializeComponent();
        }

        public string fileName = null;
        private static MetodoSecuencial metS = new MetodoSecuencial();
        private static MetodoParalelo metP = new MetodoParalelo();


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
            if (checkBox9.Checked == true)
            {
                //De forma secuencial
                if (fileName != null)
                {
                    //Do something with the file, for example read text from it
                    string ext = Path.GetExtension(fileName);
                    if (ext.Equals(".txt"))
                    {
                        metS.leerTexto(fileName);
                    }
                    else if (ext.Equals(".doc") || ext.Equals(".docx"))
                    {
                        metS.leerWord(fileName);
                    }
                }
                Parallel.Invoke(() =>
                {
                    if (checkBox1.Checked == true)
                    {
                        //llamese al metodo de palabra de mayor longitud
                        metS.getPalabraLarga(metS.data);

                    }
                    if (checkBox2.Checked == true)
                    {
                        //llamese al metodo de "N" palabras mas comunes
                        metS.descomponerLineaS(metS.data);

                        int valor = ShowDialog("Cantidad de palabras:", "Cantidad de Palabras a buscar");
                        metS.PalabrasRepetidas(valor);

                        Func<KeyValuePair<string, int>, int> ordenar = delegate (KeyValuePair<string, int> item2)
                        {
                            return item2.Value;
                        };
                        IOrderedEnumerable<KeyValuePair<string, int>> ordenado = metS.diccionarioRepetidas.OrderByDescending(ordenar);
                        int cont2 = 0;
                        foreach (var itemx1 in ordenado)
                        {
                            if (cont2 < valor)
                            {
                                //Modificar Para que imprima en la pantalla de impresion
                                Console.WriteLine(itemx1.Key + "   " + itemx1.Value);
                                Console.Read();
                            }
                        }
                    }
                    if (checkBox3.Checked == true)
                    {
                        //llamese al metodo de numero de veces que aparece una palabra
                        string valor = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
                        metS.cantPalabraParticular(metS.data, valor);
                    }
                    if (checkBox4.Checked == true)
                    {
                        //llamese al metodo de Total de palabras
                        metS.getTotalPalabras(metS.data);
                    }
                }, () =>
                {
                    if (checkBox5.Checked == true)
                    {
                        //llamese al metodo de numero de palabras diferentes
                        metS.getPalabrasDiferentes(metS.data);
                    }
                    if (checkBox6.Checked == true)
                    {
                        //llamese al metodo de numero total de caracteres
                        metS.getTotalCaracters(metS.data);
                    }
                    if (checkBox7.Checked == true)
                    {
                        //llamese al metodo de numero de caracteres sin espacio
                        metS.getTotalCaracters(metS.data);

                    }
                    if (checkBox8.Checked == true)
                    {
                        //llamese al metodo de recuento de oraciones
                        metS.getTotalOraciones(metS.data);

                    }
                });
            }
            else if (checkBox10.Checked == true)
            {
                //hacer de manera concurrente
                if (fileName != null)
                {
                    //Do something with the file, for example read text from it
                    string ext = Path.GetExtension(fileName);
                    if (ext.Equals(".txt"))
                    {
                        metP.leerTexto(fileName);
                    }
                    else if (ext.Equals(".doc") || ext.Equals(".docx"))
                    {
                        metP.leerWord(fileName);
                    }

                }
                //Preguntar Cuales Checkbox estan activas
                Parallel.Invoke(() =>
                {
                    if (checkBox1.Checked == true)
                    {
                        //llamese al metodo de palabra de mayor longitud
                        metP.palabraLarga();

                    }
                    if (checkBox2.Checked == true)
                    {
                        //llamese al metodo de "N" palabras mas comunes
                        metP.descomponerLineaP(metP.data);
                        int valor = ShowDialog("Cantidad de palabras:", "Cantidad de Palabras a buscar");
                        metP.PalabrasRepetidas(valor);

                        Func<KeyValuePair<string, int>, int> ordenar = delegate (KeyValuePair<string, int> item2)
                        {
                            return item2.Value;
                        };
                        IOrderedEnumerable<KeyValuePair<string, int>> ordenado = metP.diccionarioRepetidas.OrderByDescending(ordenar);
                        int cont2 = 0;
                        foreach (var itemx1 in ordenado)
                        {
                            if (cont2 < valor)
                            {
                                Console.WriteLine(itemx1.Key + "   " + itemx1.Value);
                                Console.Read();
                            }
                        }
                    }
                    if (checkBox3.Checked == true)
                    {
                        //llamese al metodo de numero de veces que aparece una palabra
                        string valor = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
                        metP.palabraParticular(valor);

                    }
                    if (checkBox4.Checked == true)
                    {
                        //llamese al metodo de Total de palabras
                        metP.totalPalabrasParalelo();
                    }
                }, () =>
                {
                    if (checkBox5.Checked == true)
                    {
                        //llamese al metodo de numero de palabras diferentes
                        metP.palabrasDiferentesParalelo();
                    }
                    if (checkBox6.Checked == true)
                    {
                        //llamese al metodo de numero total de caracteres
                        metP.totalCaracteresParalelo();
                    }
                    if (checkBox7.Checked == true)
                    {
                        //llamese al metodo de numero de caracteres sin espacio
                        metP.caracteresEspaciosParalelo();

                    }
                    if (checkBox8.Checked == true)
                    {
                        //llamese al metodo de recuento de oraciones
                        metP.totalOracionesParalelo();

                    }
                });
            }
        }

        private void ejecutarTodoButton_Click(object sender, EventArgs e)
        {
            //llamese a todos los metodos uno por uno
            if (checkBox9.Checked == true)
            {
                //De forma secuencial
                if (fileName != null)
                {
                    //Do something with the file, for example read text from it
                    string ext = Path.GetExtension(fileName);
                    if (ext.Equals(".txt"))
                    {
                        metS.leerTexto(fileName);
                    }
                    else if (ext.Equals(".doc") || ext.Equals(".docx"))
                    {
                        metS.leerWord(fileName);
                    }
                }

                //llamese al metodo de palabra de mayor longitud
                metS.getPalabraLarga(metS.data);

                //llamese al metodo de "N" palabras mas comunes
                metS.descomponerLineaS(metS.data);
                int valor = ShowDialog("Cantidad de palabras:", "Cantidad de Palabras a buscar");
                metS.PalabrasRepetidas(valor);

                Func<KeyValuePair<string, int>, int> ordenar = delegate (KeyValuePair<string, int> item2)
                {
                    return item2.Value;
                };
                IOrderedEnumerable<KeyValuePair<string, int>> ordenado = metP.diccionarioRepetidas.OrderByDescending(ordenar);
                int cont2 = 0;
                foreach (var itemx1 in ordenado)
                {
                    if (cont2 < valor)
                    {
                        Console.WriteLine(itemx1.Key + "   " + itemx1.Value);
                        Console.Read();
                    }
                }

                //llamese al metodo de numero de veces que aparece una palabra
                string valorx = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
                metS.cantPalabraParticular(metS.data, valorx);

                //llamese al metodo de Total de palabras
                metS.getTotalPalabras(metS.data);

                //llamese al metodo de numero de palabras diferentes
                metS.getPalabrasDiferentes(metS.data);

                //llamese al metodo de numero total de caracteres
                metS.getTotalCaracters(metS.data);

                //llamese al metodo de numero de caracteres sin espacio
                metS.getTotalCaracters(metS.data);

                //llamese al metodo de recuento de oraciones
                metS.getTotalOraciones(metS.data);

            }
            else if (checkBox10.Checked == true)
            {
                //hacer de manera concurrente
                if (fileName != null)
                {
                    //Do something with the file, for example read text from it
                    string ext = Path.GetExtension(fileName);
                    if (ext.Equals(".txt"))
                    {
                        metP.leerTexto(fileName);
                    }
                    else if (ext.Equals(".doc") || ext.Equals(".docx"))
                    {
                        metP.leerWord(fileName);
                    }
                }
                Parallel.Invoke(()=> 
                {
                    //llamese al metodo de palabra de mayor longitud
                    metP.palabraLarga();

                    //llamese al metodo de "N" palabras mas comunes
                    metP.descomponerLineaP(metP.data);
                    int valor = ShowDialog("Cantidad de palabras:", "Cantidad de Palabras a buscar");
                    metP.PalabrasRepetidas(valor);

                    Func<KeyValuePair<string, int>, int> ordenar = delegate (KeyValuePair<string, int> item2)
                    {
                        return item2.Value;
                    };
                    IOrderedEnumerable<KeyValuePair<string, int>> ordenado = metP.diccionarioRepetidas.OrderByDescending(ordenar);
                    int cont2 = 0;
                    foreach (var itemx1 in ordenado)
                    {
                        if (cont2 < valor)
                        {
                            Console.WriteLine(itemx1.Key + "   " + itemx1.Value);
                            Console.Read();
                        }
                    }

                    //llamese al metodo de numero de veces que aparece una palabra
                    string valorx = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
                    metP.palabraParticular(valorx);

                    //llamese al metodo de Total de palabras
                    metP.totalPalabrasParalelo();

                }, () =>
                {
                    //llamese al metodo de numero de palabras diferentes
                    metP.palabrasDiferentesParalelo();

                    //llamese al metodo de numero total de caracteres
                    metP.totalCaracteresParalelo();

                    //llamese al metodo de numero de caracteres sin espacio
                    metP.caracteresEspaciosParalelo();

                    //llamese al metodo de recuento de oraciones
                    metP.totalOracionesParalelo();

                });
            }
        }

        private void rendimientoButton_Click(object sender, EventArgs e)
        {
            Rendimiento rendi = new Rendimiento();
            rendi.Show();
        }
    }
}
