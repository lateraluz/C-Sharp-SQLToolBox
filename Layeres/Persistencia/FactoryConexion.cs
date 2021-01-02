using System;
using System.Configuration;
using System.Text;


class FactoryConexion
{

    public static string CreateConnection(string pUsuario, String pContrasena)
    {
        
        StringBuilder conexion = new StringBuilder();
        bool existe = false;

        // Validacion de la conexion
        if (ConfigurationManager.ConnectionStrings.Count == 0) {
            throw new Exception("No existen registradas ConnectionStrings en el archivo app.config, revise!");
        }

        for (int i = 0; i < ConfigurationManager.ConnectionStrings.Count -1; i++)
        {
            if (ConfigurationManager.ConnectionStrings[i].Name.Equals("default", StringComparison.InvariantCultureIgnoreCase))
                existe = true;
        }

        if (!existe) {
            throw new Exception("No existe registrada en ConnectionStrings del app.config el Key default!");
        }
        
        // Lee la conexion default
        conexion.AppendFormat("{0}", ConfigurationManager.ConnectionStrings["default"].ConnectionString);
        // Agrega al usuario
        conexion.AppendFormat("User Id={0};Password={1}", pUsuario, pContrasena);
        return conexion.ToString();
    }

    public static string CreateConnection(string pUsuario, String pContrasena, string pServer,string pDataBase)
    {

        StringBuilder conexion = new StringBuilder(); 
        // Agrega al usuario
        conexion.AppendFormat("User Id={0};Password={1};Data Source={2};Database={3}", pUsuario, pContrasena,pServer, pDataBase);
        return conexion.ToString();
    }

    public static string CreateConnection(string pUsuario, String pContrasena, string pServer)
    { 
        StringBuilder conexion = new StringBuilder();
        // Agrega al usuario
        conexion.AppendFormat("User Id={0};Password={1};Data Source={2};", pUsuario, pContrasena, pServer );
        return conexion.ToString();
    }

}

