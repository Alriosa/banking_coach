using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
    public class SysAdminManager : BaseManager
    {
        private SysAdminCrudFactory crudSysAdmin;

        public SysAdminManager()
        {
            crudSysAdmin = new SysAdminCrudFactory();
        }

        public void Create(SysAdmin sysAdmin)
        {
          try
            {

               // if (temp.AdminLogin.Equals("0"))
                  crudSysAdmin.Create(sysAdmin);
                    
              // else
             //       throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al insertar datos", ex);
            }
        }

        public SysAdmin RetrieveByUserLogin(SysAdmin sysAdmin)
        {
            SysAdmin c = null;
            try
            {
                c = crudSysAdmin.RetrieveByUserLogin<SysAdmin>(sysAdmin);
                /* if (c == null)
                 {
                     throw new BussinessException(4);
                 }*/
            }
            catch (Exception ex)
            {
                //s ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }

            return c;
        }
        public List<SysAdmin> RetrieveAll()
        {
            return crudSysAdmin.RetrieveAll<SysAdmin>();
        }

        public SysAdmin RetrieveById(SysAdmin sysAdmin)
        {
            SysAdmin c = null;
            try
            {
                c = crudSysAdmin.Retrieve<SysAdmin>(sysAdmin);
                /*if (c == null)
                {
                    throw new BussinessException(4);
                }*/
            }
            catch (Exception ex)
            {
                //ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }

            return c;
        }

        public void Update(SysAdmin sysAdmin)
        {
            crudSysAdmin.Update(sysAdmin);
        }

        public void UpdatePassword(SysAdmin sysAdmin)
        {
            SysAdmin s = null;


            try
            {
                crudSysAdmin.UpdatePassword(sysAdmin);


            }
            catch (Exception ex)
            {
                //s ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }

        }

        public void Delete(SysAdmin sysAdmin)
        {
            crudSysAdmin.Delete(sysAdmin);
        }


        public bool ValidateExist(SysAdmin sysAdmin)
        {
            bool repeated = false;
            try
            {
                repeated = crudSysAdmin.ValidateUserExistence(sysAdmin);
            }
            catch (Exception ex)
            {
                //ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }
            return repeated;
        }
    }
}
