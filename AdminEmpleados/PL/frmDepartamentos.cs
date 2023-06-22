using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AdminEmpleados.DAL;
using AdminEmpleados.BLL;

namespace AdminEmpleados.PL
{
    public partial class frmDepartamentos : Form
    {
        DepartamentosDAL oDepartamentosDAL;
        public frmDepartamentos()
        {
            oDepartamentosDAL = new DepartamentosDAL();
            InitializeComponent();
            LLenaGrid();
            LimpiarEntradas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Instruccion GUI (Obtener informacion de la presentacion)


            //Clase DAL Departamentos... Objeto que tiene la informacion de la GUI
            oDepartamentosDAL.Agregar(RecuperarInformacion());
            LLenaGrid();
            LimpiarEntradas();
        }
        private DepartamentoBLL RecuperarInformacion()
        {
            DepartamentoBLL oDepartamentoBLL = new DepartamentoBLL();
            int Id = 0;int.TryParse(txtId.Text, out Id);
            oDepartamentoBLL.Id = Id;
            oDepartamentoBLL.Departamento = txtNombre.Text;
            return oDepartamentoBLL;

        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvDepartamentos.ClearSelection();
            if (indice >= 0)
            {
                txtId.Text = dgvDepartamentos.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvDepartamentos.Rows[indice].Cells[1].Value.ToString();

                btnAgregar.Enabled = false;
                btnBorrar.Enabled = true;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Eliminar(RecuperarInformacion());
            LLenaGrid();
            LimpiarEntradas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Modificar(RecuperarInformacion());
            LLenaGrid();
            LimpiarEntradas();
        }

        public void LLenaGrid()
        {
            dgvDepartamentos.DataSource = oDepartamentosDAL.MostrarDepartamentos().Tables[0];
            dgvDepartamentos.Columns[0].HeaderText = "ID";
            dgvDepartamentos.Columns[1].HeaderText = "Nombre Departamento";

        }
        public void LimpiarEntradas()
        {
            txtId.Text = "";
            txtNombre.Text = "";

            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        // allowtouseraddrow = False
        //autosize = fill
        // textimagerelation = image before text
    }
}
