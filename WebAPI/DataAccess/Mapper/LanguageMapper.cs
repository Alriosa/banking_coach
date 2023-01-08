using DataAccess.Dao;
using DataAccess.Mapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class LanguageMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_LANGUAGE_ID = "Language_ID";
        private const string DB_COL_LANGUAGE = "Language";
        private const string DB_COL_LEVEL = "Level";
        private const string DB_COL_ENTRY_DATE = "Entry_Date";
        private const string DB_COL_STUDENT_ID = "Student_ID";
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_INSERT_TBL_LANGUAGE_STUDENT" };

            var language = (Language)entity;

            operation.AddVarcharParam(DB_COL_LANGUAGE, language.LanguageName);
            operation.AddVarcharParam(DB_COL_LEVEL, language.Level);
            operation.AddIntParam(DB_COL_STUDENT_ID, language.StudentID);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_ALL_TBL_LANGUAGES" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_LANGUAGE_BY_ID" };

            var language = (Language)entity;
            operation.AddIntParam(DB_COL_LANGUAGE_ID, language.LanguageID);

            return operation;
        }
        public SqlOperation GetRetriveStatementByStudent(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_SELECT_TBL_LANGUAGE_BY_STUDENT" };

            var language = (Language)entity;
            operation.AddIntParam(DB_COL_STUDENT_ID, language.StudentID);

            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TBL_LANGUAGE_STUDENT" };

            var language = (Language)entity;

            operation.AddIntParam(DB_COL_LANGUAGE_ID, language.LanguageID);
            operation.AddVarcharParam(DB_COL_LANGUAGE, language.LanguageName);
            operation.AddVarcharParam(DB_COL_LEVEL, language.Level);
            operation.AddIntParam(DB_COL_STUDENT_ID, language.StudentID);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_TBL_LANGUAGE" };

            var language = (Language)entity;
            operation.AddIntParam(DB_COL_LANGUAGE_ID, language.LanguageID);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var language = BuildObject(row);
                lstResults.Add(language);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var language = new Language
            {
                LanguageID = GetIntValue(row, DB_COL_LANGUAGE_ID),
                LanguageName = GetStringValue(row, DB_COL_LANGUAGE),
                Level = GetStringValue(row, DB_COL_LEVEL),
                EntryDate = GetDateValue(row, DB_COL_ENTRY_DATE),
                StudentID = GetIntValue(row, DB_COL_STUDENT_ID),
            };

            return language;
        }
    }
}
