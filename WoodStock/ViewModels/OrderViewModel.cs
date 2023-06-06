using WoodStock.Models;

namespace WoodStock.ViewModels
{
    public class OrderViewModel
    {
        public Product Product { get; set; }
        public int Id_Prod { get; set; }
        public int Cost { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public int Id_Master { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
