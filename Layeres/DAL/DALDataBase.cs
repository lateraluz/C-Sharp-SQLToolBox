using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using UTN.Winform.SQLToolBox.Layeres.Entities;
using UTN.Winform.SQLToolBox.Properties;

namespace UTN.Winform.SQLToolBox.Layeres.DAL
{
    class DALConnection
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");
        private User _User = new User();
        public DALConnection() {
            _User.Login = Settings.Default.Login;
            _User.Password = Settings.Default.Password;
            _User.Server = Settings.Default.Server; 
        }

        public  List<DataBaseStorage> GetDataBases()
        {
            
            DataSet dsBaseDatos = new DataSet();
            DataSet dsTablas = new DataSet();
            SqlCommand cmdBaseDatos = new SqlCommand();
            SqlCommand cmdTablas = new SqlCommand();
            List<DataBaseStorage> lista = new List<DataBaseStorage>();

            try
            { 
                cmdBaseDatos = new SqlCommand();
                cmdBaseDatos.CommandText = "select * from sys.databases where name <> 'master' and name <> 'msdb'  and name <> 'model' and name <> 'reportserver' and name <> 'reportservertempdb'";
                cmdBaseDatos.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_User.Login, _User.Password,_User.Server)))
                {
                    dsBaseDatos = db.ExecuteReader(cmdBaseDatos, "query");
                } 

                if (dsBaseDatos.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No existen bases de datos registradas !");
                }
                else
                {
                    foreach (DataRow item in dsBaseDatos.Tables[0].Rows)
                    {
                        DataBaseStorage oDataBase = new DataBaseStorage()
                        { 
                            DataBaseName = item["Name"].ToString().Trim(),
                            Id = int.Parse(item["database_id"].ToString())
                        };

                        cmdTablas = new SqlCommand();
                        // extraer todas las tablas que NO sean sysdiagrams
                        cmdTablas.CommandText = string.Format("select *  from [{0}].sys.tables where name <> 'sysdiagrams'", oDataBase.DataBaseName.Trim());
                        cmdTablas.CommandType = CommandType.Text;                        
                        dsTablas = new DataSet();

                        using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_User.Login, _User.Password,_User.Server)))
                        {
                            dsTablas = db.ExecuteReader(cmdTablas, "query");
                        }                        

                        foreach (DataRow tabla in dsTablas.Tables[0].Rows)
                        {
                            Table oTabla = new Table() {
                                Id = int.Parse(tabla["Object_id"].ToString()),
                                TableName = tabla["name"].ToString()
                            };
                            oDataBase.AgregarTabla(oTabla);
                        }                                                

                        lista.Add(oDataBase);
                    }
                }
                return lista;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", cmdTablas.CommandText);
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
