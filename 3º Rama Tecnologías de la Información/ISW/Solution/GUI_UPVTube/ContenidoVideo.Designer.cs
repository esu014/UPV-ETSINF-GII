namespace GUI_UPVTube
{
    partial class ContenidoVideo
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
            this.VTube = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comentario = new System.Windows.Forms.TextBox();
            this.fechaSubidaTextBox = new System.Windows.Forms.TextBox();
            this.autorTextBox = new System.Windows.Forms.TextBox();
            this.tituloTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.añadir_comentario = new System.Windows.Forms.Button();
            this.comentariosdataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComentrio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.comentariosdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VTube
            // 
            this.VTube.AutoSize = true;
            this.VTube.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VTube.Location = new System.Drawing.Point(91, 59);
            this.VTube.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VTube.Name = "VTube";
            this.VTube.Size = new System.Drawing.Size(158, 45);
            this.VTube.TabIndex = 25;
            this.VTube.Text = "UPVTube";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(626, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 30);
            this.button1.TabIndex = 24;
            this.button1.Text = "Atrás";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comentario
            // 
            this.comentario.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comentario.Location = new System.Drawing.Point(114, 363);
            this.comentario.Margin = new System.Windows.Forms.Padding(2);
            this.comentario.Name = "comentario";
            this.comentario.Size = new System.Drawing.Size(447, 27);
            this.comentario.TabIndex = 23;
            // 
            // fechaSubidaTextBox
            // 
            this.fechaSubidaTextBox.Location = new System.Drawing.Point(406, 148);
            this.fechaSubidaTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.fechaSubidaTextBox.Name = "fechaSubidaTextBox";
            this.fechaSubidaTextBox.Size = new System.Drawing.Size(170, 20);
            this.fechaSubidaTextBox.TabIndex = 22;
            this.fechaSubidaTextBox.TextChanged += new System.EventHandler(this.fechaSubidaTextBox_TextChanged);
            // 
            // autorTextBox
            // 
            this.autorTextBox.Location = new System.Drawing.Point(167, 144);
            this.autorTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.autorTextBox.Name = "autorTextBox";
            this.autorTextBox.Size = new System.Drawing.Size(170, 20);
            this.autorTextBox.TabIndex = 21;
            this.autorTextBox.TextChanged += new System.EventHandler(this.autorTextBox_TextChanged);
            // 
            // tituloTextBox
            // 
            this.tituloTextBox.Location = new System.Drawing.Point(167, 122);
            this.tituloTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tituloTextBox.Name = "tituloTextBox";
            this.tituloTextBox.Size = new System.Drawing.Size(170, 20);
            this.tituloTextBox.TabIndex = 20;
            this.tituloTextBox.TextChanged += new System.EventHandler(this.tituloTextBox_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(406, 118);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(291, 20);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Fecha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Autor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Titulo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Url:";
            // 
            // añadir_comentario
            // 
            this.añadir_comentario.Location = new System.Drawing.Point(565, 362);
            this.añadir_comentario.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.añadir_comentario.Name = "añadir_comentario";
            this.añadir_comentario.Size = new System.Drawing.Size(145, 30);
            this.añadir_comentario.TabIndex = 14;
            this.añadir_comentario.Text = "AÑADIR COMENTARIO";
            this.añadir_comentario.UseVisualStyleBackColor = true;
            this.añadir_comentario.Click += new System.EventHandler(this.añadir_comentario_Click);
            // 
            // comentariosdataGridView
            // 
            this.comentariosdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.comentariosdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUsuario,
            this.ColumnComentrio});
            this.comentariosdataGridView.Location = new System.Drawing.Point(114, 180);
            this.comentariosdataGridView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comentariosdataGridView.Name = "comentariosdataGridView";
            this.comentariosdataGridView.RowHeadersWidth = 51;
            this.comentariosdataGridView.RowTemplate.Height = 24;
            this.comentariosdataGridView.Size = new System.Drawing.Size(596, 148);
            this.comentariosdataGridView.TabIndex = 13;
            // 
            // ColumnUsuario
            // 
            this.ColumnUsuario.HeaderText = "Usuario";
            this.ColumnUsuario.MinimumWidth = 6;
            this.ColumnUsuario.Name = "ColumnUsuario";
            this.ColumnUsuario.Width = 200;
            // 
            // ColumnComentrio
            // 
            this.ColumnComentrio.HeaderText = "Comentario";
            this.ColumnComentrio.MinimumWidth = 6;
            this.ColumnComentrio.Name = "ColumnComentrio";
            this.ColumnComentrio.Width = 550;
            // 
            // ContenidoVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VTube);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comentario);
            this.Controls.Add(this.fechaSubidaTextBox);
            this.Controls.Add(this.autorTextBox);
            this.Controls.Add(this.tituloTextBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.añadir_comentario);
            this.Controls.Add(this.comentariosdataGridView);
            this.Name = "ContenidoVideo";
            this.Text = "ContenidoVideo";
            this.Load += new System.EventHandler(this.ContenidoVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comentariosdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VTube;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox comentario;
        private System.Windows.Forms.TextBox fechaSubidaTextBox;
        private System.Windows.Forms.TextBox autorTextBox;
        private System.Windows.Forms.TextBox tituloTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button añadir_comentario;
        private System.Windows.Forms.DataGridView comentariosdataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComentrio;
    }
}