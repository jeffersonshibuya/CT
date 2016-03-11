using System;
using System.ComponentModel.DataAnnotations;

namespace CT.Appllication.ViewModels
{
    public class EntProjetosViewModel
    {
        [Key]
        public int EP_ID { get; set; }
        public int ENT_COD { get; set; }
        public string PRO_COD { get; set; }
        public DateTime EP_DATA_LIMITE { get; set; }
        public decimal EP_VALOR { get; set; }
    }
}