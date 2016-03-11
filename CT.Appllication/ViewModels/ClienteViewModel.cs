using System.ComponentModel.DataAnnotations;

namespace CT.Appllication.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ID { get; set; }
        public string NOME { get; set; }
    }
}