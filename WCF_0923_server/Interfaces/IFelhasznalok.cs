using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_0923_server.Models;

namespace WCF_0923_server.Interfaces
{
    [ServiceContract]
    public interface IFelhasznalok
    {
        //CRUD műveletek

        //Read
        [OperationContract]
        List<Felhasznalok> FelhasznalokLista_CS();
        //Create
        [OperationContract]
        string FelhasznaloAdd_CS(Felhasznalok felhasznalo);
        //Update
        [OperationContract]
        string FelhasznaloUpdate_CS(Felhasznalok felhasznalo);
        //Delete
        [OperationContract]
        string FelhasznalokDelete_CS(int id);
    }
}
