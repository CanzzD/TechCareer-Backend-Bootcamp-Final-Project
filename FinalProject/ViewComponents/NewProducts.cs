using FinalProject.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.ViewComponents{
    public class NewProducts : ViewComponent{
        private IProductRepository _productRepository;

        public NewProducts(IProductRepository productRepository){
            _productRepository = productRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(){
            return View(await _productRepository
            .Products
            .OrderByDescending(p=>p.ProductPublishedOn)
            .Take(5)
            .ToListAsync());
        }
    }
}