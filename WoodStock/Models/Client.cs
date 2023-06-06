using System.ComponentModel.DataAnnotations;

namespace WoodStock.Models
{
    public class Client
    {
        [Key]
        public int Id_Client { get; set; }
        public int Id_Master { get; set; }
        public string Firsname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
