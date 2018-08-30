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
                this.listBox1.Items.Add("Metodos Secuencial: ");

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
                        ArrayList list = metS.getPalabraLarga(metS.data);

                        string resultado = "Palabra más larga: ";
                        foreach (var item in list)
                        {
                            resultado += item + ", ";
                        }
                        this.listBox1.Items.Add(resultado);
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
                        this.listBox1.Items.Add(result);
                    }
                    if (checkBox3.Checked == true)
                    {
                        //llamese al metodo de numero de veces que aparece una palabra
                        string valor = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
                        int x = metS.cantPalabraParticular(metS.data, valor);
                        this.listBox1.Items.Add(valor + "Número veces que aparece: " + x.ToString());
                    }
                    if (checkBox4.Checked == true)
                    {
                        //llamese al metodo de Total de palabras
                        int x = metS.getTotalPalabras(metS.data);
                        this.listBox1.Items.Add("Número total de palabras: " + x.ToString());
                    }

                    if (checkBox5.Checked == true)
                    {
                        //llamese al metodo de numero de palabras diferentes
                        int x = metS.getPalabrasDiferentes(metS.data);
                        this.listBox1.Items.Add("Número palabras diferentes: " + x.ToString());
                    }
                    if (checkBox6.Checked == true)
                    {
                        //llamese al metodo de numero total de caracteres
                        int x = metS.getTotalCaracters(metS.data);
                        this.listBox1.Items.Add("Número total de caracteres: " + x.ToString());
                    }
                    if (checkBox7.Checked == true)
                    {
                        //llamese al metodo de numero de caracteres sin espacio
                        int x = metS.getCaracteresEspacios(metS.data);
                        this.listBox1.Items.Add("Número total de caracteres sin espacios: " + x.ToString());
                    }
                    if (checkBox8.Checked == true)
                    {
                        //llamese al metodo de recuento de oraciones
                        int x = metS.getTotalOraciones(metS.data);
                        this.listBox1.Items.Add("Número de oraciones: " + x.ToString());
                    }
                });
            }
            else if (checkBox10.Checked == true)
            {
                this.listBox1.Items.Add("Metodos Concurrentes: ");

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
                        string resultado = "Palabra más larga: ";
                        ArrayList list = metP.palabraLarga();
                        foreach (var item in list)
                        {
                            resultado += item + ", ";
                        }
                        this.listBox1.Items.Add(resultado);

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
                        string result = "Palabras más comunes: ";
                        foreach (var itemx1 in ordenado)
                        {
                            if (cont2 < valor)
                            {
                                cont2 += 1;
                                result += itemx1.Key + " " + itemx1.Value + ", ";
                            }
                        }
                        this.listBox1.Items.Add(result);
                    }
                    if (checkBox3.Checked == true)
                    {
                        //llamese al metodo de numero de veces que aparece una palabra
                        string valor = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
                        int x = metP.palabraParticular(valor);
                        this.listBox1.Items.Add(valor + "Número veces que aparece: " + x.ToString());
                    }
                    if (checkBox4.Checked == true)
                    {
                        //llamese al metodo de Total de palabras
                        int x = metP.totalPalabrasParalelo();
                        this.listBox1.Items.Add("Número total de palabras: " + x.ToString());
                    }

                    if (checkBox5.Checked == true)
                    {
                        //llamese al metodo de numero de palabras diferentes
                        int x = metP.palabrasDiferentesParalelo();
                        this.listBox1.Items.Add("Número palabras diferentes: " + x.ToString());
                    }
                    if (checkBox6.Checked == true)
                    {
                        //llamese al metodo de numero total de caracteres
                        int x = metP.totalCaracteresParalelo();
                        this.listBox1.Items.Add("Número total de caracteres: " + x.ToString());
                    }
                    if (checkBox7.Checked == true)
                    {
                        //llamese al metodo de numero de caracteres sin espacio
                        int x = metP.caracteresEspaciosParalelo();
                        this.listBox1.Items.Add("Número caracteres sin espacio: " + x.ToString());
                    }
                    if (checkBox8.Checked == true)
                    {
                        //llamese al metodo de recuento de oraciones
                        int x = metP.totalOracionesParalelo();
                        this.listBox1.Items.Add("Número total de oraciones: " + x.ToString());
                    }
                });
            }
        }

        private void ejecutarTodoButton_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Add("Metodos Secuencial: ");

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
                ArrayList list = metS.getPalabraLarga(metS.data);

                string resultado = "Palabra más larga: ";
                foreach (var item in list)
                {
                    resultado += item + ", ";
                }
                this.listBox1.Items.Add(resultado);


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
                this.listBox1.Items.Add(result);


                //llamese al metodo de numero de veces que aparece una palabra
                string valorx = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
                int x = metS.cantPalabraParticular(metS.data, valorx);
                this.listBox1.Items.Add(valor + "Número veces que aparece: " + x.ToString());


                //llamese al metodo de Total de palabras
                int x2 = metS.getTotalPalabras(metS.data);
                this.listBox1.Items.Add("Número total de palabras: " + x2.ToString());



                //llamese al metodo de numero de palabras diferentes
                int x3 = metS.getPalabrasDiferentes(metS.data);
                this.listBox1.Items.Add("Número palabras diferentes: " + x3.ToString());

                //llamese al metodo de numero total de caracteres
                int x4 = metS.getTotalCaracters(metS.data);
                this.listBox1.Items.Add("Número total de caracteres: " + x4.ToString());

                //llamese al metodo de numero de caracteres sin espacio
                int x5 = metS.getCaracteresEspacios(metS.data);
                this.listBox1.Items.Add("Número total de caracteres sin espacios: " + x5.ToString());

                //llamese al metodo de recuento de oraciones
                int x6 = metS.getTotalOraciones(metS.data);
                this.listBox1.Items.Add("Número de oraciones: " + x6.ToString());

            }
            else if (checkBox10.Checked == true)
            {
                this.listBox1.Items.Add("Metodos Concurrentes: ");

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
                Parallel.Invoke(() =>
                {

                    //llamese al metodo de palabra de mayor longitud
                    string resultado = "Palabra más larga: ";
                    ArrayList list = metP.palabraLarga();
                    foreach (var item in list)
                    {
                        resultado += item + ", ";
                    }
                    this.listBox1.Items.Add(resultado);


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
                    string result = "Palabras más comunes: ";
                    foreach (var itemx1 in ordenado)
                    {
                        if (cont2 < valor)
                        {
                            cont2 += 1;
                            result += itemx1.Key + " " + itemx1.Value + ", ";
                        }
                    }
                    this.listBox1.Items.Add(result);

                    //llamese al metodo de numero de veces que aparece una palabra
                    string valorx = ShowDialog2("Indique la palabra", "Numero de veces de una palabra");
                    int x = metP.palabraParticular(valorx);
                    this.listBox1.Items.Add(valor + "Número veces que aparece: " + x.ToString());

                    //llamese al metodo de Total de palabras
                    int x1 = metP.totalPalabrasParalelo();
                    this.listBox1.Items.Add("Número total de palabras: " + x1.ToString());

                    //llamese al metodo de numero de palabras diferentes
                    int x2 = metP.palabrasDiferentesParalelo();
                    this.listBox1.Items.Add("Número palabras diferentes: " + x2.ToString());

                    //llamese al metodo de numero total de caracteres
                    int x3 = metP.totalCaracteresParalelo();
                    this.listBox1.Items.Add("Número total de caracteres: " + x3.ToString());

                    //llamese al metodo de numero de caracteres sin espacio
                    int x4 = metP.caracteresEspaciosParalelo();
                    this.listBox1.Items.Add("Número caracteres sin espacio: " + x4.ToString());


                    //llamese al metodo de recuento de oraciones
                    int x5 = metP.totalOracionesParalelo();
                    this.listBox1.Items.Add("Número total de oraciones: " + x5.ToString());


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
