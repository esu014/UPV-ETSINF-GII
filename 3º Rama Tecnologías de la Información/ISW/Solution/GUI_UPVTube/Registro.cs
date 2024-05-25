using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPVTube.Services;

namespace GUI_UPVTube
{
    public partial class Registro : Form
    {
        private IUPVTubeService service;
        private Form onwerForm = null;
        public Registro(IUPVTubeService service)
        {
            InitializeComponent();
            this.service = service;
        }
        public void setOwnerForm(Form form)
        {
            this.onwerForm = form;
        }
        private void volverInicioSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            if (this.onwerForm != null)
            {
                this.onwerForm.Show();
            }
        }

        private void RegistrarButton_Click(object sender, EventArgs e)
        {
            string email = email_txt.Text;
            string fullname = nombre.Text;
            string user = usuario.Text;
            string pasword = contraseña.Text;
            try
            {
                service.singUp(email, fullname, user, pasword);
                this.Close();

                // Aquí puedes también limpiar los campos o cerrar el formulario si lo prefieres.
            }
            catch (ServiceException ex)
            {
                // Muestra un MessageBox con el error
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void atrasButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void contraseña_TextChanged(object sender, EventArgs e)
        {
            contraseña = (TextBox)sender;
        }

        private void usuario_TextChanged(object sender, EventArgs e)
        {
            usuario = (TextBox)sender; 
        }

        private void email_txt_TextChanged(object sender, EventArgs e)
        {
            email_txt = (TextBox)sender;
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {
            nombre = (TextBox)sender;  
        }
    }
}
