using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_0923_server.Interfaces;

namespace WCF_0923_server
{
    [ServiceContract]
    public interface IService1 : IFelhasznalok, IJogosultsagok
    {
        
    }

}
