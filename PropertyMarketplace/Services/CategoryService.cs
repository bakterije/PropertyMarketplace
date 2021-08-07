using PropertyMarketplace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMarketplace.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PropertyMarketplaceContext _context;
        public CategoryService(PropertyMarketplaceContext context)
        {
            _context = context;
        }
        public IEnumerable<Models.Category> GetCategories()
        {
            IEnumerable<Models.Category> categories = _context.Category.Where(x => x.ParentId == null).ToList();
            return categories;


        }
        public IEnumerable<Models.Category> GetSubCategories(int categoryId)
        {
            IEnumerable<Models.Category> subcategories = _context.Category.Where(x => x.ParentId == categoryId).ToList();
            return subcategories;


        }
    }

}
