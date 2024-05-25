using Microsoft.Win32;
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
    public partial class GUI_UPVTube : Form
    {
        private IUPVTubeService service;
        public GUI_UPVTube(IUPVTubeService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GUI_UPVTube_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nick = usuario.Text;
            string password = contraseña.Text;


            try
            {
                service.login(nick, password);
                Member loggedUser = service.userLogged();
                this.Hide();

                MenuPrincipal mainMenu = new MenuPrincipal(loggedUser, service);
                mainMenu.ShowDialog();

                this.Close();
            }

            catch (ServiceException ex) //poner una ventana sino
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro registroForm = new Registro(service);
            registroForm.Owner = this;
            registroForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuario_TextChanged(object sender, EventArgs e)
        {
            usuario = (TextBox)sender;
        }

        private void contraseña_TextChanged(object sender, EventArgs e)
        {
            contraseña = (TextBox)sender;
        }
    }
}
