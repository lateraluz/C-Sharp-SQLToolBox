using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTN.Winform.SQLToolBox.Layeres.Entities
{
    class DataBaseStorage
    {
        public string DataBaseName { set; get; }
        public int Id { set; get; }
        private List<Table> ListaTablas; 

        public DataBaseStorage() {
            ListaTablas = new List<Table>();
        } 
        public void AgregarTabla(Table pTable) {
            ListaTablas.Add(pTable);
        } 
        public   List<Table> GetTablas() => ListaTablas;
         
        public override string ToString() => DataBaseName;
        

    }
}
