using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEmpleados.BLL
{
    internal class EmpleadosBLL
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public int departamento { get; set; }
        public string correo { get; set; }
        public byte[] fotoEmpleado { get; set; }
    }
}
