using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Framework.DAL
{
    public interface IAccess
    {
        void Open();
        void Close();
        SqlParameter CreateParameter(string name, object value);
        int Write(string nombre, IEnumerable<SqlParameter> parameters = null);
        DataTable Read(string nombre, IEnumerable<SqlParameter> parameters = null);
    }
}