namespace Proyecto1Arqui
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox10 = new System.Windows.Forms.CheckBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.ejecutarTodoButton = new System.Windows.Forms.Button();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.ejecutarSeleccionButton = new System.Windows.Forms.Button();
			this.ArchivoNombre = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.explorarButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.rendimientoButton = new System.Windows.Forms.Button();
			this.cargando = new System.Windows.Forms.Label();
			this.panelResultados = new System.Windows.Forms.Panel();
			this.rPalabraCaracteres = new System.Windows.Forms.Label();
			this.rOraciones = new System.Windows.Forms.Label();
			this.rEspacios = new System.Windows.Forms.Label();
			this.rTotalCaracteres = new System.Windows.Forms.Label();
			this.rPalabrasDiferentes = new System.Windows.Forms.Label();
			this.rTotalPalabras = new System.Windows.Forms.Label();
			this.rPalabraVeces = new System.Windows.Forms.Label();
			this.rPalabrasComunes = new System.Windows.Forms.Label();
			this.rMayorLongitud = new System.Windows.Forms.Label();
			this.checkBox11 = new System.Windows.Forms.CheckBox();
			this.tiempoTotal = new System.Windows.Forms.Label();
			this.panelResultados.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(306, 123);
			this.label1.MinimumSize = new System.Drawing.Size(50, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 17);
			this.label1.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(55, 174);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(185, 13);
			this.label5.TabIndex = 40;
			this.label5.Text = "Seleccione las operaciones a realizar:";
			// 
			// checkBox10
			// 
			this.checkBox10.AutoSize = true;
			this.checkBox10.Location = new System.Drawing.Point(211, 129);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new System.Drawing.Size(136, 17);
			this.checkBox10.TabIndex = 39;
			this.checkBox10.Text = "Operación Concurrente";
			this.checkBox10.UseVisualStyleBackColor = true;
			// 
			// checkBox9
			// 
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new System.Drawing.Point(58, 129);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(131, 17);
			this.checkBox9.TabIndex = 38;
			this.checkBox9.Text = "Operación Secuencial";
			this.checkBox9.UseVisualStyleBackColor = true;
			// 
			// ejecutarTodoButton
			// 
			this.ejecutarTodoButton.Location = new System.Drawing.Point(202, 462);
			this.ejecutarTodoButton.Name = "ejecutarTodoButton";
			this.ejecutarTodoButton.Size = new System.Drawing.Size(97, 23);
			this.ejecutarTodoButton.TabIndex = 37;
			this.ejecutarTodoButton.Text = "Ejecutar Todo";
			this.ejecutarTodoButton.UseVisualStyleBackColor = true;
			this.ejecutarTodoButton.Click += new System.EventHandler(this.ejecutarTodoButton_Click);
			// 
			// checkBox8
			// 
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new System.Drawing.Point(58, 364);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(152, 17);
			this.checkBox8.TabIndex = 36;
			this.checkBox8.Text = "8. Recuento de oraciones:";
			this.checkBox8.UseVisualStyleBackColor = true;
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(58, 341);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(207, 17);
			this.checkBox7.TabIndex = 35;
			this.checkBox7.Text = "7. Número de caracteres sin espacios:";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(58, 318);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(169, 17);
			this.checkBox6.TabIndex = 34;
			this.checkBox6.Text = "6. Número total de caracteres:";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(58, 295);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(185, 17);
			this.checkBox5.TabIndex = 33;
			this.checkBox5.Text = "5. Número de palabras diferentes:";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(58, 271);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(123, 17);
			this.checkBox4.TabIndex = 32;
			this.checkBox4.Text = "4. Total de palabras:";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(58, 247);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(241, 17);
			this.checkBox3.TabIndex = 31;
			this.checkBox3.Text = "3. Número de veces que aparce una palabra:";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(58, 224);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(170, 17);
			this.checkBox2.TabIndex = 30;
			this.checkBox2.Text = "2. \"N\" palabras más comunes:";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(58, 200);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(163, 17);
			this.checkBox1.TabIndex = 29;
			this.checkBox1.Text = "1. Palabra de mayor longitud:";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// ejecutarSeleccionButton
			// 
			this.ejecutarSeleccionButton.Location = new System.Drawing.Point(60, 462);
			this.ejecutarSeleccionButton.Name = "ejecutarSeleccionButton";
			this.ejecutarSeleccionButton.Size = new System.Drawing.Size(122, 23);
			this.ejecutarSeleccionButton.TabIndex = 28;
			this.ejecutarSeleccionButton.Text = "Ejecutar Selección";
			this.ejecutarSeleccionButton.UseVisualStyleBackColor = true;
			this.ejecutarSeleccionButton.Click += new System.EventHandler(this.ejecutarSeleccionButton_Click);
			// 
			// ArchivoNombre
			// 
			this.ArchivoNombre.Location = new System.Drawing.Point(237, 59);
			this.ArchivoNombre.Name = "ArchivoNombre";
			this.ArchivoNombre.Size = new System.Drawing.Size(286, 20);
			this.ArchivoNombre.TabIndex = 27;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(57, 66);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 13);
			this.label4.TabIndex = 26;
			this.label4.Text = "Ubicacion del archivo:";
			// 
			// explorarButton
			// 
			this.explorarButton.Location = new System.Drawing.Point(564, 57);
			this.explorarButton.Name = "explorarButton";
			this.explorarButton.Size = new System.Drawing.Size(75, 23);
			this.explorarButton.TabIndex = 25;
			this.explorarButton.Text = "Explorar";
			this.explorarButton.UseVisualStyleBackColor = true;
			this.explorarButton.Click += new System.EventHandler(this.explorarButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(288, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 13);
			this.label3.TabIndex = 24;
			this.label3.Text = "Abrir documento de Texto";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(439, 174);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 22;
			this.label2.Text = "Resultados";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(55, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(121, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Determine la Modalidad:";
			// 
			// rendimientoButton
			// 
			this.rendimientoButton.Location = new System.Drawing.Point(564, 462);
			this.rendimientoButton.Name = "rendimientoButton";
			this.rendimientoButton.Size = new System.Drawing.Size(75, 23);
			this.rendimientoButton.TabIndex = 41;
			this.rendimientoButton.Text = "Rendimiento";
			this.rendimientoButton.UseVisualStyleBackColor = true;
			this.rendimientoButton.Click += new System.EventHandler(this.rendimientoButton_Click);
			// 
			// cargando
			// 
			this.cargando.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cargando.Location = new System.Drawing.Point(466, 123);
			this.cargando.Name = "cargando";
			this.cargando.Size = new System.Drawing.Size(247, 20);
			this.cargando.TabIndex = 43;
			// 
			// panelResultados
			// 
			this.panelResultados.AutoScroll = true;
			this.panelResultados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelResultados.Controls.Add(this.rPalabraCaracteres);
			this.panelResultados.Controls.Add(this.rOraciones);
			this.panelResultados.Controls.Add(this.rEspacios);
			this.panelResultados.Controls.Add(this.rTotalCaracteres);
			this.panelResultados.Controls.Add(this.rPalabrasDiferentes);
			this.panelResultados.Controls.Add(this.rTotalPalabras);
			this.panelResultados.Controls.Add(this.rPalabraVeces);
			this.panelResultados.Controls.Add(this.rPalabrasComunes);
			this.panelResultados.Controls.Add(this.rMayorLongitud);
			this.panelResultados.Location = new System.Drawing.Point(346, 190);
			this.panelResultados.Name = "panelResultados";
			this.panelResultados.Size = new System.Drawing.Size(418, 247);
			this.panelResultados.TabIndex = 44;
			this.panelResultados.Paint += new System.Windows.Forms.PaintEventHandler(this.panelResultados_Paint);
			// 
			// rPalabraCaracteres
			// 
			this.rPalabraCaracteres.AutoSize = true;
			this.rPalabraCaracteres.Location = new System.Drawing.Point(23, 199);
			this.rPalabraCaracteres.Name = "rPalabraCaracteres";
			this.rPalabraCaracteres.Size = new System.Drawing.Size(0, 13);
			this.rPalabraCaracteres.TabIndex = 46;
			// 
			// rOraciones
			// 
			this.rOraciones.AutoSize = true;
			this.rOraciones.Location = new System.Drawing.Point(23, 176);
			this.rOraciones.Name = "rOraciones";
			this.rOraciones.Size = new System.Drawing.Size(0, 13);
			this.rOraciones.TabIndex = 7;
			// 
			// rEspacios
			// 
			this.rEspacios.AutoSize = true;
			this.rEspacios.Location = new System.Drawing.Point(23, 153);
			this.rEspacios.Name = "rEspacios";
			this.rEspacios.Size = new System.Drawing.Size(0, 13);
			this.rEspacios.TabIndex = 6;
			// 
			// rTotalCaracteres
			// 
			this.rTotalCaracteres.AutoSize = true;
			this.rTotalCaracteres.Location = new System.Drawing.Point(23, 130);
			this.rTotalCaracteres.Name = "rTotalCaracteres";
			this.rTotalCaracteres.Size = new System.Drawing.Size(0, 13);
			this.rTotalCaracteres.TabIndex = 5;
			// 
			// rPalabrasDiferentes
			// 
			this.rPalabrasDiferentes.AutoSize = true;
			this.rPalabrasDiferentes.Location = new System.Drawing.Point(23, 107);
			this.rPalabrasDiferentes.Name = "rPalabrasDiferentes";
			this.rPalabrasDiferentes.Size = new System.Drawing.Size(0, 13);
			this.rPalabrasDiferentes.TabIndex = 4;
			// 
			// rTotalPalabras
			// 
			this.rTotalPalabras.AutoSize = true;
			this.rTotalPalabras.Location = new System.Drawing.Point(23, 83);
			this.rTotalPalabras.Name = "rTotalPalabras";
			this.rTotalPalabras.Size = new System.Drawing.Size(0, 13);
			this.rTotalPalabras.TabIndex = 3;
			// 
			// rPalabraVeces
			// 
			this.rPalabraVeces.AutoSize = true;
			this.rPalabraVeces.Location = new System.Drawing.Point(23, 59);
			this.rPalabraVeces.Name = "rPalabraVeces";
			this.rPalabraVeces.Size = new System.Drawing.Size(0, 13);
			this.rPalabraVeces.TabIndex = 2;
			// 
			// rPalabrasComunes
			// 
			this.rPalabrasComunes.AutoSize = true;
			this.rPalabrasComunes.Location = new System.Drawing.Point(23, 33);
			this.rPalabrasComunes.Name = "rPalabrasComunes";
			this.rPalabrasComunes.Size = new System.Drawing.Size(0, 13);
			this.rPalabrasComunes.TabIndex = 1;
			// 
			// rMayorLongitud
			// 
			this.rMayorLongitud.AutoSize = true;
			this.rMayorLongitud.Location = new System.Drawing.Point(23, 8);
			this.rMayorLongitud.Name = "rMayorLongitud";
			this.rMayorLongitud.Size = new System.Drawing.Size(0, 13);
			this.rMayorLongitud.TabIndex = 0;
			// 
			// checkBox11
			// 
			this.checkBox11.AutoSize = true;
			this.checkBox11.Location = new System.Drawing.Point(58, 387);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new System.Drawing.Size(153, 17);
			this.checkBox11.TabIndex = 45;
			this.checkBox11.Text = "9. Palabras por caracteres:";
			this.checkBox11.UseVisualStyleBackColor = true;
			// 
			// tiempoTotal
			// 
			this.tiempoTotal.AutoSize = true;
			this.tiempoTotal.Location = new System.Drawing.Point(561, 174);
			this.tiempoTotal.Name = "tiempoTotal";
			this.tiempoTotal.Size = new System.Drawing.Size(0, 13);
			this.tiempoTotal.TabIndex = 46;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 497);
			this.Controls.Add(this.tiempoTotal);
			this.Controls.Add(this.checkBox11);
			this.Controls.Add(this.panelResultados);
			this.Controls.Add(this.cargando);
			this.Controls.Add(this.rendimientoButton);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.checkBox10);
			this.Controls.Add(this.checkBox9);
			this.Controls.Add(this.ejecutarTodoButton);
			this.Controls.Add(this.checkBox8);
			this.Controls.Add(this.checkBox7);
			this.Controls.Add(this.checkBox6);
			this.Controls.Add(this.checkBox5);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.ejecutarSeleccionButton);
			this.Controls.Add(this.ArchivoNombre);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.explorarButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panelResultados.ResumeLayout(false);
			this.panelResultados.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.Button ejecutarTodoButton;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button ejecutarSeleccionButton;
        private System.Windows.Forms.TextBox ArchivoNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button explorarButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button rendimientoButton;
		private System.Windows.Forms.Label cargando;
		private System.Windows.Forms.Panel panelResultados;
		private System.Windows.Forms.Label rMayorLongitud;
		private System.Windows.Forms.Label rPalabrasComunes;
		private System.Windows.Forms.Label rPalabraVeces;
		private System.Windows.Forms.Label rTotalPalabras;
		private System.Windows.Forms.Label rPalabrasDiferentes;
		private System.Windows.Forms.Label rTotalCaracteres;
		private System.Windows.Forms.Label rEspacios;
		private System.Windows.Forms.Label rOraciones;
		private System.Windows.Forms.Label rPalabraCaracteres;
		private System.Windows.Forms.CheckBox checkBox11;
		private System.Windows.Forms.Label tiempoTotal;
	}
}

