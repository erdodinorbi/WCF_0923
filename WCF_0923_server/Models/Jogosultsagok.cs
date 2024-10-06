using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_0923_server.Models
{
    [DataContract]
    public class Jogosultsagok : Record
    {
        [DataMember]
        public int Szint { get; set; }
        [DataMember]
        public string Nev {  get; set; }
        [DataMember]
        public string Leiras { get; set; }
    }
}