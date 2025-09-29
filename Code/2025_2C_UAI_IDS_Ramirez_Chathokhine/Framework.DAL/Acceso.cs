using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Framework.DAL
{
    public class Acceso
    {
        SqlConnection conexion;
        // private string constring= @"Data Source=.\SQLEXPRESS01; Initial Catalog=LUG; Integrated Security = SSPI ";

        public void abrir()
        {
            try
            {
                if (conexion == null || conexion.State != ConnectionState.Open)
                {
                    conexion = new SqlConnection();
                    conexion.ConnectionString = ConfigurationManager.AppSettings["connectionString1"];
                    conexion.Open();
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error al abrir la conexion: " + Environment.NewLine + ex.Message);
            }

        }

        public void cerrar()
        {
            conexion.Close();
            conexion.Dispose();
            conexion = null;
            GC.Collect();
        }


        private SqlCommand CrearComando(string nombre, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = nombre;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;



            if (parametros != null && parametros.Count > 0)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }

            return cmd;
        }

        public int Escribir(string nombre, List<SqlParameter> parametros = null)
        {
            int filasafectadas = 0;
            abrir();

            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                SqlCommand cmd = CrearComando(nombre, parametros);
                try
                {
                    filasafectadas = cmd.ExecuteNonQuery();
                }
                catch
                {
                    filasafectadas = -1;
                }
                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
            }
            else
            {
                filasafectadas = -2;
            }
            cerrar();
            return filasafectadas;

        }






        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.String;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.Int32;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, decimal valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.Decimal;
            return parametro;
        }

        public DataTable Leer(string nombre, List<SqlParameter> parametros = null)
        {
            DataTable tabla = new DataTable();
            abrir();
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = CrearComando(nombre, parametros);
                    try
                    {
                        da.Fill(tabla);
                    }
                    catch (Exception ex)
                    {

                        //MessageBox.Show("error en acceso.leer: " + Environment.NewLine + ex.Message);
                    }

                    da.Dispose();
                }
            }
            cerrar();
            return tabla;
        }
    }
}
