using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTN.Winform.SQLToolBox.Layeres.Entities
{
    class Table
    {
        public string TableName { set; get; }
        public int Id { set; get; }
        public List<Column> ColumnList = new List<Column>();
        public List<Column> PrimaryKeyList = new List<Column>();
        public override string ToString() => TableName;

    }
}
