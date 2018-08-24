using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1Arqui
{
    public partial class Rendimiento : Form
    {
        public Rendimiento()
        {
            InitializeComponent();
        }

        private void salirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = (int)(performanceCounter1.NextValue());
            label1.Text = "CPU: " + progressBar1.Value.ToString() + "%";

            progressBar2.Value = (int)(performanceCounter2.NextValue());
            label2.Text = "RAM: " + progressBar2.Value.ToString() + "%";

            chart1.Series["CPU"].Points.AddY(progressBar1.Value);
            chart1.Series["RAM"].Points.AddY(progressBar2.Value);

            if (progressBar1.Value > 20)
            {
                progressBar1.ForeColor = Color.Red;
            }
            else
            {
                progressBar1.ForeColor = Color.LimeGreen;
            }

            if (progressBar2.Value > 20)
            {
                progressBar2.ForeColor = Color.Red;
            }
            else
            {
                progressBar2.ForeColor = Color.LimeGreen;
            }
        }

        private void Rendimiento_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
