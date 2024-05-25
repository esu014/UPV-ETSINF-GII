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
    public partial class ContenidoVideo : Form
    {
        private IUPVTubeService service;
        private String titulo;
        private String autor;
        private String fecha_sub;
        private String comentari;
        public ContenidoVideo(string titulo, string autor, String fecha_sub, IUPVTubeService service)
        {
            InitializeComponent();
            this.service = service;
            this.titulo = titulo;
            this.autor = autor;
            this.fecha_sub = fecha_sub;
        }

        private void ContenidoVideo_Load(object sender, EventArgs e)
        {

        }

        private void tituloTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void autorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fechaSubidaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void añadir_comentario_Click(object sender, EventArgs e)
        {
            titulo = tituloTextBox.Text;
            autor = autorTextBox.Text;
            comentari = comentario.Text;
            Member owner = service.userLogged();
            DateTime fecha_sb = DateTime.Now;
            service.AddComment2(titulo, autor, fecha_sb, comentari, owner);
        }
    }
}
