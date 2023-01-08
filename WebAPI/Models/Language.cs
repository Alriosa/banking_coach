using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Language: BaseEntity
    {
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }
        public string Level { get; set; }
        public DateTime EntryDate { get; set; }
        public int StudentID { get; set; }

        public Language()
        {
        }

        public Language(int languageID, string language, string level, DateTime entryDate, int studentID)
        {
            LanguageID = languageID;
            LanguageName = language;
            Level = level;
            EntryDate = entryDate;
            StudentID = studentID;
        }
    }
}
