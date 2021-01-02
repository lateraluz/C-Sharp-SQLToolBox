using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UTN.Winform.SQLToolBox.Layeres.DAL;
using UTN.Winform.SQLToolBox.Layeres.Entities;

namespace UTN.Winform.SQLToolBox.Layeres.BLL
{
    class BLLTable
    {
        public List<Table> GetTables(string pDataBase,string pServidor, string pUsuario, string pContrasena) {

            DALTable _DALTable = new DALTable();
            List<Table> tablas = _DALTable.GetTable( pDataBase, pServidor,  pUsuario,  pContrasena);

            return tablas;

        }

    }
}
