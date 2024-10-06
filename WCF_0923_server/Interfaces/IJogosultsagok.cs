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
    public interface IJogosultsagok
    {
        //CRUD műveletek

        //Read
        [OperationContract]
        List<Jogosultsagok> JogosultsagokLista_CS();
        //Create
        [OperationContract]
        string JogosultsagAdd_CS(Jogosultsagok felhasznalo);
        //Update
        [OperationContract]
        string JogosultsagUpdate_CS(Jogosultsagok felhasznalo);
        //Delete
        [OperationContract]
        string JogosultsagDelete_CS(int id);
    }
}
