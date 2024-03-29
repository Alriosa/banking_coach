﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Dao
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set;}

        public SqlOperation()
        {
            Parameters=new List<SqlParameter>();
        }

        public void AddVarcharParam(string paramName, string paramValue)
        {
            var param = new SqlParameter("@SP_" + paramName, SqlDbType.VarChar)
            {
                Value = paramValue                            
            };
            Parameters.Add(param);
        }

        public void AddIntParam(string paramName, int paramValue)
        {
            var param = new SqlParameter("@SP_" + paramName, SqlDbType.Int)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddDoubleParam(string paramName, double paramValue)
        {
            var param = new SqlParameter("@SP_" + paramName, SqlDbType.Decimal)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddDateTimeParam(string paramName, DateTime paramValue)
        {
            var param = new SqlParameter("@SP_" + paramName, SqlDbType.DateTime)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddCharParam(string paramName, char paramValue)
        {
            var param = new SqlParameter("@SP_" + paramName, SqlDbType.Char)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }
    }
}
