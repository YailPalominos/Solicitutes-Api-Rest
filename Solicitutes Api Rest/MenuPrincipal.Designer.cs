namespace Solicitutes_Api_Rest
{
    partial class MenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tipoCambioBoton = new Button();
            resultado = new Label();
            SuspendLayout();
            // 
            // tipoCambioBoton
            // 
            tipoCambioBoton.Location = new Point(128, 89);
            tipoCambioBoton.Name = "tipoCambioBoton";
            tipoCambioBoton.Size = new Size(159, 23);
            tipoCambioBoton.TabIndex = 0;
            tipoCambioBoton.Text = "Obtener Resultados";
            tipoCambioBoton.UseVisualStyleBackColor = true;
            tipoCambioBoton.Click += tipoCambioBoton_Click;
            // 
            // resultado
            // 
            resultado.AutoSize = true;
            resultado.Location = new Point(12, 9);
            resultado.Name = "resultado";
            resultado.Size = new Size(59, 15);
            resultado.TabIndex = 1;
            resultado.Text = "Resultado";
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 124);
            Controls.Add(resultado);
            Controls.Add(tipoCambioBoton);
            Name = "MenuPrincipal";
            Text = "Terremotos de USGS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion




        private Button tipoCambioBoton;
        private Label resultado;
    }
}
