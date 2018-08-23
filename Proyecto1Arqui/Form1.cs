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
        private Metodos met = new Metodos();

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

        private void ejecutarSeleccionButton_Click(object sender, EventArgs e)
        {
			
			if (checkBox1.Checked) {

			}
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
		}
    }
}
