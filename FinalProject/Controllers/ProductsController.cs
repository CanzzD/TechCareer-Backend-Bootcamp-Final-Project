using FinalProject.Data.Abstract;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using FinalProject.Data.Concrete;
using FinalProject.Data.Concrete.EfCore;
using FinalProject.Entity;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class ProductsController : Controller
    {

        private IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public IActionResult Index()
        {
            return View(
                new ProductViewModel
                {
                    Products = _productRepository.Products.ToList(),

                }
            );
        }

        [Authorize]
        public IActionResult Create()
        {
            
            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ProductCreateViewModel model, IFormFile imageFile)
{
    var allowenExtensions = new[] { ".jpg", ".png", ".jpeg" };
    if (imageFile != null)
    {
        var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
        if (!allowenExtensions.Contains(extension))
        {
            ModelState.AddModelError("", "Geçerli Bir Resim Seçiniz!");
        }
        else
        {
            var randomfileName = string.Format($"{Guid.NewGuid()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomfileName);

            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                model.Image = randomfileName;
            }
            catch
            {
                ModelState.AddModelError("", "Dosya Yüklenirken Bir Hata Oluştu!");
            }
        }
    }
    else
    {
        ModelState.AddModelError("", "Bir resim dosyası seçiniz.");
    }

    if (ModelState.IsValid)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _productRepository.CreateProduct(
            new Product
            {
                ProductName = model.ProductName,
                ProductCategory = model.ProductCategory,
                ProductDescription = model.ProductDescription,
                ProductPrice = model.ProductPrice,
                ProductUrl = model.ProductUrl,
                SellerId = int.Parse(userId ?? ""),
                StockQuantity = model.StockQuantity,
                Image = model.Image ?? "avatar.jpg",
            });

        return RedirectToAction("Index");
    }
    return View(model);
}


        public async Task<IActionResult> Details(string url)
        {
            return View(await _productRepository.Products.FirstOrDefaultAsync(p => p.ProductUrl == url));
        }
    }
}