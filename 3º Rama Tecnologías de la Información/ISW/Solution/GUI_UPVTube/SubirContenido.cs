using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPVTube.Entities;
using UPVTube.Services;

namespace GUI_UPVTube
{
    public partial class SubirContenido : Form
    {
        private IUPVTubeService service;
        public SubirContenido(IUPVTubeService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void SubirContenido_Load(object sender, EventArgs e)
        {

        }

        private void añadir_Click(object sender, EventArgs e)
        {
            string url = url_t.Text;
            string description = descripcion.Text;
            bool isPublic = chequea.Checked;
            string title = titulo_t.Text;
            if (url != "" && description !="" && title !="")
            {
                DateTime date = fecha.Value;
                Member owner = service.userLogged();

                Content c = new Content(url, description, isPublic, title, date, owner);

                try
                {
                    service.AddContent(c);
                    MessageBox.Show("Contenido añadido con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, rellene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chequea_CheckedChanged(object sender, EventArgs e)
        {
            chequea = (CheckBox)sender;
        }

        private void url_t_TextChanged(object sender, EventArgs e)
        {
            url_t = (TextBox)sender;
        }

        private void titulo_t_TextChanged(object sender, EventArgs e)
        {
            titulo_t = (TextBox)sender;
        }

        private void descripcion_TextChanged(object sender, EventArgs e)
        {
            descripcion = (TextBox)sender;
        }
    }
}
