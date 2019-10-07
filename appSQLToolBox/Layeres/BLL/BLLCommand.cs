
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.SQLToolBox.Layeres.DAL;
using UTN.Winform.SQLToolBox.Layeres.Entities;

namespace UTN.Winform.SQLToolBox.Layeres.BLL
{
    class BLLCommand
    {
        public string CrearCommand(string pBaseDatos, string pTabla)
        {
            StringBuilder command = new StringBuilder();
            StringBuilder fingerprint = new StringBuilder();
            fingerprint.AppendFormat("// Generado por {0} {1}", System.Windows.Forms.Application.ProductName, Environment.NewLine);
            fingerprint.AppendFormat("// Version: {0} {1} ", System.Windows.Forms.Application.ProductVersion, Environment.NewLine);
            fingerprint.AppendFormat("// Fecha: {0} {1} ", DateTime.Now, Environment.NewLine);

            command.Append("// Insert Command \n");
            command.AppendFormat(fingerprint.ToString());
            command.Append(CommandInsert(pBaseDatos, pTabla));
            command.Append(Environment.NewLine);
            command.Append("// Update Command \n");
            command.AppendFormat(fingerprint.ToString());
            command.Append(CommandUpdate(pBaseDatos, pTabla));
            command.Append(Environment.NewLine);
            command.Append("// Delete Command \n");
            command.AppendFormat(fingerprint.ToString());
            command.Append(CommandDelete(pBaseDatos, pTabla));
            command.Append(Environment.NewLine);
            command.Append("// Select By Id Command \n");
            command.AppendFormat(fingerprint.ToString());
            command.Append(SelectById(pBaseDatos, pTabla));
            command.Append(Environment.NewLine);
            command.Append("// Select ALL  Command \n");
            command.AppendFormat(fingerprint.ToString());
            command.Append(SelectAll(pBaseDatos, pTabla));

            return command.ToString();
        }

        private string CommandInsert(string pBaseDatos, string pTabla)
        {
            DALTable _DALTable = new DALTable();
            StringBuilder command = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            Table oTabla = _DALTable.GetTableStructure(pBaseDatos, pTabla);

            // Insert 
            sql.AppendFormat("Insert into {0}(", pTabla);
            foreach (var oColumna in oTabla.ColumnList)
            {
                if (oColumna.Identity != true)
                    sql.AppendFormat("{0},", oColumna.Name);
            }

            sql.Remove(sql.Length - 1, 1);
            sql.AppendFormat(") values (");

            foreach (var oColumna in oTabla.ColumnList)
            {
                if (oColumna.Identity != true)
                    sql.AppendFormat("{0},", "@" + oColumna.Name);
            }
            sql.Remove(sql.Length - 1, 1);

            sql.AppendFormat(")");
            command.AppendFormat(@"string  sql= {0}""{1}"";" + "\n", "@", sql.ToString());
            command.AppendFormat("SqlCommand command = new SqlCommand();\n");
            foreach (var oColumna in oTabla.ColumnList)
            {
                if (oColumna.Identity != true)
                    command.AppendFormat("command.Parameters.AddWithValue(\"{0}\",\"\");\n", "@" + oColumna.Name);
            }
            command.AppendFormat("command.CommandType = CommandType.Text;\n");
            command.AppendFormat("command.CommandText = sql;\n");

            return command.ToString();
        }

