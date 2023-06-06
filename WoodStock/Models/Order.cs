using System.ComponentModel.DataAnnotations;

namespace WoodStock.Models
{
    public class Order
    {
        [Key]
        public int Id_Order { get; set; }
        public int Cost { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public int Id_Master { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
