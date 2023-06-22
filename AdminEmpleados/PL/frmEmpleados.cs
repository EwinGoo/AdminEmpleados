using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AdminEmpleados.DAL;
using AdminEmpleados.BLL;

namespace AdminEmpleados.PL
{
    public partial class frmEmpleados : Form
    {
        byte[] imagenByte;
        EmpleadosDAL oEmpleadosDAL;
        public frmEmpleados()
        {
            InitializeComponent();
            oEmpleadosDAL = new EmpleadosDAL();
            LLenaGrid();
            LimpiarEntradas();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            DepartamentosDAL oDepartamentos = new DepartamentosDAL();
            cbxDepartamento.DataSource = oDepartamentos.MostrarDepartamentos().Tables[0];
            cbxDepartamento.DisplayMember = "departamento";
            cbxDepartamento.ValueMember = "id";

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();
            selectorImagen.Title = "Seleccionar imagen";
            if (selectorImagen.ShowDialog()==DialogResult.OK)
            {
                picFoto.Image = Image.FromStream(selectorImagen.OpenFile());
                MemoryStream memoria = new MemoryStream();
                picFoto.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);
                imagenByte = memoria.ToArray();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            oEmpleadosDAL.Agregar(RecolectarDatos());
            LLenaGrid();
            LimpiarEntradas();
        }
        private EmpleadosBLL RecolectarDatos()
        {
            EmpleadosBLL oEmpleados = new EmpleadosBLL();
            int codigoEmpleado = 1;

            int.TryParse(txtId.Text, out codigoEmpleado);

            oEmpleados.Id = codigoEmpleado;
            oEmpleados.nombre = txtNombre.Text;
            oEmpleados.paterno = txtPaterno.Text;
            oEmpleados.materno = txtMaterno.Text;
            oEmpleados.correo = txtCorreo.Text;

            int IdDepartamento = 0;
            int.TryParse(cbxDepartamento.SelectedValue.ToString(), out IdDepartamento);

            oEmpleados.departamento = IdDepartamento;
            oEmpleados.fotoEmpleado = imagenByte;

            return oEmpleados;
        }
        public void LLenaGrid()
        {
            dgvEmpleados.DataSource = oEmpleadosDAL.MostrarEmpleados().Tables[0];
            dgvEmpleados.Columns[0].HeaderText = "ID";
            dgvEmpleados.Columns[1].HeaderText = "Nombre";
            dgvEmpleados.Columns[2].HeaderText = "Paterno";
            dgvEmpleados.Columns[3].HeaderText = "Materno";
            dgvEmpleados.Columns[4].HeaderText = "Correo";
            dgvEmpleados.Columns[5].HeaderText = "Departamento";


        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oEmpleadosDAL.Eliminar(RecuperarInformacion());
            LLenaGrid();
            LimpiarEntradas();
        }
        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvEmpleados.ClearSelection();
            if (indice >= 0)
            {
                txtId.Text = dgvEmpleados.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvEmpleados.Rows[indice].Cells[1].Value.ToString();
                txtPaterno.Text = dgvEmpleados.Rows[indice].Cells[2].Value.ToString();
                txtMaterno.Text = dgvEmpleados.Rows[indice].Cells[3].Value.ToString();
                txtCorreo.Text = dgvEmpleados.Rows[indice].Cells[4].Value.ToString();
                

                btnAgregar.Enabled = false;
                btnBorrar.Enabled = true;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
            }


        }
        private EmpleadosBLL RecuperarInformacion()
        {
            EmpleadosBLL oEmpleadoBLL = new EmpleadosBLL();
            int Id = 0; int.TryParse(txtId.Text, out Id);
            oEmpleadoBLL.Id = Id;
            oEmpleadoBLL.nombre = txtNombre.Text;
            oEmpleadoBLL.paterno = txtPaterno.Text;
            oEmpleadoBLL.materno = txtMaterno.Text;
            oEmpleadoBLL.correo = txtCorreo.Text;
            return oEmpleadoBLL;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();

        }
        public void LimpiarEntradas()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            txtCorreo.Text = "";
            picFoto.Image = null;

            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        
    }
    //size mode = strech image
}
