
using DataAccess.Crud;
using DataAcess.Crud;
using Models;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ListManager : BaseManager
    {
        private Dictionary<string, List<OptionList>> dicListOptions;
        private ListCrudFactory crudList;

        public ListManager()
        {
            crudList = new ListCrudFactory();
            LoadDictionary();
        }

        private void LoadDictionary()
        {
            dicListOptions = new Dictionary<string, List<OptionList>>();

        }

        /* private void LoadDictionary()
         {
             dicListOptions = new Dictionary<string, List<OptionList>>();
             //TODO: ESTO DEBE VENIR DE ELA BASE DE DATOS

             var lst = new List<OptionList>();
             var option = new OptionList
             {
                 ListId = "LST_GENERO",
                 Value = "M",
                 Description = "Masculino"
             };
             lst.Add(option);
             option = new OptionList
             {
                 ListId = "LST_GENERO",
                 Value = "F",
                 Description = "Femenino"
             };
             lst.Add(option);
             option = new OptionList
             {
                 ListId = "LST_GENERO",
                 Value = "O",
                 Description = "Otros"
             };
             lst.Add(option);
             dicListOptions.Add("LST_GENERO", lst);

         }*/

        public List<OptionList> RetrieveById(OptionList option)
        {

            var lst = new List<OptionList>();
            foreach (OptionList o in crudList.RetrieveAllByListId<OptionList>(option, option.ListId))
            {
                var newOption = new OptionList
                {
                    ListId = option.ListId,
                    PCode = o.PCode,
                    Code = o.Code,
                    Value = o.Value
                };
                lst.Add(newOption);
            }
            return lst;
        }

       
    }
}
