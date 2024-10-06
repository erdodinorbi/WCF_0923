using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_0923_server.Models
{
    [DataContract]
    public class Felhasznalok : Record
    {
        [DataMember]
        public string LoginNev { get; set; }
        [DataMember]
        public string Hash {  get; set; }
        [DataMember]
        public string Salt { get; set; }
        [DataMember]
        public string Nev { get; set; }
        [DataMember]
        public int Jog { get; set; }
        [DataMember]
        public bool Aktiv { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Profilkep { get; set; }
        
    }
}