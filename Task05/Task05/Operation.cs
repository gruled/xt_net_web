using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    struct Operation
    {
        public DateTime Time;
        public string File;
        public TypeOperation Type;
        public string Value;
        public Operation(DateTime time, string file, TypeOperation operation, string value)
        {
            this.Time = time;
            this.File = file;
            this.Type = operation;
            this.Value = value;
        }
    }
}
