
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
    class DALSql
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");
        private User _User = new User();
        public DALSql()
        {
            _User.Login = Settings.Default.Login;
            _User.Password = Settings.Default.Password;
            _User.Server = Settings.Default.Server;
            
        }

        public double ExecuteSQLDDL_DLC(string pDataBase, string pSql)
        {

            SqlCommand command = new SqlCommand();
            double rows = 0;
            try
            { 
                  command.CommandText = string.Format("{0}", pSql);
               // command.CommandText = string.Format("exec {0}..sp_executesql {1} ", pDataBase,  pSql);
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_User.Login, _User.Password, _User.Server,pDataBase)))
                {
                    rows = db.ExecuteNonQuery(command);
                }

                return rows;
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

        public DataSet ExecuteSQLDML(string pDataBase, string pSql)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = string.Format("use {0}{1};{2}{3}",pDataBase, Environment.NewLine,Environment.NewLine,pSql);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_User.Login, _User.Password, _User.Server)))
                {
                    ds = db.ExecuteReader(command, "query");
                }
                return ds;
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
