namespace ServidorKinectPizarra
{
    partial class Angulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.barraAngulo = new System.Windows.Forms.TrackBar();
            this.restablecer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.barraAngulo)).BeginInit();
            this.SuspendLayout();
            // 
            // barraAngulo
            // 
            this.barraAngulo.Location = new System.Drawing.Point(30, 12);
            this.barraAngulo.Maximum = 27;
            this.barraAngulo.Minimum = -27;
            this.barraAngulo.Name = "barraAngulo";
            this.barraAngulo.Size = new System.Drawing.Size(308, 45);
            this.barraAngulo.TabIndex = 2;
            this.barraAngulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.barraAngulo_MouseUp);
            // 
            // restablecer
            // 
            this.restablecer.Location = new System.Drawing.Point(137, 52);
            this.restablecer.Name = "restablecer";
            this.restablecer.Size = new System.Drawing.Size(91, 28);
            this.restablecer.TabIndex = 3;
            this.restablecer.Text = "Restablecer";
            this.restablecer.UseVisualStyleBackColor = true;
            this.restablecer.Click += new System.EventHandler(this.restablecer_Click);
            // 
            // Angulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 92);
            this.Controls.Add(this.restablecer);
            this.Controls.Add(this.barraAngulo);
            this.Name = "Angulo";
            this.Text = "Angulo";
            ((System.ComponentModel.ISupportInitialize)(this.barraAngulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar barraAngulo;
        private System.Windows.Forms.Button restablecer;
    }
}