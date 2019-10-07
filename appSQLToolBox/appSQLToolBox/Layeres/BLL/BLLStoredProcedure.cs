
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UTN.Winform.SQLToolBox.Layeres.DAL;
using UTN.Winform.SQLToolBox.Layeres.Entities;

namespace UTN.Winform.SQLToolBox.Layeres.BLL
{
    class BLLStoredProcedure
    {
        private List<string> _Caracteres = new List<string>() { "varchar", "nvarchar", "nchar", "char", "varbinary" };
        private List<string> _Numericos = new List<string>() { "numeric" };

        public string CreateStoredProcedure(string pDataBase, string pTable)
        {
            DALTable _DALTable = new DALTable();
            StringBuilder statement = new StringBuilder();

            statement.AppendFormat("USE {0};\n", pDataBase);

            Table oTable = _DALTable.GetTableStructure(pDataBase, pTable);
            statement.Append(CreateStoredProcedureInsertStatement(oTable));
            statement.Append(CreateStoredProcedureDeleteStatement(oTable));
            statement.Append(CreateStoredProcedureUpdateStatement(oTable));
            statement.Append(CreateStoredProcedureSelectByIdStatement(oTable));
            statement.Append(CreateStoredProcedureSelectAllStatement(oTable));

            return statement.ToString();
        }

        private string CreateStoredProcedureInsertStatement(Table pTable)
        {

            StringBuilder insert = new StringBuilder("");

            insert.AppendFormat("IF OBJECT_ID(\'usp_INSERT_{0}\') is NOT NULL {1}", pTable, Environment.NewLine);
            insert.AppendFormat("DROP PROC  usp_INSERT_{0}{1}", pTable, Environment.NewLine);
            insert.AppendFormat(";{0}{0}", Environment.NewLine);

            insert.AppendFormat("CREATE PROCEDURE usp_INSERT_{0}{1} (", pTable, Environment.NewLine);
            insert.AppendFormat("{0}){1}", GetInsertFieldsWithoutIdentity(pTable), Environment.NewLine);
            insert.AppendFormat("AS {0}", Environment.NewLine);
            insert.AppendFormat("-- Stored Procedured Generado por {0} {1}", System.Windows.Forms.Application.ProductName, Environment.NewLine);
            insert.AppendFormat("-- Version: {0} {1} ", System.Windows.Forms.Application.ProductVersion, Environment.NewLine);
            insert.AppendFormat("-- Fecha: {0} {1} ", DateTime.Now, Environment.NewLine);
            insert.AppendFormat("insert into {0}(", pTable, Environment.NewLine);
            insert.Append(GetColumnsStoredProcedureWithoutIdentity(pTable, ""));
            insert.AppendFormat(") {0} values(", Environment.NewLine);
            insert.AppendFormat("{0} ) {1}", GetColumnsStoredProcedureWithoutIdentity(pTable, "@"), Environment.NewLine);
            insert.AppendFormat(";{0}{0}", Environment.NewLine);

            return insert.ToString();
        }

        private string CreateStoredProcedureDeleteStatement(Table pTable)
        {
            StringBuilder insert = new StringBuilder("");
            string whereKeyClouse = "";
            bool IsError = false;

            whereKeyClouse = GetWhereKeyClause(pTable, ref IsError);

            if (!IsError)
            {
                insert.AppendFormat("IF OBJECT_ID(\'usp_DELETE_{0}_ByID\') is NOT NULL {1}", pTable, Environment.NewLine);
                insert.AppendFormat("Drop Proc  usp_DELETE_{0}_ByID{1}", pTable, Environment.NewLine);
                insert.AppendFormat(";{0}{0}", Environment.NewLine);
                insert.AppendFormat("CREATE PROCEDURE usp_DELETE_{0}_ByID {1}(", pTable, Environment.NewLine);
                insert.AppendFormat("{0}){1}", GetColumnsKeys(pTable, ""), Environment.NewLine);
                insert.AppendFormat("AS {0}", Environment.NewLine);
                insert.AppendFormat("-- Stored Procedured Generado por {0} {1}", System.Windows.Forms.Application.ProductName, Environment.NewLine);
                insert.AppendFormat("-- Version: {0} {1} ", System.Windows.Forms.Application.ProductVersion, Environment.NewLine);
                insert.AppendFormat("-- Fecha: {0} {1} ", DateTime.Now, Environment.NewLine);
                insert.AppendFormat("\tDelete from {0}{1}", pTable, Environment.NewLine);
                insert.AppendFormat("\tWhere {0}{1}", whereKeyClouse, Environment.NewLine);
                insert.AppendFormat(";{0}{0}", Environment.NewLine);
            }
            else
            {

                insert.AppendFormat("No se puede crear el Stored Procedure para Borrar porque la Tabla {0} NO  LLAVES PRIMARIAS", pTable.TableName);
            }

            return insert.ToString();
        }