        private string CommandUpdate(string pBaseDatos, string pTabla)
        {
            DALTable _DALTable = new DALTable();
            StringBuilder command = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            Table oTabla = _DALTable.GetTableStructure(pBaseDatos, pTabla);

            // No primary Key so It can't create Update sentence
            if (oTabla.PrimaryKeyList.Count == 0)
                return $"//  La tabla  no tiene Llave Primaria, NO SE puede crear un UPDATE porque se requiere en el WHERE \n\n";

            if (oTabla.PrimaryKeyList.Count == oTabla.ColumnList.Count)
                return $"// La tabla '{oTabla.TableName.ToUpper()}' tiene todas sus Columnas como llaves primarias, NO se puede crear UPDATE  \n\n";

            // Insert 
            sql.AppendFormat("Update  {0} SET ", pTabla);
            foreach (var oColumna in oTabla.ColumnList)
            {
                // no identity
                if (oColumna.Identity != true)
                    // no update primary key.
                    if (oTabla.PrimaryKeyList.Find(p => p.Name.Equals(oColumna.Name, StringComparison.CurrentCultureIgnoreCase)) != null)
                        sql.AppendFormat(@"{0} = " + "@" + "{0} ,", oColumna.Name);
            }

            // Eliminar ultima (,)
            sql.Remove(sql.Length - 2, 2);

            sql.Append("  Where ");
            // llaves primarias 
            foreach (var oColumna in oTabla.PrimaryKeyList)
            {
                sql.AppendFormat("({0} = {1}) AND ", oColumna.Name, "@" + oColumna.Name);
            }
            sql.Remove(sql.Length - 4, 4);

            command.AppendFormat(@"string  sql= {0}""{1}"";" + "\n", "@", sql.ToString());
            command.AppendFormat("SqlCommand command = new SqlCommand();\n");

            foreach (var oColumna in oTabla.ColumnList)
            {
                if (oColumna.Identity != true)
                    command.AppendFormat("command.Parameters.AddWithValue(\"{0}\",\"\");\n", "@" + oColumna.Name);
            }
            command.AppendFormat("command.CommandType = CommandType.Text;\n");
            command.AppendFormat("command.CommandText = sql;\n");

            return command.ToString();
        }

        private string CommandDelete(string pBaseDatos, string pTabla)
        {
            DALTable _DALTable = new DALTable();
            StringBuilder command = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            Table oTabla = _DALTable.GetTableStructure(pBaseDatos, pTabla);

            if (oTabla.PrimaryKeyList.Count == 0)
                return $"// La tabla '{oTabla.TableName.ToUpper()}' NO tiene Llave Primaria, no se puede crear un Delete \n\n";

            // Insert 
            sql.AppendFormat("Delete from  {0} ", pTabla);

            sql.Append("  Where ");
            // llaves primarias 
            foreach (var oColumna in oTabla.PrimaryKeyList)
            {
                sql.AppendFormat("({0} = {1}) AND ", oColumna.Name, "@" + oColumna.Name);
            }
            sql.Remove(sql.Length - 4, 4);

            command.AppendFormat(@"string  sql= {0}""{1}"";" + "\n", "@", sql.ToString());
            command.AppendFormat("SqlCommand command = new SqlCommand();\n");
            foreach (var oColumna in oTabla.PrimaryKeyList)
            {
                command.AppendFormat("command.Parameters.AddWithValue(\"{0}\",\"\");\n", "@" + oColumna.Name);
            }
            command.AppendFormat("command.CommandType = CommandType.Text;\n");
            command.AppendFormat("command.CommandText = sql;\n");

            return command.ToString();
        }

        private string SelectById(string pBaseDatos, string pTabla)
        {
            DALTable _DALTable = new DALTable();
            StringBuilder command = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            Table oTabla = _DALTable.GetTableStructure(pBaseDatos, pTabla);

            if (oTabla.PrimaryKeyList.Count == 0)
                return $"// La tabla '{oTabla.TableName.ToUpper()}' NO tiene Llave Primaria, no se puede crear un Select_By_Id \n\n";

            // Select 
            sql.AppendFormat("Select  ");

            foreach (var oColumna in oTabla.ColumnList)
            {
                sql.AppendFormat("{0},", oColumna.Name);
            }
            sql.Remove(sql.Length - 1, 1);

            sql.AppendFormat("  from  {0} ", pTabla);

            sql.Append("  Where ");
            // llaves primarias 
            foreach (var oColumna in oTabla.PrimaryKeyList)
            {
                sql.AppendFormat("({0} = {1}) AND ", oColumna.Name, "@" + oColumna.Name);
            }
            sql.Remove(sql.Length - 4, 4);

            command.AppendFormat(@"string  sql= {0}""{1}"";" + "\n", "@", sql.ToString());
            command.AppendFormat("SqlCommand command = new SqlCommand();\n");
            foreach (var oColumna in oTabla.PrimaryKeyList)
            {
                command.AppendFormat("command.Parameters.AddWithValue(\"{0}\",\"\");\n", "@" + oColumna.Name);
            }
            command.AppendFormat("command.CommandType = CommandType.Text;\n");
            command.AppendFormat("command.CommandText = sql;\n");
            command.AppendFormat("{0}", this.CreateMapObject(oTabla).ToString());

            return command.ToString();
        }

