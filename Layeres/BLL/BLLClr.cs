using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.SQLToolBox.Layeres.BLL
{
    class BLLClr
    {
        public string SQLTypeToCLR(string pSqlType, string pField)
        {
            string type = "";

            pSqlType = pSqlType.ToLower();

            switch (pSqlType)
            {
                case "nvarchar":
                case "varchar":
                case "ntext":
                case "nchar":
                case "text":
                case "char":
                    type = string.Format(@" dr[""{0}""].ToString() ", pField);   //"string";
                    break;
                case "bit":
                    type = string.Format(@"bool.Parse(dr[""{0}""].ToString())", pField); ;//  "bool";
                    break;
                case "smallint":
                case "int":
                    type = string.Format(@"int.Parse(dr[""{0}""].ToString())", pField);  //"int";
                    break;
                case "bigint":
                    type = string.Format(@"Int32.Parse(dr[""{0}""].ToString())", pField);// "Int64";
                    break;
                case "long":
                    type = string.Format(@"Int64.Parse(dr[""{0}""].ToString())", pField);// "Int32";
                    break;
                case "money":
                case "decimal":
                case "float":
                case "real":
                case "smallmoney":
                case "numeric":
                    type = string.Format(@"double.Parse(dr[""{0}""].ToString())", pField);// "double";
                    break;
                case "datetime":
                case "date":
                    type = string.Format(@"DateTime.Parse(dr[""{0}""].ToString())", pField);// "DateTime";
                    break;
                case "binary":
                case "timestamp":
                case "time":
                case "varbinary":
                case "image":
                    type = string.Format(@"(byte[])dr[""{0}""]", pField);// "byte[]";
                    break;
                case "xml":
                    type = "*** Sin Valor de Conversion ****";
                    break;
                default:
                    type = string.Format("SINASIGNAR -> {0}", pSqlType);
                    break;
            }

            return type;
        }

        public  string GetClrType(string pSqlType)
        {
            string type = "";

            pSqlType = pSqlType.ToLower();

            switch (pSqlType)
            {
                case "nvarchar":
                case "varchar":
                case "ntext":
                case "nchar":
                case "text":
                case "char":
                    type = "string";
                    break;
                case "bit":
                    type = "bool";
                    break;
                case "smallint":
                case "int":
                    type = "int";
                    break;
                case "bigint":
                    type = "Int64";
                    break;
                case "long":
                    type = "Int32";
                    break;
                case "money":
                case "decimal":
                case "float":
                case "real":
                case "smallmoney":
                case "numeric":
                    type = "double";
                    break;
                case "datetime":
                case "date":
                    type = "DateTime";
                    break;
                case "binary":
                case "timestamp":
                case "time":
                case "varbinary":
                case "image":
                    type = "byte[]";
                    break;
                case "xml":
                    type = "xml";
                    break;
                default:
                    type = string.Format("SINASIGNAR -> {0}", pSqlType);
                    break;
            }


            return type;
        }
    }
}
