using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Crud;
using Models;
using Exceptions;


namespace CoreAPI
{
    public class LanguageManager : BaseManager
    {
        private LanguageCrudFactory crudLanguage;

        public LanguageManager()
        {
            crudLanguage = new LanguageCrudFactory();
        }

        public void Create(Language language)
        {
            try
            {

                // if (temp.AdminLogin.Equals("0"))
                crudLanguage.Create(language);

                // else
                //       throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al insertar datos", ex);
            }
        }


        public List<Language> RetrieveAll()
        {
            return crudLanguage.RetrieveAll<Language>();
        }

        public Language RetrieveById(Language language)
        {
            Language c = null;
            try
            {
                c = crudLanguage.Retrieve<Language>(language);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                // ExceptionManager.GetInstance().Process(ex);
                throw new Exception("Error al retornar datos", ex);
            }
            return c;
        }

        public List<Language> RetrieveAllByStudent(Language language)
        {
            return crudLanguage.RetrieveAllById<Language>(language);
        }

        public void Update(Language language)
        {
            crudLanguage.Update(language);
        }

        public void Delete(Language language)
        {
            crudLanguage.Delete(language);
        }
    }
}
