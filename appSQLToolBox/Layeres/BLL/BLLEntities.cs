
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.SQLToolBox.Layeres.DAL;
using UTN.Winform.SQLToolBox.Layeres.Entities;

namespace UTN.Winform.SQLToolBox.Layeres.BLL
{
    class BLLEntities
    {
        public List<Entity> CreateEntities(string pBaseDatos )
        {
            List<Entity> listaEntidades = new List<Entity>();
            StringBuilder entidades = new StringBuilder("");
            DALConnection _DALConnection = new DALConnection();
            DALTable _DALTable = new DALTable();
            BLLClr _BLLClr = new BLLClr();

            List<DataBaseStorage> ListaDataBasesWithTables = _DALConnection.GetDataBases();
            DataBaseStorage database = ListaDataBasesWithTables.Find(p => p.DataBaseName.Equals(pBaseDatos, StringComparison.CurrentCultureIgnoreCase));

            foreach (Table oTabla in database.GetTablas())
            {
                Table tabla = _DALTable.GetTableStructure(pBaseDatos, oTabla.TableName);
                Entity oEntity = new Entity();
                entidades.AppendFormat("public class {0} {1}\n", tabla.TableName, "\n{");
                oEntity.Name = tabla.TableName;

                foreach (Column oColumna in tabla.ColumnList)
                { 
                    Trace.WriteLine(oColumna.Name + " " + oColumna.Type);
                    entidades.AppendFormat("public {0} {1} {2}\n", _BLLClr.GetClrType(oColumna.Type), oColumna.Name, "{set;get;}");
                 }

                entidades.AppendFormat("{0}\n\n", "}");
                oEntity.Detail = entidades.ToString();
                listaEntidades.Add(oEntity);
                entidades.Clear();
            } 
            return listaEntidades;
        }

    }
}
