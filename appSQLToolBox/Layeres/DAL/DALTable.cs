using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using UTN.Winform.SQLToolBox.Layeres.Entities;
using UTN.Winform.SQLToolBox.Properties;

namespace UTN.Winform.SQLToolBox.Layeres.DAL
{
    class DALTable
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");
        private User _User = new User();
        public DALTable()
        {
            _User.Login = Settings.Default.Login;
            _User.Password = Settings.Default.Password;
            _User.Server = Settings.Default.Server;
        }
       
        public List<Table> GetTable(  string pDataBase, string pServidor, string pUsuario, string pContrasena)
        {           
            DataSet ds = new DataSet();
            SqlCommand command = new SqlCommand(); ;
            List<Table> lista = new List<Table>();

            try
            {
                
                command.CommandText = string.Format("select * from  {0}..Sysobjects where xtype = 'U'", pDataBase);
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_User.Login, _User.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }                                 

                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No existen bases de datos registradas !");
                }
                else
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        Table oTable = new Table()
                        {
                            TableName = item["Name"].ToString().Trim(),
                            Id = int.Parse(item["id"].ToString())
                        };

                        oTable.ColumnList = new List<Column>();
                        lista.Add(oTable);
                    } 
                } 
                return lista;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Table GetTableStructure(string pDataBase, string pTable)
        {
            DataSet tableSpec = new DataSet();
            List<Column> listaColumnas = new List<Column>();
            List<Column> listaLlavesPrimarias = new List<Column>();
            string identity = "";
            SqlCommand command = new SqlCommand();

            try
            {
                // 15-7-2018 extrar cual es la identity
                identity = GetIdentityField(pDataBase, pTable);
                 
                command.CommandText = string.Format("use [{0}]; exec sp_help [{1}]", pDataBase, pTable); ;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_User.Login, _User.Password, _User.Server)))
                {
                    tableSpec = db.ExecuteReader(command, "query");
                }

                foreach (DataRow item in tableSpec.Tables[1].Rows)
                {
                    Column oColumna = new Column();

                    if (item["column_name"].ToString().Equals(identity, StringComparison.CurrentCultureIgnoreCase))
                        oColumna.Identity = true;
                    else
                        oColumna.Identity = false;

                    oColumna.Name = item["column_name"].ToString().Trim();
                    oColumna.Type = item["type"].ToString().Trim();
                    oColumna.Lenght = string.IsNullOrEmpty(item["length"].ToString().Trim()) == true ? 0 : int.Parse(item["length"].ToString());
                    oColumna.Precision = string.IsNullOrEmpty(item["prec"].ToString().Trim()) == true ? 0 : int.Parse(item["prec"].ToString());
                    oColumna.Scale = string.IsNullOrEmpty(item["scale"].ToString().Trim()) == true ? 0 : int.Parse(item["scale"].ToString());
                    oColumna.Nullable = item["Nullable"].ToString().Trim();
                    listaColumnas.Add(oColumna);
                }

                List<string> arregloLlavesPrimarias = new List<string>();
                // tiene datos para sacar la llave primaria
                if (tableSpec.Tables.Count > 6)
                {

                    // Corregido 11-3-2015
                    // arregloLlavesPrimarias = tableSpec.Tables[5].Rows[0]["index_keys"].ToString().Split(',').ToList<string>();

                    foreach (DataRow item in tableSpec.Tables[6].Rows)
                    {
                        if (item["Constraint_type"].ToString().Contains("PRIMARY KEY"))
                        {
                            arregloLlavesPrimarias = item["Constraint_keys"].ToString().Split(',').ToList<string>();
                        }
                    }

                    foreach (string item in arregloLlavesPrimarias)
                    {
                        listaLlavesPrimarias.Add(listaColumnas.Find(p => p.Name.ToLower().Trim().CompareTo(item.ToLower().Trim()) == 0));
                    }
                } 

                Table oTable = new Table()
                {
                    TableName = pTable,
                    ColumnList = listaColumnas,
                    PrimaryKeyList = listaLlavesPrimarias
                };

                return oTable;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }


        private string GetIdentityField(string pDataBase, string pTable)
        {
            string field = ""; 
            DataSet tableSpec = new DataSet();
            List<Column> listaColumnas = new List<Column>();
            List<Column> listaLlavesPrimarias = new List<Column>();
            SqlCommand command = new SqlCommand();

            try
            { 
                command.CommandText = string.Format("use [{0}]; exec sp_help [{1}]", pDataBase, pTable);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_User.Login, _User.Password, _User.Server)))
                {
                    tableSpec = db.ExecuteReader(command, "query");
                }

                foreach (DataRow item in tableSpec.Tables[2].Rows)
                {
                    field = item["Identity"].ToString();
                }

                // Si no tiene 
                if (field.ToUpper().Contains("No identity".ToUpper()) ||
                    field.ToUpper().Contains("No ".ToUpper()))
                {
                    field = "";
                }

                return field;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            } 
        }
    }
}
