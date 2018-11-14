using System;
using System.Collections.Generic;
using System.Data;

public interface IDataBase: IDisposable 
{
    IDbConnection _Conexion { get; set; }
    double ExecuteNonQuery(IDbCommand pCommand);
    int ExecuteNonQuery(ref IDbCommand pCommand, IsolationLevel pIsolationLevel);
    int  ExecuteNonQuery(List<IDbCommand> pCommands, IsolationLevel pIsolationLevel);
    double ExecuteNonQuery(IDbCommand pCommand, IsolationLevel pIsolationLevel);
    IDataReader ExecuteReader(IDbCommand pCommand);
    DataSet ExecuteReader(IDbCommand pCommand, string pTabla);
    double ExecuteScalar(IDbCommand pCommand);

}