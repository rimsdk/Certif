using System.Collections.Generic;

namespace Gestion_Certif.Model
{
    public class Departement
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<Certificat> certifs { get; set; }
    }
}
