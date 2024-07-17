using FinalProject.Data.Abstract;
using FinalProject.Data.Concrete.EfCore;
using FinalProject.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data.Concrete
{
    public class EfProductRepository : IProductRepository
    {

        private readonly SocialAppDbContext _context;
        public EfProductRepository(SocialAppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Products;

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            var entity = _context.Products.FirstOrDefault(i=>i.ProductId == product.ProductId);

            if(entity != null){
                entity.ProductName = product.ProductName;
                entity.ProductDescription = product.ProductDescription;
                entity.ProductCategory = product.ProductCategory;
                entity.ProductUrl = product.ProductUrl;
                entity.StockQuantity = product.StockQuantity;

                _context.SaveChanges();
            }
        }

        public void EditProduct(Product product, int[] categoryIds)
        {
            var entity = _context.Products.Include(x=>x.Categories).FirstOrDefault(i=>i.ProductId == product.ProductId);

            if(entity != null){
                entity.ProductName = product.ProductName;
                entity.ProductDescription = product.ProductDescription;
                entity.ProductPrice = product.ProductPrice;
                entity.ProductCategory = product.ProductCategory;
                entity.ProductUrl = product.ProductUrl;
                entity.StockQuantity = product.StockQuantity;

                entity.Categories = _context.Categories.Where(category=>categoryIds.Contains(category.CategoryId)).ToList();

                _context.SaveChanges();
            }
        }
    }
}