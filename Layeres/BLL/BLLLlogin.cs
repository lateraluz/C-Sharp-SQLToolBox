using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.SQLToolBox.Layeres.DAL;

namespace UTN.Winform.SQLToolBox.Layeres.BLL
{
    class BLLLlogin
    {
        public bool Login(string pUsuario, string pContrasena, string pServer)
        {
            DALLogin _DALLogin = new DALLogin();
            return _DALLogin.Login(pUsuario, pContrasena, pServer);
        }
    }
}
