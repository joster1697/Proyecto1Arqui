using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Proyecto1Arqui
{
    public partial class Rendimiento : Form
    {
        bool iscontinue = true;

        public Rendimiento()
        {
            InitializeComponent();
        }

        private void salirButton_Click(object sender, EventArgs e)
        {
            iscontinue = false;
            this.Close();
        }
        
        private void Rendimiento_Load(object sender, EventArgs e)
        {
            // Esta propiedad es necesaria para poder crear thread en modo "no seguro"
            CheckForIllegalCrossThreadCalls = false;

            // Invoca hilos en modo "no seguro", se llama el hilo que obtiene el uso de la CPU
            Thread demoThread = new Thread(new ThreadStart(this.CPUInfoThread));

            demoThread.Start();
            timer1.Start();

        }

        private void CPUInfoThread()
        {
            try
            {

                Thread thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        while (iscontinue)
                        {
                            progressBar1.Value = (int)(performanceCounter1.NextValue());
                            label1.Text = "CPU: " + progressBar1.Value.ToString() + "%";

                            progressBar2.Value = (int)(performanceCounter2.NextValue());
                            label2.Text = "RAM: " + progressBar2.Value.ToString() + "%";

                            chart1.Series["CPU"].Points.AddY(progressBar1.Value);
                            chart1.Series["RAM"].Points.AddY(progressBar2.Value);

                            Thread.Sleep(1000);

                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }

                }));

                thread.Priority = ThreadPriority.Highest;
                thread.IsBackground = true;
                thread.Start();//Start the Thread

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Rendimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            iscontinue = false;
            this.Dispose();
            this.Close();
        }
    }
}