        private string CreateStoredProcedureUpdateStatement(Table pTable)
        {
            StringBuilder update = new StringBuilder("");
            string whereKeyClouse = "";
            bool isError = false;
            string mensaje = "";

            whereKeyClouse = GetWhereKeyClause(pTable, ref isError);

            if (!isError)
            {
                isError = false;
                mensaje = "";
                if (GetSetUpdateFields(pTable, ref mensaje) == "")
                {
                    return "-- ALERTA a GENERAR EL Stored Procedured UPDATE  " + Environment.NewLine + "--" + mensaje + Environment.NewLine + Environment.NewLine;
                }

                update.AppendFormat("IF OBJECT_ID(\'usp_UPDATE_{0}\') is NOT NULL {1}", pTable, Environment.NewLine);
                update.AppendFormat("Drop Proc  usp_UPDATE_{0}{1}", pTable, Environment.NewLine);
                update.AppendFormat(";{0}{0}", Environment.NewLine);
                update.AppendFormat("CREATE PROCEDURE usp_UPDATE_{0}{1} (", pTable, Environment.NewLine);
                update.AppendFormat("{0}){1}", GetAllFieldsTable(pTable), Environment.NewLine);
                update.AppendFormat("AS {0}", Environment.NewLine);
                update.AppendFormat("-- Stored Procedured Generado por {0} {1}", System.Windows.Forms.Application.ProductName, Environment.NewLine);
                update.AppendFormat("-- Version: {0} {1} ", System.Windows.Forms.Application.ProductVersion, Environment.NewLine);
                update.AppendFormat("-- Fecha: {0} {1} ", DateTime.Now, Environment.NewLine);
                update.AppendFormat("\tUpdate  {0}{1}", pTable.TableName, Environment.NewLine);
                update.AppendFormat("\tSet {0}{1}", GetSetUpdateFields(pTable, ref mensaje), Environment.NewLine);
                update.AppendFormat("\tWhere {0}{1}", whereKeyClouse, Environment.NewLine);
                update.AppendFormat(";{0}{0}", Environment.NewLine);
            }
            else
            {

                update.AppendFormat("No se puede crear el Stored Procedure para Actualizar porque la Tabla {0} NO  LLAVES PRIMARIAS", pTable.TableName);
            }

            return update.ToString();
        }

        private string CreateStoredProcedureSelectByIdStatement(Table pTable)
        {
            StringBuilder insert = new StringBuilder("");
            string whereKeyClouse = "";
            bool IsError = false;

            whereKeyClouse = GetWhereKeyClause(pTable, ref IsError);

            if (!IsError)
            {

                insert.AppendFormat("IF OBJECT_ID(\'usp_SELECT_{0}_ByID\') is NOT NULL {1}", pTable, Environment.NewLine);
                insert.AppendFormat("Drop Proc  usp_SELECT_{0}_ByID{1}", pTable, Environment.NewLine);
                insert.AppendFormat(";{0}{0}", Environment.NewLine);
                insert.AppendFormat("CREATE PROCEDURE usp_SELECT_{0}_ByID {1}(", pTable, Environment.NewLine);
                insert.AppendFormat("{0}){1}", GetColumnsKeys(pTable, ""), Environment.NewLine);
                insert.AppendFormat("AS {0}", Environment.NewLine);
                insert.AppendFormat("-- Stored Procedured Generado por {0} {1}", System.Windows.Forms.Application.ProductName, Environment.NewLine);
                insert.AppendFormat("-- Version: {0} {1} ", System.Windows.Forms.Application.ProductVersion, Environment.NewLine);
                insert.AppendFormat("-- Fecha: {0} {1} ", DateTime.Now, Environment.NewLine);
                insert.AppendFormat("\tSelect {0} from {1}{2}", GetColumnsStoredProcedureWithIdentity(pTable, ""), pTable, Environment.NewLine);
                insert.AppendFormat("\tWhere {0}{1}", whereKeyClouse, Environment.NewLine);
                insert.AppendFormat(";{0}{0}", Environment.NewLine);
            }
            else
            {
                insert.AppendFormat("No se puede crear el Stored Procedure para seleccionar  porque la Tabla {0} NO  LLAVES PRIMARIAS", pTable.TableName);
            }

            return insert.ToString();
        }

