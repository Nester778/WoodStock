using WoodStock.Models;

namespace WoodStock.ViewModels
{
    public class CatalogViewModel
    {
        public List<Product> Products { get; set; }
        public string Search { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int MinCost { get; set; }
        public int MaxCost { get; set; }

    }
}
