using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_0923_server.Models;

namespace WCF_0923_server.DatabaseManager
{
    internal interface IDML
    {
        string Insert(Record record);
        string Update(Record record);
        string Delete(int id);
    }
}
