using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_0923_server.Controllers;
using WCF_0923_server.Models;

namespace WCF_0923_server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string FelhasznaloAdd_CS(Felhasznalok felhasznalo)
        {
            FelhasznalokController controller = new FelhasznalokController();
            return controller.Insert(felhasznalo);
        }

        public string FelhasznalokDelete_CS(int id)
        {
            FelhasznalokController controller = new FelhasznalokController();
            string valasz = controller.Delete(id);
            return valasz;
        }

        public List<Felhasznalok> FelhasznalokLista_CS()
        {
            FelhasznalokController controller = new FelhasznalokController();
            List<Record> rekordok = controller.Select();
            List<Felhasznalok> ujLista = new List<Felhasznalok>();
            foreach(Record record in rekordok)
            {
                ujLista.Add(record as Felhasznalok);
            }
            return ujLista;
            //Korai verzió
            /*List<Felhasznalok> felhLista = new List<Felhasznalok>();
            Felhasznalok f1 = new Felhasznalok()
            {
                Id = 1,
                LoginNev = "pimpike",
                Hash = "asdfghjktu",
                Salt = "KKJHGDGUJ",
                Nev = "Bojtos Pimpike",
                Jog = 1,
                Aktiv = true,
                Email = "pimpike@pimpserver.hu",
                Profilkep = "pimpike.jpg"
            };
            felhLista.Add(f1);
            return felhLista;*/
        }

        public string FelhasznaloUpdate_CS(Felhasznalok felhasznalo)
        {
            FelhasznalokController controller = new FelhasznalokController();
            return controller.Update(felhasznalo);
        }

        public string JogosultsagAdd_CS(Jogosultsagok jogosultsag)
        {
            JogosultsagokController controller = new JogosultsagokController();
            return controller.Insert(jogosultsag);
        }

        public string JogosultsagDelete_CS(int id)
        {
            JogosultsagokController controller = new JogosultsagokController();
            string valasz = controller.Delete(id);
            return valasz;
        }

        public List<Jogosultsagok> JogosultsagokLista_CS()
        {
            JogosultsagokController controller = new JogosultsagokController();
            List<Record> rekordok = controller.Select();
            List<Jogosultsagok> ujLista = new List<Jogosultsagok>();
            foreach (Record record in rekordok)
            {
                ujLista.Add(record as Jogosultsagok);
            }
            return ujLista;
        }

        public string JogosultsagUpdate_CS(Jogosultsagok jogosultsag)
        {
            JogosultsagokController controller = new JogosultsagokController();
            return controller.Update(jogosultsag);
        }
    }
}
