using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class ListMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_LIST = "ID_LIST";
        private const string DB_COL_P_CODE = "P_Code";
        private const string DB_COL_CODE = "Code";
        private const string DB_COL_VALUE = "Name_Value";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var optionList = new OptionList
            {
                PCode = GetStringValue(row, DB_COL_P_CODE),
                Code = GetStringValue(row, DB_COL_CODE),
                Value = GetStringValue(row, DB_COL_VALUE)
            };

            return optionList;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var optionList = BuildObject(row);
                lstResults.Add(optionList);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllProvincesStatement()
        {
            throw new NotImplementedException();

        }

        public SqlOperation GetRetrieveByListStatement(BaseEntity entity, string list_id)
        {
            var procedure = "RET_" + list_id;
            var operation = new SqlOperation { ProcedureName = procedure };
            
            //var p = (OptionList)entity;
            //operation.AddVarcharParam(DB_COL_P_CODE, p.PCode);

            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
