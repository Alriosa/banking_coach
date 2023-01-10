using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Models;
using Exceptions;

namespace CoreAPI
{
    public class EntityUserManager : BaseManager
    {
        private EntityUserCrudFactory entityUserCrudFactory;

        public EntityUserManager()
        {
            entityUserCrudFactory = new EntityUserCrudFactory();
        }

        public void Create(EntityUser entityUser)
        {
            try
            {

                // if (temp.EntityLogin.Equals("0"))
                entityUserCrudFactory.Create(entityUser);

                // else
                //       throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al insertar datos", ex);
            }
        }

        public List<EntityUser> RetrieveAll()
        {
            return entityUserCrudFactory.RetrieveAll<EntityUser>();
        }

        public EntityUser RetrieveById(EntityUser entityUser)
        {
            EntityUser c = null;
            try
            {
                c = entityUserCrudFactory.Retrieve<EntityUser>(entityUser);
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

        public EntityUser RetrieveByUserLogin(EntityUser entity)
        {
            EntityUser c = null;
            try
            {
                c = entityUserCrudFactory.RetrieveByUserLogin<EntityUser>(entity);
                /* if (c == null)
                 {
                     throw new BussinessException(4);
                 }*/
            }
            catch (Exception ex)
            {
                throw new Exception("Error al devolver datos", ex);
                //s ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }
        public void Update(EntityUser entityUser)
        {
            entityUserCrudFactory.Update(entityUser);
        }

       

        public void Delete(EntityUser entityUser)
        {
            entityUserCrudFactory.Delete(entityUser);
        }

        public bool ValidateExist(EntityUser entity)
        {
            bool repeated = false;
            try
            {
                repeated = entityUserCrudFactory.ValidateUserExistence(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al devolver datos", ex);

                //ExceptionManager.GetInstance().Process(ex);
            }
            return repeated;
        }
    }
}
