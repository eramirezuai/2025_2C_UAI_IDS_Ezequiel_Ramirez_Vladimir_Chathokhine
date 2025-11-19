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
    public class Access : IAccess
    {
        SqlConnection connection;

        public void Open()
        {
            try
            {
                if (connection == null || connection.State != ConnectionState.Open)
                {
                    connection = new SqlConnection();
                    connection.ConnectionString = ConfigurationManager.AppSettings["connectionString1"];
                    connection.Open();
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error al abrir la connection: " + Environment.NewLine + ex.Message);
            }

        }

        public void Close()
        {
            connection.Close();
            connection.Dispose();
            connection = null;
            GC.Collect();
        }


        private SqlCommand CreateCommand(string name, IEnumerable<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = name;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;

            if (parameters != null && parameters.Any())
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }

            return cmd;
        }

        public int Write(string name, IEnumerable<SqlParameter> parameters = null)
        {
            int filasafectadas = 0;
            Open();

            if (connection != null && connection.State == ConnectionState.Open)
            {
                SqlCommand cmd = CreateCommand(name, parameters);
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
            Close();
            return filasafectadas;

        }



        public SqlParameter CreateParameter(string name, object value)
        {
            if (value is string)
            {
                return CreateParameter(name, (string)value);
            }
            else if (value is int)
            {
                return CreateParameter(name, (int)value);
            }
            else if (value is decimal)
            {
                return CreateParameter(name, (decimal)value);
            }
            else if (value is long)
            {
                return CreateParameter(name, (long)value);
            }
            else if (value is DateTime)
            {
                return CreateParameter(name, (DateTime)value);
            }

            else { throw new NotSupportedException("Data type not implemented in Access"); }
        }


        public SqlParameter CreateParameter(string name, string value)
        {
            SqlParameter parameter = new SqlParameter(name, value);
            parameter.DbType = DbType.String;
            return parameter;
        }

        public SqlParameter CreateParameter(string name, int value)
        {
            SqlParameter parameter = new SqlParameter(name, value);
            parameter.DbType = DbType.Int32;
            return parameter;
        }

        public SqlParameter CreateParameter(string name, decimal value)
        {
            SqlParameter parameter = new SqlParameter(name, value);
            parameter.DbType = DbType.Decimal;
            return parameter;
        }

        public SqlParameter CreateParameter(string name, DateTime value)
        {
            SqlParameter parameter = new SqlParameter(name, value);
            parameter.DbType = DbType.DateTime;
            return parameter;
        }

        public DataTable Read(string name, IEnumerable<SqlParameter> parameters = null)
        {
            DataTable table = new DataTable();
            Open();
            if (connection != null && connection.State == ConnectionState.Open)
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = CreateCommand(name, parameters);
                    try
                    {
                        da.Fill(table);
                    }
                    catch (Exception ex)
                    {

                        //MessageBox.Show("error en acceso.leer: " + Environment.NewLine + ex.Message);
                    }

                    da.Dispose();
                }
            }
            Close();
            return table;
        }


    }
}
