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
    internal class DepartamentosDAL
    {
        conexionDAL conexion;
        public DepartamentosDAL()
        {
            conexion = new conexionDAL();
        }

        public bool Agregar(DepartamentoBLL oDepartamentoBLL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Departamentos VALUES(@Departamente)");
            SQLComando.Parameters.Add("@Departamente", SqlDbType.VarChar).Value = oDepartamentoBLL.Departamento;
            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);

            //return conexion.EjecutarComandoSinRetornoDatos("INSERT INTO Departamentos(departamento) VALUES('"+oDepartamentoBLL.Departamento+"')");
        }
        public bool Eliminar(DepartamentoBLL oDepartamentoBLL)
        {
            //conexion.EjecutarComandoSinRetornoDatos("DELETE FROM Departamentos WHERE id = '" + oDepartamentoBLL.Id + "'");
            
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Departamentos WHERE ID = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oDepartamentoBLL.Id;
            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);
        }
        public bool Modificar(DepartamentoBLL oDepartamentoBLL)
        {
            //conexion.EjecutarComandoSinRetornoDatos("UPDATE Departamentos "+
            //    "SET departamento = '" + oDepartamentoBLL.Departamento + "' "+
            //   "WHERE id = '" + oDepartamentoBLL.Id + "'");

            SqlCommand SQLComando = new SqlCommand("UPDATE Departamentos SET departamento = @Departamento WHERE ID = @ID");
            SQLComando.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = oDepartamentoBLL.Departamento;
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oDepartamentoBLL.Id;

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);
        }
        public DataSet MostrarDepartamentos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Departamentos");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
