using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteAdminUTF8CI.Models
{
    class TableField
    {
        public string FldName { get; set; }
        public string FldType { get; set; }
        public string FldDefaultValue { get; set; }
        public string FldIsNotNull { get; set; } //NOT NULL, ALLOW NULL
        public string FldIsPrimary { get; set; } //YES, NO
        public string FldCollation { get; set; }
        public string FldIsUnique { get; set; }
        public bool FldIsUpdated { get; set; }
    }
}
