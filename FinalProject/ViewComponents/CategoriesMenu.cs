using FinalProject.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.ViewComponents{

    public class CategoriesMenu : ViewComponent
    {
         private ICategoryRepository _categoryRepository;

        public CategoriesMenu(ICategoryRepository categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(){
            return View(await _categoryRepository.Categories.ToListAsync());
        }
    }
}