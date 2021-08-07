using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PropertyMarketplace.Services
{
    public interface ICategoryService
    {
        IEnumerable<Models.Category> GetCategories();
        IEnumerable<Models.Category> GetSubCategories(int categoryId);
        
    }
}
