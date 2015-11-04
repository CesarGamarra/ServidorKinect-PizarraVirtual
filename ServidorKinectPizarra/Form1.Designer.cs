namespace ServidorKinectPizarra
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.trayBar = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuBar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemConectar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDesconectar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAngulo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayBar
            // 
            this.trayBar.ContextMenuStrip = this.menuBar;
            this.trayBar.Icon = ((System.Drawing.Icon)(resources.GetObject("trayBar.Icon")));
            this.trayBar.Text = "notifyIcon1";
            this.trayBar.Visible = true;
            this.trayBar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayBar_MouseDoubleClick);
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemConectar,
            this.menuItemDesconectar,
            this.menuItemAngulo,
            this.toolStripSeparator1,
            this.menuItemSalir});
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(198, 98);
            // 
            // menuItemConectar
            // 
            this.menuItemConectar.Name = "menuItemConectar";
            this.menuItemConectar.Size = new System.Drawing.Size(197, 22);
            this.menuItemConectar.Text = "Conectar Kinect";
            this.menuItemConectar.Click += new System.EventHandler(this.menuItemConectar_Click);
            // 
            // menuItemDesconectar
            // 
            this.menuItemDesconectar.Name = "menuItemDesconectar";
            this.menuItemDesconectar.Size = new System.Drawing.Size(197, 22);
            this.menuItemDesconectar.Text = "Desconectar Kinect";
            this.menuItemDesconectar.Click += new System.EventHandler(this.menuItemDesconectar_Click);
            // 
            // menuItemAngulo
            // 
            this.menuItemAngulo.Name = "menuItemAngulo";
            this.menuItemAngulo.Size = new System.Drawing.Size(197, 22);
            this.menuItemAngulo.Text = "Cambiar Angulo Kinect";
            this.menuItemAngulo.Click += new System.EventHandler(this.menuItemAngulo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // menuItemSalir
            // 
            this.menuItemSalir.Name = "menuItemSalir";
            this.menuItemSalir.Size = new System.Drawing.Size(197, 22);
            this.menuItemSalir.Text = "Salir";
            this.menuItemSalir.Click += new System.EventHandler(this.menuItemSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 118);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Aplicacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayBar;
        private System.Windows.Forms.ContextMenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemSalir;
        private System.Windows.Forms.ToolStripMenuItem menuItemConectar;
        private System.Windows.Forms.ToolStripMenuItem menuItemDesconectar;
        private System.Windows.Forms.ToolStripMenuItem menuItemAngulo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

