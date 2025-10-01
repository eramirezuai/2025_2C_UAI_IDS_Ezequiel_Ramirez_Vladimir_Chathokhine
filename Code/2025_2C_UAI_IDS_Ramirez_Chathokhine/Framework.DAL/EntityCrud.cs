using Framework.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Framework.DAL
{
    public abstract class EntityCrud<T, E> : ICrud<T> where E : Enum
    {
        protected IAccess access;
        protected IToParameterMapper<T, E> toParameterMapper;
        protected IToEntityMapper<T, E> toEntityMapper;

        public EntityCrud(IAccess access, IToParameterMapper<T, E> toParameterMapper, IToEntityMapper<T, E> toEntityMapper)
        {
            this.access = access;
            this.toParameterMapper = toParameterMapper;
            this.toEntityMapper = toEntityMapper;
        }

        protected void Create(T data, E type, string addSpName)
        {
            if(string.IsNullOrEmpty(addSpName))
            {
                throw new InvalidOperationException("No stored procedure name defined for add operation");
            }
            try
            {
                var parameters = toParameterMapper.MapToParameters(data, type);
                var sqlParameters = new List<SqlParameter>();
                access.Open();
                foreach (var param in parameters)
                {
                    sqlParameters.Add(access.CreateParameter(param.Key, param.Value));
                }
                access.Write(addSpName, sqlParameters);
            }
            finally
            {
                access.Close();
            }
        }

        public abstract void Create(T data);

        protected IEnumerable<T> Retrieve(E type, string retrieveSpName)
        {
            if (string.IsNullOrEmpty(retrieveSpName))
            {
                throw new InvalidOperationException("No stored procedure name defined for retrieve operation");
            }
            try
            {
                access.Open();
                var table = access.Read(retrieveSpName);
                return ParametersFromDataTable(table).Select(p => toEntityMapper.MapToEntity(p, type));
            }
            finally
            {
                access.Close();
            }
        }

        public abstract IEnumerable<T> Retrieve();

        protected IEnumerable<T> Retrieve(Dictionary<string, object> args, E type, string retrieveSpName)
        {
            if (string.IsNullOrEmpty(retrieveSpName))
            {
                throw new InvalidOperationException("No stored procedure name defined for retrieve operation");
            }
            try
            {
                var sqlParameters = new List<SqlParameter>();
                access.Open();
                foreach(var arg in args)
                {
                    sqlParameters.Add(access.CreateParameter(arg.Key, arg.Value));
                }
                var table = access.Read(retrieveSpName);
                return ParametersFromDataTable(table).Select(p => toEntityMapper.MapToEntity(p, type));
            }
            finally
            {
                access.Close();
            }
        }

        public abstract IEnumerable<T> Retrieve(Dictionary<string, object> args);

        protected void Update(T data, E type, string updateSpName)
        {
            if (string.IsNullOrEmpty(updateSpName))
            {
                throw new InvalidOperationException("No stored procedure name defined for update operation");
            }
            try
            {
                var parameters = toParameterMapper.MapToParameters(data, type);
                var sqlParameters = new List<SqlParameter>();
                access.Open();
                foreach (var param in parameters)
                {
                    sqlParameters.Add(access.CreateParameter(param.Key, param.Value));
                }
                access.Write(updateSpName, sqlParameters);
            }
            finally
            {
                access.Close();
            }
        }

        public abstract void Update(T data);

        protected void Delete(T data, E type, string deleteSpName)
        {
            if (string.IsNullOrEmpty(deleteSpName))
            {
                throw new InvalidOperationException("No stored procedure name defined for delete operation");
            }
            try
            {
                var parameters = toParameterMapper.MapToParameters(data, type);
                var sqlParameters = new List<SqlParameter>();
                access.Open();
                foreach (var param in parameters)
                {
                    sqlParameters.Add(access.CreateParameter(param.Key, param.Value));
                }
                access.Write(deleteSpName, sqlParameters);
            }
            finally
            {
                access.Close();
            }
        }

        public abstract void Delete(T data);

        protected void Delete(T data, Dictionary<string, object> args, E type, string deleteSpName)
        {
            if (string.IsNullOrEmpty(deleteSpName))
            {
                throw new InvalidOperationException("No stored procedure name defined for delete operation");
            }
            try
            {
                var parameters = toParameterMapper.MapToParameters(data, type);
                var sqlParameters = new List<SqlParameter>();
                access.Open();
                foreach (var param in parameters)
                {
                    sqlParameters.Add(access.CreateParameter(param.Key, param.Value));
                }
                foreach (var arg in args)
                {
                    sqlParameters.Add(access.CreateParameter(arg.Key, arg.Value));
                }
                access.Write(deleteSpName, sqlParameters);
            }
            finally
            {
                access.Close();
            }
        }

        public abstract void Delete(T data, Dictionary<string, object> args);

        private IEnumerable<Dictionary<string, object>> ParametersFromDataTable(DataTable table)
        {
            var ret = new List<Dictionary<string, object>>();
            var columnNames = new List<string>();
            foreach (DataColumn column in table.Columns)
            {
                columnNames.Add(column.ColumnName);
            }
            foreach (DataRow row in table.Rows)
            {
                var rowData = new Dictionary<string, object>();
                foreach (var columnName in columnNames)
                {
                    rowData[columnName] = row[columnName];
                }
                ret.Add(rowData);
            }
            return ret;
        }
    }
}
