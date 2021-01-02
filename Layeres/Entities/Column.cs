using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTN.Winform.SQLToolBox.Layeres.Entities
{
    class Column
    {
        public string Name { set; get; }
        public string Type { set; get; }
        public int Lenght { set; get; }
        public int Precision { set; get; }
        public int Scale { set; get; }
        public string Nullable { set; get; }
        public bool Identity { set; get; }
    }
}
