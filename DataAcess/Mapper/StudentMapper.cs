using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class StudentMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_STUDENT_ID = "ID";
        private const string DB_COL_BANKING_STUDENT = "NAME";
        private const string DB_COL_USER_ACTIVE_STATUS = "LAST_NAME";
        private const string DB_COL_ENTRY_DATE = "AGE";
        private const string DB_COL_FIRST_NAME = "ID";
        private const string DB_COL_SECOND_NAME = "NAME";
        private const string DB_COL_LAST_NAME = "LAST_NAME";
        private const string DB_COL_SECOND_LAST_NAME = "AGE";
        private const string DB_COL_ID_TYPE = "ID";
        private const string DB_COL_IDENTIFICATION_NUMBER = "NAME";
        private const string DB_COL_BIRTHDATE = "LAST_NAME";
        private const string DB_COL_GENDER = "AGE";
        private const string DB_COL_CANTON = "ID";
        private const string DB_COL_DISTRICT = "NAME";
        private const string DB_COL_USER_TYPE = "LAST_NAME";
        private const string DB_COL_STUDENT_LOGIN = "AGE";
        private const string DB_COL_STUDENT_PASSWORD = "ID";
        private const string DB_COL_LABORAL_STATUS = "NAME";
        private const string DB_COL_WORK_ADDRESS = "LAST_NAME";
        private const string DB_COL_EMAIL = "AGE";
        private const string DB_COL_PRIMARY_PHONE = "ID";
        private const string DB_COL_SECOND_PHONE = "NAME";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            throw new NotImplementedException();
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }
    }
}
