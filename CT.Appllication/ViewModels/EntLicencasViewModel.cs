using System;
using System.ComponentModel.DataAnnotations;

namespace CT.Appllication.ViewModels
{
    public class EntLicencasViewModel
    {
        public int ID { get; set; }
        public string SERIAL { get; set; }
        public string CHAVE { get; set; }
        [Key]
        public string LICENCIADO { get; set; }
        public string ID_MD5 { get; set; }
    }
}