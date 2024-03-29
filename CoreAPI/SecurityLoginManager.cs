﻿using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class SecurityLoginManager : BaseManager
    {
        private SecurityCrudFactory crudSecurity;

        public SecurityLoginManager()
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
                throw new Exception("Error al retornar datos", ex);
            }

            return c;
        }

        public Security RetrieveByEmail(Security security)
        {
            Security c = null;
            try
            {
                c = crudSecurity.RetrieveByEmail<Security>(security);
            }
            catch (Exception ex)
            {
                //ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }

            return c;
        }
    }

    
}
