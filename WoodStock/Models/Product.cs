using System.ComponentModel.DataAnnotations;

namespace WoodStock.Models
{
    public class Product
    {
        [Key]
        public int Id_Product { get; set; }
        public int Id_Material { get; set; }
        public int Id_Coating { get; set; }
        public int Id_Master { get; set; }
        public byte[] Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OnStock { get; set; }
        public int Cost { get; set; }
        public int Size_Y { get; set; }
        public int Size_X { get; set; }
        public int Size_Z { get; set; }
    }
}
