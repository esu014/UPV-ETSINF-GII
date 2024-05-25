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
    public partial class Información : Form
    {
        private IUPVTubeService service;
        private DataGridViewRow selectedRow;
        private Content selectedContent;
        public Información(IUPVTubeService service, DataGridViewRow selectedRow, Content selectedContent)
        {
            InitializeComponent();
            this.service = service;
            this.selectedRow = selectedRow;
            this.selectedContent = selectedContent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string commentario = comentario.Text;
            Member owner = service.userLogged();
            DateTime writingData = DateTime.Now;
            Comment comment = new Comment(commentario, writingData, selectedContent, owner);
            try
            {
                // Llama al método para autorizar el contenido
                service.NotAuthorizeContent(selectedContent, comment);
                DialogResult answer = MessageBox.Show(this, "No autorizado con exito\nSe enviara un correo con el motivo de rechazo", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
