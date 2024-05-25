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
    public partial class MenuPrincipal : Form
    {
        private Member LoggedMember;
        private IUPVTubeService service;
        public MenuPrincipal(Member member, IUPVTubeService service)
        {
            InitializeComponent();
            LoggedMember = member;
            ConfigureUIBasedOnRole();
            this.service = service;
        }
        private void ConfigureUIBasedOnRole()
        {
            Buscar_button.Enabled = true; // Todos los usuarios pueden buscar

            if (LoggedMember.IsTeacher())
            {
                subir_button.Enabled = true;
                evaluar_button.Enabled = true;
            }
            else if (LoggedMember.IsStudent())
            {
                subir_button.Enabled = true;
                evaluar_button.Enabled = false;
            }
            else
            {
                subir_button.Enabled = false;
                evaluar_button.Enabled = false;
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Buscar_button_Click(object sender, EventArgs e)
        {
            ContenidoInicial contenidoForm = new ContenidoInicial(service);
            contenidoForm.Show();
        }

        private void subir_button_Click(object sender, EventArgs e)
        {
            SubirContenido subirForm = new SubirContenido(service);
            subirForm.Show();
        }

        private void evaluar_button_Click(object sender, EventArgs e)
        {
            EvaluarContenido evaluarContenidoForm = new EvaluarContenido(service);
            evaluarContenidoForm.Show();
        }

        private void cerrar_session_Click(object sender, EventArgs e)
        {
            service.logout();
            this.Hide();
            this.Close();
            GUI_UPVTube loginForm = new GUI_UPVTube(service);
            loginForm.ShowDialog();
        }
    }
}
