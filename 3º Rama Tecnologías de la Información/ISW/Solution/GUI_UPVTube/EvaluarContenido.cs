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
    public partial class EvaluarContenido : Form
    {
        private IUPVTubeService service;
        public EvaluarContenido(IUPVTubeService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void no_autorizar_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona el contenido no autorizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Content selectedContent = (Content)selectedRow.DataBoundItem;
            Información comment = new Información(service, selectedRow, selectedContent);
            comment.ShowDialog();
            reLoad();


        }
        private void autorizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un contenido que autorizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Content selectedContent = (Content)selectedRow.DataBoundItem;
            try
            {
                // Llama al método para autorizar el contenido
                service.AuthorizeContent(selectedContent);
                reLoad();
                MessageBox.Show("Autorizado con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void reLoad()
        {
            try
            {
                //como el que evalua es un profesor, es autorizado y por tanto esta el "2" a piñon
                var contents = service.searchContent((int)Authorized.Yes,null, null, null, null, null)
                                      .Where(c => c.Authorized == Authorized.Yes); // Asumiendo que hay un estado 'Pending'
                dataGridView1.DataSource = new BindingList<Content>(contents.ToList());

            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            reLoad();
        }

        private void atras_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Configurar el texto del encabezado de las columnas
            dataGridView1.Columns["Title"].HeaderText = "Título";
            dataGridView1.Columns["UploadDate"].HeaderText = "Fecha de Subida";
            dataGridView1.Columns["Owner"].HeaderText = "Propietario";

            // Formatear la columna de fecha si es necesario
            dataGridView1.Columns["UploadDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Ajustar el ancho de las columnas, por ejemplo, para ajustarse al contenido o un ancho fijo
            dataGridView1.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["UploadDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Owner"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
    }
}
