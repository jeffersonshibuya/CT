using System;

namespace CT.Domain.Entities
{
    public class EntLicencas
    {
        public int ID { get; set; }
        public string SERIAL { get; set; }
        public string CHAVE{ get; set; }
        //KEY
        public string LICENCIADO { get; set; }
        public string ID_MD5 { get; set; }
    }
}