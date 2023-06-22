using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using AdminEmpleados.BLL;

namespace AdminEmpleados.DAL
{
    internal class EmpleadosDAL
    {
        conexionDAL conexion;
        public EmpleadosDAL()
        {
            conexion = new conexionDAL();
        }
        public bool Agregar(EmpleadosBLL oEmpleadosBLL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO empleados(nombre,paterno,materno,correo,foto) OUTPUT INSERTED.id VALUES(@nombre,@paterno,@materno,@correo,@foto)");
            SQLComando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = oEmpleadosBLL.nombre;
            SQLComando.Parameters.Add("@paterno", SqlDbType.VarChar).Value = oEmpleadosBLL.paterno;
            SQLComando.Parameters.Add("@materno", SqlDbType.VarChar).Value = oEmpleadosBLL.materno;
            SQLComando.Parameters.Add("@correo", SqlDbType.VarChar).Value = oEmpleadosBLL.correo;
            SQLComando.Parameters.Add("@foto", SqlDbType.Binary).Value = oEmpleadosBLL.fotoEmpleado;

            int IDNuevo = conexion.EjecutarComandoRetornaID(SQLComando);

            SqlCommand SQLComandoEmpDep = new SqlCommand("INSERT INTO EmpleadoDepartamento VALUES(@id_departamento,@id_empleado)");
            SQLComandoEmpDep.Parameters.Add("@id_departamento", SqlDbType.Int).Value = oEmpleadosBLL.departamento;
            SQLComandoEmpDep.Parameters.Add("@id_empleado", SqlDbType.Int).Value = IDNuevo;

            return conexion.EjecutarComandoSinRetornoDatos(SQLComandoEmpDep);

            //return conexion.EjecutarComandoSinRetornoDatos("INSERT INTO Departamentos(departamento) VALUES('"+oDepartamentoBLL.Departamento+"')");
        }
        public DataSet MostrarEmpleados()
        {
            String Consulta;
            Consulta = "SELECT e.id,nombre,paterno,materno,correo,d.departamento,d.id id_dep " +
                       "FROM Empleados e left join EmpleadoDepartamento ed on ed.id_empleado = e.id " +
                       "left join Departamentos d on ed.id_departamento = d.id";
            SqlCommand sentencia = new SqlCommand(Consulta);
            return conexion.EjecutarSentencia(sentencia);
        }
        public bool Eliminar(EmpleadosBLL oEmpleadosBLL)
        {
            //conexion.EjecutarComandoSinRetornoDatos("DELETE FROM Departamentos WHERE id = '" + oDepartamentoBLL.Id + "'");

            SqlCommand SQLComando = new SqlCommand("DELETE FROM empleados WHERE ID = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oEmpleadosBLL.Id;

            conexion.EjecutarComandoSinRetornoDatos(SQLComando);
            
            SQLComando = new SqlCommand("DELETE FROM EmpleadoDepartamento WHERE id_empleado = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oEmpleadosBLL.Id;
            
            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);
        }
    }
}
