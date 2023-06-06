using System.ComponentModel.DataAnnotations;

namespace WoodStock.Models
{
    public class Coating
    {
        [Key]
        public int Id_Coating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
