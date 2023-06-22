using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AdminEmpleados.PL;

namespace AdminEmpleados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            frmDepartamentos formDepartamentos = new frmDepartamentos();
            formDepartamentos.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados formEmpleados= new frmEmpleados();
            formEmpleados.Show();
        }
    }
}
