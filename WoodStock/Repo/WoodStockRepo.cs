using Microsoft.EntityFrameworkCore;
using System.Linq;
using WoodStock.Models;

namespace WoodStock.Repo
{
    public class WoodStockRepo
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext context;

        public WoodStockRepo(AppDbContext context, IConfiguration config)
        {
            _config = config;
            this.context = context;
        }

        public Product GetProductById(int id, int MasterId) 
        {
            return context.Product.Where(x => x.Id_Product == id && x.Id_Master == MasterId).ToList()[0];
        }

        public Worker GetWorkerById(int MasterId)
        {
            var worker = context.Worker.Where(x => x.Id_Worker == MasterId);
            if (worker.Count() > 0)
                return worker.ToList()[0];
            else
                return null;
        }

        public Master GetMasterById(int MasterId)
        {
            var master = context.Master.Where(x => x.Id_Master == MasterId);
            if (master.Count() > 0)
                return master.ToList()[0];
            else
                return null;
        }

        public List<Product> GetProducts(int id)
        {
            return context.Product.Where(x => x.Id_Master == id).ToList();
        }
        public List<Order> GetOrders(int id)
        {
            return context.Order.Where(x => x.Id_Master == id).ToList();
        }
        public void AddProduct(Product product)
        {
            context.Entry(product).State = EntityState.Added;
            context.SaveChanges();
        }
        public void AddOrder(Order order)
        {
            context.Entry(order).State = EntityState.Added;
            context.SaveChanges();
        }
        public void DeleteProd(int id, int MasterId)
        { 
            Product product = GetProductById(id, MasterId);
            context.Remove(product); 
            context.SaveChanges();
        }
        public int GetMasterId(string Id)
        {
            Master master = context.Master.Where(x => x.Id == Id).ToList()[0];
            return master.Id_Master;
        }
    }
}
