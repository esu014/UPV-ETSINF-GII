namespace GUI_UPVTube
{
    partial class EvaluarContenido
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.autorizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.atras_btn = new System.Windows.Forms.Button();
            this.no_autorizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(58, 99);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(352, 194);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(326, 65);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 30);
            this.button3.TabIndex = 12;
            this.button3.Text = "REFRESCAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // autorizar
            // 
            this.autorizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autorizar.Location = new System.Drawing.Point(294, 306);
            this.autorizar.Margin = new System.Windows.Forms.Padding(2);
            this.autorizar.Name = "autorizar";
            this.autorizar.Size = new System.Drawing.Size(116, 30);
            this.autorizar.TabIndex = 11;
            this.autorizar.Text = "AUTORIZAR";
            this.autorizar.UseVisualStyleBackColor = true;
            this.autorizar.Click += new System.EventHandler(this.autorizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 45);
            this.label1.TabIndex = 10;
            this.label1.Text = "UPVTube";
            // 
            // atras_btn
            // 
            this.atras_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atras_btn.Location = new System.Drawing.Point(411, 34);
            this.atras_btn.Margin = new System.Windows.Forms.Padding(2);
            this.atras_btn.Name = "atras_btn";
            this.atras_btn.Size = new System.Drawing.Size(84, 30);
            this.atras_btn.TabIndex = 9;
            this.atras_btn.Text = "ATRÁS";
            this.atras_btn.UseVisualStyleBackColor = true;
            this.atras_btn.Click += new System.EventHandler(this.atras_btn_Click);
            // 
            // no_autorizar
            // 
            this.no_autorizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_autorizar.Location = new System.Drawing.Point(174, 306);
            this.no_autorizar.Margin = new System.Windows.Forms.Padding(2);
            this.no_autorizar.Name = "no_autorizar";
            this.no_autorizar.Size = new System.Drawing.Size(116, 30);
            this.no_autorizar.TabIndex = 8;
            this.no_autorizar.Text = "NO AUTORIZAR";
            this.no_autorizar.UseVisualStyleBackColor = true;
            this.no_autorizar.Click += new System.EventHandler(this.no_autorizar_Click);
            // 
            // EvaluarContenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 366);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.autorizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atras_btn);
            this.Controls.Add(this.no_autorizar);
            this.Name = "EvaluarContenido";
            this.Text = "EvaluarContenido";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button autorizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button atras_btn;
        private System.Windows.Forms.Button no_autorizar;
    }
}