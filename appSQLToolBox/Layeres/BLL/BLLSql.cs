using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.SQLToolBox.Layeres.DAL;

namespace UTN.Winform.SQLToolBox.Layeres.BLL
{
    class BLLSql
    {
        public DataSet ExecuteSQL(string pDataBase, string pSql)
        {
            bool isValid = false;
            bool itWasExecuted = false;
            DataSet ds = new DataSet();

            string[] listaCommandos = pSql.Split(';');
            DALSql _DALSql = new DALSql();
            foreach (string item in listaCommandos)
            {
                if (IsDataDefinitionLanguageAndDataControlLanguage(item.Trim()))
                {
                    if (pDataBase.Equals("MASTER", StringComparison.CurrentCultureIgnoreCase))
                    {
                        throw new Exception("No se pueden ejecutar sentencias en tipo CREATE, ALTER, DROP en la base de datos MASTER !");
                    }

                    _DALSql.ExecuteSQLDDL_DLC(pDataBase, item.Trim());
                    isValid = true;
                    itWasExecuted = true;
                    ds.Tables.Add(CreateDynamicTable("Ejecucion correcta"));
                }

                if (IsDataManipulationLanguage(pSql) && !itWasExecuted && item.Trim().Length > 0)
                {
                    ds = _DALSql.ExecuteSQLDML(pDataBase, pSql);

                    if (ds.Tables.Count == 0)
                        ds.Tables.Add(CreateDynamicTable("Ejecucion correcta"));
                    isValid = true;
                }

                itWasExecuted = false;
            }

            if (!isValid)
                throw new Exception("Comando no reconocido!");

            return ds;

        }

        /// <summary>
        ///  data manipulation  language
        /// </summary>
        /// <param name="pSql"></param>
        /// <returns>bool</returns>
        private bool IsDataManipulationLanguage(string pSql)
        {

            List<string> TokensDML = new List<string>() { "EXEC ", "SELECT ", "INSERT ", "DELETE ", "UPDATE " };
            bool flag = false;

            Parallel.ForEach(TokensDML, (item) =>
               {
                   if (pSql.ToUpper().Contains(item))
                       flag = true;
               }
            ); 
            return flag; 
        }

        /// <summary>
        ///  data definition language &   data control language
        /// </summary>
        /// <param name="pSql"></param>
        /// <returns></returns>
        private bool IsDataDefinitionLanguageAndDataControlLanguage(string pSql)
        {
            bool flag = false;
            List<string> TokensDDL_DLC = new List<string>() { "IF ", "USE ", "CREATE ", "GRANT ", "REVOKE " };

            Parallel.ForEach(TokensDDL_DLC, (item) =>
            {
                if (pSql.ToUpper().Contains(item))
                    flag = true;
            }
            ); 
            return flag;
        }

        /// <summary>
        /// Crea una tabla din/micamente
        /// </summary>
        /// <param name="pParametro"></param>
        /// <returns></returns>
        private DataTable CreateDynamicTable(string pParametro)
        {

            DataTable table = new DataTable();
            table.Columns.Add("Respuesta", typeof(string));
            table.Rows.Add(pParametro);
            return table;
        }
    }
}
