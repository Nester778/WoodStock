using System.ComponentModel.DataAnnotations;

namespace WoodStock.Models
{
    public class Material
    {
        [Key]
        public int Id_Material { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
