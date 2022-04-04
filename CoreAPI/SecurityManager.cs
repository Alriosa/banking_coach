﻿using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class SecurityManager : BaseManager
    {
        private SecurityCrudFactory crudSecurity;

        public SecurityManager()
        {
            crudSecurity = new SecurityCrudFactory();
        }
        public Security RetrieveById(Security security)
        {
            Security c = null;
            try
            {
                c = crudSecurity.Retrieve<Security> (security) ;
            }
            catch (Exception ex)
            {
                //ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }
    }

    
}
