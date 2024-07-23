using FinalProject.Data.Abstract;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using FinalProject.Entity;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class ProductsController : Controller
    {

        private IProductRepository _productRepository;
        private ICommentRepository _commentRepository;

        private ICategoryRepository _categoryRepository;
        public ProductsController(IProductRepository productRepository, ICommentRepository commentRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _commentRepository = commentRepository;
            _categoryRepository = categoryRepository;

        }
        public async Task<IActionResult> Index(string category)
        {
            var products = _productRepository.Products;
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(x => x.Categories.Any(t => t.CategoryUrl == category));
            }
            return View(new ProductViewModel { Products = await products.ToListAsync() });
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
                        ProductTitle = model.ProductTitle,
                        ProductCategory = model.ProductCategory,
                        ProductDescription = model.ProductDescription,
                        ProductPrice = model.ProductPrice,
                        ProductUrl = model.ProductUrl,
                        UserId = int.Parse(userId ?? ""),
                        ProductPublishedOn = DateTime.Now,
                        Image = model.Image ?? "avatar.jpg",
                        IsActive = false
                    });

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> List()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var role = User.FindFirstValue(ClaimTypes.Role);

            var products = _productRepository.Products;
            if (string.IsNullOrEmpty(role))
            {
                products = products.Where(i => i.UserId == userId);
            }
            return View(await products.ToListAsync());
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productRepository.Products.Include(x => x.Categories).FirstOrDefault(i => i.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _categoryRepository.Categories.ToList();
            return View(new ProductCreateViewModel
            {
                ProductId = product.ProductId,
                ProductTitle = product.ProductTitle,
                ProductDescription = product.ProductDescription,
                ProductCategory = product.ProductCategory,
                Image = product.Image,
                ProductUrl = product.ProductUrl,
                IsActive = product.IsActive,
            });
        }

        [Authorize]
        [HttpPost]

        public IActionResult Edit(ProductCreateViewModel model, int[] categoryIds)
        {
            if (ModelState.IsValid)
            {
                var entityToUpdate = new Product
                {
                    ProductId = model.ProductId,
                    ProductTitle = model.ProductTitle,
                    ProductDescription = model.ProductDescription,
                    ProductCategory = model.ProductCategory,
                    ProductUrl = model.ProductUrl
                };

                if (User.FindFirstValue(ClaimTypes.Role) == "admin")
                {
                    entityToUpdate.IsActive = model.IsActive;
                }
                _productRepository.EditProduct(entityToUpdate, categoryIds);
                return RedirectToAction("List");
            }
            ViewBag.Tags = _categoryRepository.Categories.ToList();
            return View(model);
        }

        [HttpPost]
        public JsonResult AddComment(int ProductId, string CommentText)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment
            {
                ProductId = ProductId,
                CommentText = CommentText,
                CommentPublishedOn = DateTime.Now,
                UserId = int.Parse(userId ?? "")
            };
            _commentRepository.CreateComment(entity);

            return Json(new
            {
                username,
                CommentText,
                entity.CommentPublishedOn,
                avatar
            });
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _productRepository.Products.Include(x => x.User).Include(x => x.Categories).Include(x => x.Comments).ThenInclude(x => x.User).FirstOrDefaultAsync(p => p.ProductUrl == url));
        }
    }
}