using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using WoodStock.Models;
using WoodStock.Repo;
using WoodStock.ViewModels;

namespace WoodStock.Controllers
{
    public class CreateProductController : Controller
    {
        private readonly WoodStockRepo _repo;
        public CreateProductController(WoodStockRepo repo)
        {
            _repo = repo;
        }

        public IActionResult CreateProd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProd(CreateProdViewModel cpvm)
        {
            var currentUser = HttpContext.User;
            string MasterId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Product product;
            if (cpvm.Avatar != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                var binaryReader = new BinaryReader(cpvm.Avatar.OpenReadStream());
                imageData = binaryReader.ReadBytes((int)cpvm.Avatar.Length);
                // установка массива байтов
                product = new Product
                {
                    Photo = imageData,
                    Cost = cpvm.Cost,
                    Description = cpvm.Description,
                    OnStock = cpvm.OnStock,
                    Id_Coating = 1,
                    Id_Material = 1,
                    Size_X = cpvm.Size_X,
                    Size_Y = cpvm.Size_Y,
                    Size_Z = cpvm.Size_Z,
                    Title = cpvm.Title,
                    Id_Master = _repo.GetMasterId(MasterId)
                };
                _repo.AddProduct(product);
                return RedirectToAction("Catalog", "Catalog");
            }
            else {
                return RedirectToAction("CreateProd");
            }

            
        }
    }
}
