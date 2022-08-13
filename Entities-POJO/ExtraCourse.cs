﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ExtraCourse : BaseEntity
    {
        public int AcademicID { get; set; }
        public string Institution { get; set; }
        public string CourseName { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Status { get; set; }
        public string Certificate { get; set; }
        public DateTime EntryDate { get; set; }
        public int StudentID { get; set; }
    }
}
