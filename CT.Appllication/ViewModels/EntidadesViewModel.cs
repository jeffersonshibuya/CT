using System;
using System.ComponentModel.DataAnnotations;

namespace CT.Appllication.ViewModels
{
    public class EntidadesViewModel
    {
        [Key]
        public int ENT_COD { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        public string ENT_NOME { get; set; }

        public string ENT_FANTASIA { get; set; }

        public string ENT_TP_FISCAL { get; set; }
        public DateTime ENT_DT_CAD { get; set; }
        public string ENT_STATUS { get; set; }
    }
}