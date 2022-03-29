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
            var c = crudSysAdmin.Retrieve<SysAdmin>(sysAdmin);
            //try
            //{
               

            //    if (c != null)
            //    {
            //        //SysAdmin already exist
            //        throw new BussinessException(3);
            //    }

            //    if (sysAdmin.Age >= 18)
            //        crudSysAdmin.Create(sysAdmin);
            //    else
            //        throw new BussinessException(2);
            //}
            //catch (Exception ex)
            //{
            //    ExceptionManager.GetInstance().Process(ex);
            //}
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
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(SysAdmin sysAdmin)
        {
            crudSysAdmin.Update(sysAdmin);
        }

        public void Delete(SysAdmin sysAdmin)
        {
            crudSysAdmin.Delete(sysAdmin);
        }
    }
}
