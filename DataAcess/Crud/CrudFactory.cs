﻿using System.Collections.Generic;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao dao;
        public string COMPONENT = "DATA_ACCESS";

        public abstract void Create(BaseEntity entity);
        public abstract T Retrieve<T>(BaseEntity entity);   
        public abstract T RetrieveByUserLogin<T>(BaseEntity entity);   
        public abstract List<T> RetrieveAll<T>();
        public abstract List<T> RetrieveAllById<T>(BaseEntity entity);
        public abstract void Update(BaseEntity entity);
        public abstract void Delete(BaseEntity entity);
        
    }
}
