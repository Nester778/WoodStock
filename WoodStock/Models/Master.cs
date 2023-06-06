using Microsoft.AspNetCore.Identity;

namespace WoodStock.Models
{
    public class Master : IdentityUser
    {
        public int Id_Master { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CompanyName { get; set; }
    }
}
