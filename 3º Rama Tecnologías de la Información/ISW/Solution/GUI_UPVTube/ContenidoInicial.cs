using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPVTube.Entities;
using UPVTube.Services;

namespace GUI_UPVTube
{
    public partial class ContenidoInicial : Form
    {
        private IUPVTubeService service;
        private DateTime fechaini;
        private DateTime fechafin;
        public ContenidoInicial(IUPVTubeService service)
        {
            InitializeComponent();
            this.service = service;
            this.dataGridContenido.DataSource = service.searchContent((int)Authorized.Yes, DateTime.MinValue, DateTime.Now, "", "", null);
            this.dataGridContenido.Refresh();
        }

        private void ContenidoInicial_Load(object sender, EventArgs e)
        {
            
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaini = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            fechafin = dateTimePicker2.Value;
        }

        private void buscarContenido_button_Click(object sender, EventArgs e)
        {
            string nick = NickBox.Text;
            string subjectFullName = SubjectBox.Text;
            int subjectCode = 0;
            int auto = (int)Authorized.No;
            string title = TitleBox.Text;
            fechafin = dateTimePicker2.Value;
            fechaini = dateTimePicker1.Value;
            if(subjectFullName!=null)
            {
                subjectCode= service.searchSubject(subjectFullName);
            }
            Member logged = service.userLogged();
            if(logged.IsTeacher())
            {
                auto = 0;
            }

            IEnumerable<Content> contents = service.searchContent(auto,fechaini, fechafin, nick, title, subjectCode);
            this.dataGridContenido.DataSource = contents;
            this.dataGridContenido.Refresh();
        }

        private void verVideo_Button_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridContenido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
