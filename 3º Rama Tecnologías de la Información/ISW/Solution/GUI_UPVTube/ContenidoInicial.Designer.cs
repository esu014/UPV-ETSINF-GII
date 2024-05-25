namespace GUI_UPVTube
{
    partial class ContenidoInicial
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
            this.a = new System.Windows.Forms.Label();
            this.atras = new System.Windows.Forms.Button();
            this.buscarContenido_button = new System.Windows.Forms.Button();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.SubjectBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NickBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.verVideo_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.Fecha_Ultima_vez = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignaturas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Público = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Subida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridContenido = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContenido)).BeginInit();
            this.SuspendLayout();
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a.Location = new System.Drawing.Point(11, 21);
            this.a.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(158, 45);
            this.a.TabIndex = 31;
            this.a.Text = "UPVTube";
            // 
            // atras
            // 
            this.atras.Location = new System.Drawing.Point(645, 21);
            this.atras.Margin = new System.Windows.Forms.Padding(2);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(84, 30);
            this.atras.TabIndex = 30;
            this.atras.Text = "ATRÁS";
            this.atras.UseVisualStyleBackColor = true;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // buscarContenido_button
            // 
            this.buscarContenido_button.Location = new System.Drawing.Point(604, 406);
            this.buscarContenido_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buscarContenido_button.Name = "buscarContenido_button";
            this.buscarContenido_button.Size = new System.Drawing.Size(137, 36);
            this.buscarContenido_button.TabIndex = 29;
            this.buscarContenido_button.Text = "FILTRAR";
            this.buscarContenido_button.UseVisualStyleBackColor = true;
            this.buscarContenido_button.Click += new System.EventHandler(this.buscarContenido_button_Click);
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(597, 150);
            this.TitleBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(144, 20);
            this.TitleBox.TabIndex = 28;
            // 
            // SubjectBox
            // 
            this.SubjectBox.Location = new System.Drawing.Point(377, 150);
            this.SubjectBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SubjectBox.Name = "SubjectBox";
            this.SubjectBox.Size = new System.Drawing.Size(144, 20);
            this.SubjectBox.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(541, 152);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Por Titulo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Por Asignatura:";
            // 
            // NickBox
            // 
            this.NickBox.Location = new System.Drawing.Point(143, 150);
            this.NickBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.NickBox.Name = "NickBox";
            this.NickBox.Size = new System.Drawing.Size(144, 20);
            this.NickBox.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Por Nick:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Por Fecha:";
            // 
            // verVideo_Button
            // 
            this.verVideo_Button.Location = new System.Drawing.Point(428, 406);
            this.verVideo_Button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.verVideo_Button.Name = "verVideo_Button";
            this.verVideo_Button.Size = new System.Drawing.Size(137, 36);
            this.verVideo_Button.TabIndex = 19;
            this.verVideo_Button.Text = "VER VIDEO";
            this.verVideo_Button.UseVisualStyleBackColor = true;
            this.verVideo_Button.Click += new System.EventHandler(this.verVideo_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Buscar Contenido:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(143, 117);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(196, 20);
            this.dateTimePicker1.TabIndex = 32;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(396, 117);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 33;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // Fecha_Ultima_vez
            // 
            this.Fecha_Ultima_vez.DataPropertyName = "ds_fecha_ultima";
            this.Fecha_Ultima_vez.HeaderText = "Fecha Visualización última";
            this.Fecha_Ultima_vez.MinimumWidth = 6;
            this.Fecha_Ultima_vez.Name = "Fecha_Ultima_vez";
            this.Fecha_Ultima_vez.Width = 125;
            // 
            // Asignaturas
            // 
            this.Asignaturas.DataPropertyName = "ds_asignaturas";
            this.Asignaturas.HeaderText = "Asignaturas";
            this.Asignaturas.MinimumWidth = 6;
            this.Asignaturas.Name = "Asignaturas";
            this.Asignaturas.Width = 125;
            // 
            // Público
            // 
            this.Público.DataPropertyName = "ds_publico";
            this.Público.HeaderText = "Público";
            this.Público.MinimumWidth = 6;
            this.Público.Name = "Público";
            this.Público.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "ds_descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 125;
            // 
            // Autor
            // 
            this.Autor.DataPropertyName = "ds_nick";
            this.Autor.HeaderText = "Autor";
            this.Autor.MinimumWidth = 6;
            this.Autor.Name = "Autor";
            this.Autor.Width = 125;
            // 
            // Titulo
            // 
            this.Titulo.DataPropertyName = "ds_titulo";
            this.Titulo.HeaderText = "Titulo";
            this.Titulo.MinimumWidth = 6;
            this.Titulo.Name = "Titulo";
            this.Titulo.Width = 125;
            // 
            // Fecha_Subida
            // 
            this.Fecha_Subida.DataPropertyName = "ds_FechaSub";
            this.Fecha_Subida.HeaderText = "Fecha_Subida";
            this.Fecha_Subida.MinimumWidth = 6;
            this.Fecha_Subida.Name = "Fecha_Subida";
            this.Fecha_Subida.Width = 125;
            // 
            // dataGridContenido
            // 
            this.dataGridContenido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridContenido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha_Subida,
            this.Titulo,
            this.Autor,
            this.Descripcion,
            this.Público,
            this.Asignaturas,
            this.Fecha_Ultima_vez});
            this.dataGridContenido.Location = new System.Drawing.Point(64, 183);
            this.dataGridContenido.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridContenido.Name = "dataGridContenido";
            this.dataGridContenido.RowHeadersWidth = 51;
            this.dataGridContenido.RowTemplate.Height = 24;
            this.dataGridContenido.Size = new System.Drawing.Size(677, 205);
            this.dataGridContenido.TabIndex = 16;
            this.dataGridContenido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridContenido_CellContentClick);
            // 
            // ContenidoInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.a);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.buscarContenido_button);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.SubjectBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NickBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.verVideo_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridContenido);
            this.Name = "ContenidoInicial";
            this.Text = "ContenidoInicial";
            this.Load += new System.EventHandler(this.ContenidoInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContenido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label a;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.Button buscarContenido_button;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.TextBox SubjectBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NickBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button verVideo_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Ultima_vez;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignaturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Público;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Autor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Subida;
        private System.Windows.Forms.DataGridView dataGridContenido;
    }
}