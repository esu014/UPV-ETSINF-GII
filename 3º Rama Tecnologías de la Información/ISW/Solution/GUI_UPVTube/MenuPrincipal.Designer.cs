namespace GUI_UPVTube
{
    partial class MenuPrincipal
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
            this.cerrar_session = new System.Windows.Forms.Button();
            this.evaluar_button = new System.Windows.Forms.Button();
            this.subir_button = new System.Windows.Forms.Button();
            this.Buscar_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cerrar_session
            // 
            this.cerrar_session.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrar_session.Location = new System.Drawing.Point(333, 29);
            this.cerrar_session.Margin = new System.Windows.Forms.Padding(2);
            this.cerrar_session.Name = "cerrar_session";
            this.cerrar_session.Size = new System.Drawing.Size(110, 34);
            this.cerrar_session.TabIndex = 16;
            this.cerrar_session.Text = "CERRAR SESIÓN";
            this.cerrar_session.UseVisualStyleBackColor = true;
            this.cerrar_session.Click += new System.EventHandler(this.cerrar_session_Click);
            // 
            // evaluar_button
            // 
            this.evaluar_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evaluar_button.Location = new System.Drawing.Point(116, 280);
            this.evaluar_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.evaluar_button.Name = "evaluar_button";
            this.evaluar_button.Size = new System.Drawing.Size(175, 36);
            this.evaluar_button.TabIndex = 15;
            this.evaluar_button.Text = "EVALUAR CONTENIDO";
            this.evaluar_button.UseVisualStyleBackColor = true;
            this.evaluar_button.Click += new System.EventHandler(this.evaluar_button_Click);
            // 
            // subir_button
            // 
            this.subir_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subir_button.Location = new System.Drawing.Point(116, 219);
            this.subir_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.subir_button.Name = "subir_button";
            this.subir_button.Size = new System.Drawing.Size(175, 36);
            this.subir_button.TabIndex = 14;
            this.subir_button.Text = "SUBIR CONTENIDO";
            this.subir_button.UseVisualStyleBackColor = true;
            this.subir_button.Click += new System.EventHandler(this.subir_button_Click);
            // 
            // Buscar_button
            // 
            this.Buscar_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscar_button.Location = new System.Drawing.Point(116, 155);
            this.Buscar_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Buscar_button.Name = "Buscar_button";
            this.Buscar_button.Size = new System.Drawing.Size(175, 36);
            this.Buscar_button.TabIndex = 13;
            this.Buscar_button.Text = "BUSCAR CONTENIDO";
            this.Buscar_button.UseVisualStyleBackColor = true;
            this.Buscar_button.Click += new System.EventHandler(this.Buscar_button_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(125, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 51);
            this.label6.TabIndex = 12;
            this.label6.Text = "UPVTube";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 376);
            this.Controls.Add(this.cerrar_session);
            this.Controls.Add(this.evaluar_button);
            this.Controls.Add(this.subir_button);
            this.Controls.Add(this.Buscar_button);
            this.Controls.Add(this.label6);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cerrar_session;
        private System.Windows.Forms.Button evaluar_button;
        private System.Windows.Forms.Button subir_button;
        private System.Windows.Forms.Button Buscar_button;
        private System.Windows.Forms.Label label6;
    }
}