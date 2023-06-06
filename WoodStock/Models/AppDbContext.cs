using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WoodStock.Models
{
    public class AppDbContext : IdentityDbContext<Worker>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Master> Master { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Coating> Coating { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            byte[] data = new byte[] { 10, 20, 30, 40, 50 };
            modelBuilder.Entity<Master>().HasData(new Master { Id_Master = 1, Firstname = "Masta", Lastname = "Matsa", Email = "Milo@gmail.com", PasswordHash = "1111", CompanyName = "TestCompany"});
            modelBuilder.Entity<Worker>().HasData(new Worker { Id_Worker = 1, Id_Master = 1, Avatar = data, Firstname = "Jakobs", Lastname = "Svin", Email = "svin@gmail.com", Position = "worker", Salary = 1000 });
            modelBuilder.Entity<Client>().HasData(new Client { Id_Client = 1, Id_Master = 1, Firsname = "Vasia", Lastname = "Litvin", Email = "milo@gmail.com", Address = "Kharkov"});
            modelBuilder.Entity<Product>().HasData(new Product { Id_Product = 1, Id_Master = 1, Cost = 1000, Description = "Text text text text text", OnStock = 123, Photo = data, Size_X = 1, Size_Y = 1, Size_Z = 1, Title = "title title", Id_Coating = 1, Id_Material = 1 });
            modelBuilder.Entity<Material>().HasData(new Material { Id_Material = 1, Description = "Text text text text text", Title = "title title" });
            modelBuilder.Entity<Coating>().HasData(new Coating { Id_Coating = 1, Description = "Text text text text text", Title = "title title" });
            modelBuilder.Entity<Order>().HasData(new Order { Id_Order = 1, Id_Master = 1, Cost = 1000, ClientName = "User", Address = "dlmsdlsdl", CreateDate = DateTime.Now });
        }
    }
}
