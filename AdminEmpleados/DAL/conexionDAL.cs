using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdminEmpleados.DAL
{
    internal class conexionDAL
    {
        private string CadenaConexion = "data source=EDWIN\\AZBITS;initial catalog=dbSistema;integrated security=true";
        SqlConnection Conexion;

        public SqlConnection EstablecerConexion()
        {
            this.Conexion = new SqlConnection(this.CadenaConexion);
            return this.Conexion;

        }
        /* Metodos INSERT, UPDATE, DELETE */
        public bool EjecutarComandoSinRetornoDatos(string strComando)
        {
            try {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = strComando;
                comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                comando.ExecuteNonQuery();
                Conexion.Close();
                return true;
            } catch {
                return false;
            }
        }
        // Sobrecarga Metodo INSERT, DELETE, UPDATE
        public bool EjecutarComandoSinRetornoDatos(SqlCommand SQLComando)
        {
            try
            {
                SqlCommand Comando = SQLComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /* SELECT (Retorno Datos) */
        public DataSet EjecutarSentencia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;
            }
            catch
            {
                return DS;

            }
        }
        public int EjecutarComandoRetornaID(SqlCommand SQLComando)
        {
            try
            {
                SqlCommand comando = SQLComando;
                comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                int IDInsertado = (int)comando.ExecuteScalar();
                Conexion.Close();
                return IDInsertado;

            }
            catch
            {
                return 1;
            }
        }

    }
}
