using FinalProject.Entity;

namespace FinalProject.Data.Abstract{
    public interface IProductRepository{
        IQueryable<Product> Products {get;}

        void CreateProduct(Product product);
        void EditProduct(Product product);
        void EditProduct(Product product, int[] categoryIds);
    }
}