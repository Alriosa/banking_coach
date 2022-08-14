using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Languages: BaseEntity
    {
        public int LanguageID { get; set; }
        public string Language { get; set; }
        public string Level { get; set; }
        public int StudentID { get; set; }

        public Languages()
        {
        }

        public Languages(int languageID, string language, string level, int studentID)
        {
            LanguageID = languageID;
            Language = language;
            Level = level;
            StudentID = studentID;
        }
    }
}
