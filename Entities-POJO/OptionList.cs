﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class OptionList : BaseEntity
    {
        public string ListId { get; set; }
        public string PCode { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
    }
}