        private string SelectAll(string pBaseDatos, string pTabla)
        {
            DALTable _DALTable = new DALTable();
            StringBuilder command = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            Table oTabla = _DALTable.GetTableStructure(pBaseDatos, pTabla);

            // Insert 
            sql.AppendFormat("Select  ");

            foreach (var oColumna in oTabla.ColumnList)
            {
                sql.AppendFormat("{0},", oColumna.Name);
            }

            sql.Remove(sql.Length - 1, 1);
            sql.AppendFormat("  from  {0} With (NOLOCK)", pTabla);
            command.AppendFormat(@"string  sql= {0}""{1}"";" + "\n", "@", sql.ToString());
            command.AppendFormat("SqlCommand command = new SqlCommand();\n");
            command.AppendFormat("command.CommandText = sql;\n");
            command.AppendFormat("{0}\n", this.CreateMapCollection(oTabla));
            return command.ToString();
        }

        private string CreateMapObject(Table pTabla)
        {
            BLLClr _BLLClr = new BLLClr();

            StringBuilder command = new StringBuilder();
            command.AppendFormat("// Declarar el DataSet para extraer los datos;\n");
            command.AppendFormat("DataSet ds = new DataSet();\n");
            command.AppendFormat("// Colocar acá el acceso a la persistencia \n");
            command.AppendFormat("// \n");
            command.AppendFormat("// \n");
            command.AppendFormat("{0} o{0} = new {0}();\n", pTabla.TableName);
            command.AppendFormat("foreach (DataRow dr in ds.Tables[0].Rows) {0} {1}  \n ", Environment.NewLine, "{");
            
            foreach (var oColumna in pTabla.ColumnList)
            {
                // command.AppendFormat("\t{0}.{1} = item[\"{1}\"];\n", "o" + oTabla.TableName,oColumna.Name);
                command.AppendFormat("\t{0}.{1} ={2};\n", "o" + pTabla.TableName, oColumna.Name, _BLLClr.SQLTypeToCLR(oColumna.Type, oColumna.Name));
            }

           // command.AppendFormat("\tlista.Add({0});\n", "o" + pTabla.TableName);
            command.AppendFormat("\r{0}\n", "}");
            command.AppendFormat("return o{0};\n", pTabla.TableName);
            return command.ToString();
        }

        private string CreateMapCollection(Table pTabla)
        {
            BLLClr _BLLClr = new BLLClr();

            StringBuilder command = new StringBuilder();
            command.AppendFormat("// Declarar el DataSet para extraer los datos;\n");
            command.AppendFormat("DataSet ds = new DataSet();\n");
            command.AppendFormat("// Colocar acá el acceso a la persistencia \n");
            command.AppendFormat("// \n");
            command.AppendFormat("// \n");
            command.AppendFormat("List<{0}> lista = new List<{0}>();\n", pTabla.TableName);
            command.AppendFormat("foreach (DataRow dr in ds.Tables[0].Rows) {0} {1}  \n ", Environment.NewLine, "{");

            command.AppendFormat("\t{0} {1} = new {0}();\n", pTabla.TableName, "o" + pTabla.TableName);

            foreach (var oColumna in pTabla.ColumnList)
            {
                // command.AppendFormat("\t{0}.{1} = item[\"{1}\"];\n", "o" + oTabla.TableName,oColumna.Name);
                command.AppendFormat("\t{0}.{1} ={2};\n", "o" + pTabla.TableName, oColumna.Name, _BLLClr.SQLTypeToCLR(oColumna.Type, oColumna.Name));
            }

            command.AppendFormat("\tlista.Add({0});\n", "o" + pTabla.TableName);
            command.AppendFormat("\r{0}", "}");
            command.AppendFormat("\r{0}", "return lista;");

            return command.ToString();
        } 
    }
}