        private string CreateStoredProcedureSelectAllStatement(Table pTable)
        {
            StringBuilder insert = new StringBuilder("");
            string whereKeyClouse = "";
            bool IsError = false;

            whereKeyClouse = GetWhereKeyClause(pTable, ref IsError);

            if (!IsError)
            {
                insert.AppendFormat("IF OBJECT_ID(\'usp_SELECT_{0}_All\') is NOT NULL {1}", pTable, Environment.NewLine);
                insert.AppendFormat("Drop Proc  usp_SELECT_{0}_All{1}", pTable, Environment.NewLine);
                insert.AppendFormat(";{0}{0}", Environment.NewLine);
                insert.AppendFormat("CREATE PROCEDURE usp_SELECT_{0}_All{1} ", pTable, Environment.NewLine);
                insert.AppendFormat("AS {0}", Environment.NewLine);
                insert.AppendFormat("-- Stored Procedured Generado por {0} {1}", System.Windows.Forms.Application.ProductName, Environment.NewLine);
                insert.AppendFormat("-- Version: {0} {1} ", System.Windows.Forms.Application.ProductVersion, Environment.NewLine);
                insert.AppendFormat("-- Fecha: {0} {1} ", DateTime.Now, Environment.NewLine);
                insert.AppendFormat("\tSelect {0} from {1}{2}", GetColumnsStoredProcedureWithIdentity(pTable, ""), pTable, Environment.NewLine);
                insert.AppendFormat(";{0}{0}", Environment.NewLine);
            }
            else
            {

                insert.AppendFormat("No se puede crear el Stored Procedure para seleccionar datos por llave Primaria porque la Tabla {0} NO  LLAVES PRIMARIAS \n", pTable.TableName);
            }

            return insert.ToString();
        }


        private string GetColumnsStoredProcedureWithIdentity(Table pTable, string pPrefijo)
        {

            StringBuilder parameters = new StringBuilder();

            foreach (Column item in pTable.ColumnList)
            {
                // Identity no van 
                if (item.Identity == false)
                    parameters.AppendFormat("{0}{1} ,", pPrefijo, item.Name);
            }
            //Eliminar la ultima (,) 
            return parameters.ToString().Substring(0, parameters.Length - 1);
        }

        private string GetColumnsStoredProcedureWithoutIdentity(Table pTable, string pPrefijo)
        {

            StringBuilder parameters = new StringBuilder();

            foreach (Column item in pTable.ColumnList)
            {
                // Identity no van 
                if (item.Identity == false)
                    parameters.AppendFormat("{0}{1} ,", pPrefijo, item.Name);
            }
            //Eliminar la ultima (,) 
            return parameters.ToString().Substring(0, parameters.Length - 1);
        }

        private string GetColumnsKeys(Table pTable, string pPrefijo)
        {

            StringBuilder parameters = new StringBuilder();

            foreach (Column item in pTable.PrimaryKeyList)
            {
                if (_Caracteres.Exists(p => p.Equals(item.Type, StringComparison.CurrentCultureIgnoreCase) == true))
                {
                    if (item.Type.Equals("varbinary", StringComparison.CurrentCultureIgnoreCase) && item.Lenght == -1)
                        parameters.AppendFormat("@{0} {1}({2}),", item.Name, item.Type, "MAX");
                    else
                        parameters.AppendFormat("@{0} {1}({2}),", item.Name, item.Type, item.Lenght);
                }
                else
                {
                    if (_Numericos.Exists(p => p.CompareTo(item.Type) == 0))
                        parameters.AppendFormat("@{0} {1}({2},{3}),", item.Name, item.Type, item.Precision, item.Scale);
                    else
                        parameters.AppendFormat("@{0} {1},", item.Name, item.Type, item.Lenght);
                }
            }

            if (parameters.ToString().Trim().Length == 0)
                return "No tiene llaves privarias para efectuar el filtro, agreguelas y vuelva a generar los Stored Procedures \n";
            else
                //Eliminar la ultima (,)
                return parameters.ToString().Substring(0, parameters.Length - 1);

        }

