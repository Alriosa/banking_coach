using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
    public class ViewPermissionManager : BaseManager
    {
        private ViewPermissionCrudFactory viewPermissionCrudFactory;

        public ViewPermissionManager()
        {
            viewPermissionCrudFactory = new ViewPermissionCrudFactory();
        }

        public List<ViewPermission> RetrieveByUser(ViewPermission viewPermission)
        {
             return viewPermissionCrudFactory.RetrieveAllById<ViewPermission>(viewPermission);
        }
    }
}
