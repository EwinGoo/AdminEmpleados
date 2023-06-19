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
        public frmDepartamentos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Instruccion GUI (Obtener informacion de la presentacion)
            RecuperarInformacion();
            conexionDAL conexion = new conexionDAL();

            MessageBox.Show("Conectado.." + conexion.ejecutarComandoSinRetornoDatos("INSERT INTO Departamentos(departamento) VALUES('programacion')"));
        }
        private void RecuperarInformacion()
        {
            DepartamentoBLL oDepartamento = new DepartamentoBLL();
            int Id = 0;int.TryParse(txtId.Text, out Id);
            oDepartamento.Id = Id;
            oDepartamento.Departamento = txtNombre.Text;
            MessageBox.Show(oDepartamento.Id.ToString());
            MessageBox.Show(oDepartamento.Departamento);

        }
    }
}