        private string GetWhereKeyClause(Table pTable, ref bool pIsError)
        {
            StringBuilder whereClause = new StringBuilder();

            foreach (Column item in pTable.PrimaryKeyList)
            {
                whereClause.AppendFormat("({0} =  @{1})  AND ", item.Name, item.Name);
            }

            if (pTable.PrimaryKeyList.Count == 0)
            {
                pIsError = true;
                return "";
            }

            else// eliminar el ultimo AND
                return whereClause.ToString().Substring(0, whereClause.Length - 4);

        }

        private string GetSetUpdateFields(Table pTable, ref string pMessage)
        {
            StringBuilder updateFields = new StringBuilder();
            pMessage = "";
            if (pTable.ColumnList.Count == pTable.PrimaryKeyList.Count)
            {
                pMessage = $"La tabla {pTable.TableName.ToUpper()} tiene todos sus campos como llave primara, NO se puede crear el UPDATE ";
                return "";
            }
            foreach (Column item in pTable.ColumnList)
            {
                // Si es llave primaria no la agregue.
                if (pTable.PrimaryKeyList.Find(p => p.Name.Equals(item.Name,
                      StringComparison.CurrentCultureIgnoreCase) == true) == null)
                {
                    updateFields.AppendFormat("\t{0} =  @{1}  ,\n", item.Name, item.Name);
                }
            }

            return updateFields.ToString().Substring(0, updateFields.Length - 2);
        }


        private string GetInsertFieldsWithoutIdentity(Table pTable)
        {
            StringBuilder parameters = new StringBuilder();

            foreach (Column item in pTable.ColumnList)
            {
                if (item.Identity == true)
                    continue;

                if (_Caracteres.Exists(p => p.CompareTo(item.Type) == 0))
                {
                    // parameters.AppendFormat("@{0} {1}({2}),", item.Name, item.Type, item.Lenght);

                    if (item.Type.Equals("varbinary", StringComparison.CurrentCultureIgnoreCase) && item.Lenght == -1)
                        parameters.AppendFormat("@{0} {1}({2}),", item.Name, item.Type, "MAX");
                    else
                    {
                        parameters.AppendFormat("@{0} {1}({2}),", item.Name, item.Type, item.Lenght == -1 ? "MAX" : item.Lenght.ToString());
                    }
                }
                else
                {
                    if (_Numericos.Exists(p => p.CompareTo(item.Type) == 0))
                        parameters.AppendFormat("@{0} {1}({2},{3}),", item.Name, item.Type, item.Precision, item.Scale);
                    else
                        parameters.AppendFormat("@{0} {1},", item.Name, item.Type, item.Lenght);
                }
            }


            return parameters.ToString().Substring(0, parameters.Length - 1);
        }

        private string GetAllFieldsTable(Table pTable)
        {
            StringBuilder parameters = new StringBuilder(); 

            foreach (Column item in pTable.ColumnList)
            {
                if (_Caracteres.Exists(p => p.CompareTo(item.Type) == 0))
                {
                    //   parameters.AppendFormat("@{0} {1}({2}),", item.Name, item.Type, item.Lenght);

                    if (item.Type.Equals("varbinary", StringComparison.CurrentCultureIgnoreCase) && item.Lenght == -1)
                        parameters.AppendFormat("@{0} {1}({2}),", item.Name, item.Type, "MAX");
                    else
                        parameters.AppendFormat("@{0} {1}({2}),", item.Name, item.Type, item.Lenght == -1 ? "MAX" : item.Lenght.ToString());
                }
                else
                {
                    if (_Numericos.Exists(p => p.CompareTo(item.Type) == 0))
                        parameters.AppendFormat("@{0} {1}({2},{3}),", item.Name, item.Type, item.Precision, item.Scale);
                    else
                        parameters.AppendFormat("@{0} {1},", item.Name, item.Type, item.Lenght);
                }
            }
            return parameters.ToString().Substring(0, parameters.Length - 1);
        }
    }
}
