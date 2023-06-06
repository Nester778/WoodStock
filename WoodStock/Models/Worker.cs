using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WoodStock.Models
{
    public class Worker : IdentityUser
    {
        [Key]
        public int Id_Worker { get; set; }
        public int Id_Master { get; set; }
        public byte[] Avatar { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }


    }
}
