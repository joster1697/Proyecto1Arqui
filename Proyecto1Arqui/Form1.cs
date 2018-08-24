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
        private static Metodos met = new Metodos();

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

        private void ejecutarSeleccionButton_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                //Do something with the file, for example read text from it
                string ext = Path.GetExtension(fileName);
                if (ext.Equals(".txt"))
                {
                    met.leerTexto(fileName);
                }
                else if (ext.Equals(".doc") || ext.Equals(".docx"))
                {
                    met.leerWord(fileName);
                }
            }
            if (checkBox9.Checked == true)
            {
                //De forma secuencial
                if (checkBox1.Checked == true)
                {
                    //llamese al metodo de palabra de mayor longitud

                }
                if (checkBox2.Checked == true)
                {
                    //llamese al metodo de "N" palabras mas comunes
                    int valor = ShowDialog("Cantidad de palabras:", "Cantidad de Palabras a buscar");


                }
                if (checkBox3.Checked == true)
                {
                    //llamese al metodo de numero de veces que aparece una palabra

                }
                if (checkBox4.Checked == true)
                {
                    //llamese al metodo de Total de palabras

                }
                if (checkBox5.Checked == true)
                {
                    //llamese al metodo de numero de palabras diferentes

                }
                if (checkBox6.Checked == true)
                {
                    //llamese al metodo de numero total de caracteres

                }
                if (checkBox7.Checked == true)
                {
                    //llamese al metodo de numero de caracteres sin espacio

                }
                if (checkBox8.Checked == true)
                {
                    //llamese al metodo de recuento de oraciones

                }
            }
            else if (checkBox10.Checked == true)
            {
                //hacer de manera concurrente
            }

        }

        private void ejecutarTodoButton_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                //Do something with the file, for example read text from it
                string ext = Path.GetExtension(fileName);
                if (ext.Equals(".txt"))
                {
                    met.leerTexto(fileName);
                }
                else if (ext.Equals(".doc") || ext.Equals(".docx"))
                {
                    met.leerWord(fileName);
                }
            }
            //llamese a todos los metodos uno por uno

        }
    }
}
