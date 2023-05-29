using PropertyMarketplace.Data;
using PropertyMarketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMarketplace.Services
{
    public class AutoMotoService : IAutoMotoService
    {
     
      
        private readonly PropertyMarketplaceContext _context;
        public AutoMotoService(PropertyMarketplaceContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Manufacturers> GetCarManufacturers()
        {
                IEnumerable<Manufacturers> manufacturers = _context.Manufacturers.Where(x => x.CategoryId == 2).ToList();
                return manufacturers;

            
        }
        public IEnumerable<Manufacturers> GetManufacturers(int SubCategoriesId)
        {
            IEnumerable<Manufacturers> manufacturers = _context.Manufacturers.Where(x => x.SubCategoryID == SubCategoriesId).ToList();
            return manufacturers;


        }
        public IEnumerable<Manufacturers> GetScooterManufacturers()
        {
            IEnumerable<Manufacturers> manufacturers = _context.Manufacturers.Where(x=> x.CategoryId == 10).ToList();
            return manufacturers;
        }
        public IEnumerable<Manufacturers> GetMotorcycleManufacturers()
        {
            IEnumerable<Manufacturers> manufacturers = _context.Manufacturers.Where(x => x.CategoryId == 9).ToList();
            return manufacturers;
        }
        public IEnumerable<Manufacturers> GetVanManufacturers()
        {
            IEnumerable<Manufacturers> manufacturers = _context.Manufacturers.Where(x => x.CategoryId == 8).ToList();
            return manufacturers;
        }

        public IEnumerable<AutoMotoModels> GetModels()
        {
            IEnumerable<AutoMotoModels> models = _context.AutoMotoModels.ToList();
            return models;
        }
        public IEnumerable<AutoMotoModels> GetCarModels(int ManufacturerId, int SubCategoriesId)
        {
            
            IEnumerable<AutoMotoModels> model = _context.AutoMotoModels.Where(x => x.ManufacturerID == ManufacturerId && x.SubCategoryID == SubCategoriesId).ToList();
            return model;
           
        }

        public IEnumerable<AutoMotoModels> GetScooterModels(int ManufacturerId)
        {
            IEnumerable<AutoMotoModels> model = _context.AutoMotoModels.Where(x => x.ManufacturerID == ManufacturerId).ToList();
            return model;

        }
        public IEnumerable<AutoMotoModels> GetMotorcycleModels(int ManufacturerId)
        {
            IEnumerable<AutoMotoModels> model = _context.AutoMotoModels.Where(x => x.ManufacturerID == ManufacturerId).ToList();
            return model;

        }
        public IEnumerable<AutoMotoModels> GetVanModels(int ManufacturerId)
        {
            IEnumerable<AutoMotoModels> model = _context.AutoMotoModels.Where(x => x.ManufacturerID == ManufacturerId).ToList();
            return model;

        }
    }
} 