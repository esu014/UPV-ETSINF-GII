namespace GUI_UPVTube
{
    partial class SubirContenido
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
            this.atras = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.url_t = new System.Windows.Forms.TextBox();
            this.titulo_t = new System.Windows.Forms.TextBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.chequea = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.añadir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // atras
            // 
            this.atras.Location = new System.Drawing.Point(468, 101);
            this.atras.Margin = new System.Windows.Forms.Padding(2);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(84, 30);
            this.atras.TabIndex = 34;
            this.atras.Text = "ATRÁS";
            this.atras.UseVisualStyleBackColor = true;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(92, 182);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 19);
            this.label10.TabIndex = 33;
            this.label10.Text = "Título";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(271, 136);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 19);
            this.label9.TabIndex = 32;
            this.label9.Text = "Fecha";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(92, 225);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 19);
            this.label8.TabIndex = 31;
            this.label8.Text = "Descripción";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(92, 313);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 19);
            this.label7.TabIndex = 30;
            this.label7.Text = "El contenido es público";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // url_t
            // 
            this.url_t.Location = new System.Drawing.Point(96, 160);
            this.url_t.Margin = new System.Windows.Forms.Padding(2);
            this.url_t.Name = "url_t";
            this.url_t.Size = new System.Drawing.Size(360, 20);
            this.url_t.TabIndex = 29;
            this.url_t.TextChanged += new System.EventHandler(this.url_t_TextChanged);
            // 
            // titulo_t
            // 
            this.titulo_t.Location = new System.Drawing.Point(96, 203);
            this.titulo_t.Margin = new System.Windows.Forms.Padding(2);
            this.titulo_t.Name = "titulo_t";
            this.titulo_t.Size = new System.Drawing.Size(360, 20);
            this.titulo_t.TabIndex = 28;
            this.titulo_t.TextChanged += new System.EventHandler(this.titulo_t_TextChanged);
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(322, 136);
            this.fecha.Margin = new System.Windows.Forms.Padding(2);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(134, 20);
            this.fecha.TabIndex = 27;
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(96, 246);
            this.descripcion.Margin = new System.Windows.Forms.Padding(2);
            this.descripcion.Multiline = true;
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(360, 45);
            this.descripcion.TabIndex = 26;
            this.descripcion.TextChanged += new System.EventHandler(this.descripcion_TextChanged);
            // 
            // chequea
            // 
            this.chequea.AutoSize = true;
            this.chequea.Location = new System.Drawing.Point(259, 318);
            this.chequea.Margin = new System.Windows.Forms.Padding(2);
            this.chequea.Name = "chequea";
            this.chequea.Size = new System.Drawing.Size(15, 14);
            this.chequea.TabIndex = 25;
            this.chequea.UseVisualStyleBackColor = true;
            this.chequea.CheckedChanged += new System.EventHandler(this.chequea_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(92, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "URL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 45);
            this.label1.TabIndex = 23;
            this.label1.Text = "UPVTube";
            // 
            // añadir
            // 
            this.añadir.Location = new System.Drawing.Point(319, 340);
            this.añadir.Margin = new System.Windows.Forms.Padding(2);
            this.añadir.Name = "añadir";
            this.añadir.Size = new System.Drawing.Size(137, 36);
            this.añadir.TabIndex = 22;
            this.añadir.Text = "PUBLICAR";
            this.añadir.UseVisualStyleBackColor = true;
            this.añadir.Click += new System.EventHandler(this.añadir_Click);
            // 
            // SubirContenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 450);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.url_t);
            this.Controls.Add(this.titulo_t);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.chequea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.añadir);
            this.Name = "SubirContenido";
            this.Text = "SubirContenido";
            this.Load += new System.EventHandler(this.SubirContenido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox url_t;
        private System.Windows.Forms.TextBox titulo_t;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.CheckBox chequea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button añadir;
    }
}