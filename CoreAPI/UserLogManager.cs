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
    public class UserLogManager : BaseManager
    {
        private UserLogCrudFactory crudUserLog;

        public UserLogManager()
        {
            crudUserLog = new UserLogCrudFactory();
        }

        public void Create(UserLog userLog)
        {
            var c = crudUserLog.Retrieve<UserLog>(userLog);
            //try
            //{
                

            //    if (c != null)
            //    {
            //        //UserLog already exist
            //        throw new BussinessException(3);
            //    }

            //    if (userLog.Age >= 18)
            //        crudUserLog.Create(userLog);
            //    else
            //        throw new BussinessException(2);
            //}
            //catch (Exception ex)
            //{
            //    ExceptionManager.GetInstance().Process(ex);
            //}
        }

        public List<UserLog> RetrieveAll()
        {
            return crudUserLog.RetrieveAll<UserLog>();
        }

        public UserLog RetrieveById(UserLog userLog)
        {
            UserLog c = null;
            try
            {
                c = crudUserLog.Retrieve<UserLog>(userLog);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                //ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }

            return c;
        }

        public void Update(UserLog userLog)
        {
            crudUserLog.Update(userLog);
        }

        public void Delete(UserLog userLog)
        {
            crudUserLog.Delete(userLog);
        }
    }
}
