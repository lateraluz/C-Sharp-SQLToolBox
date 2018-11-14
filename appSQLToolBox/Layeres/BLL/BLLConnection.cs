using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UTN.Winform.SQLToolBox.Layeres.DAL;
using UTN.Winform.SQLToolBox.Layeres.Entities;

namespace  UTN.Winform.SQLToolBox.Layeres.BLL
{
    class BLLDataBase
    { 
        private  List<DataBaseStorage> _DataBases; 
        public  List<DataBaseStorage> GetDataBases()
        {
            DALConnection _DALConnection = new DALConnection();
            _DataBases = _DALConnection.GetDataBases( );
            return _DataBases;        
        }
         
    }
}
