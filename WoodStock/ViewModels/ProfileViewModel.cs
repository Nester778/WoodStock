using WoodStock.Models;

namespace WoodStock.ViewModels
{
    public class ProfileViewModel
    {
        public List<Order> Orders { get; set; }
        public Worker Worker { get; set; }
        public Master Master { get; set; }
        public string Position { get; set; }
        public int Sum { get; set; }
        public int Colv { get; set; }
    }
}
