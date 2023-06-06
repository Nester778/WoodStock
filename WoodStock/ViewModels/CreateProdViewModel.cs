namespace WoodStock.ViewModels
{
    public class CreateProdViewModel
    {
        public int Id_Product { get; set; }
        public string Material { get; set; }
        public string Coating { get; set; }
        public IFormFile Avatar { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OnStock { get; set; }
        public int Cost { get; set; }
        public int Size_Y { get; set; }
        public int Size_X { get; set; }
        public int Size_Z { get; set; }
    }
}
