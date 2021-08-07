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
            IEnumerable<Manufacturers> manufacturers = _context.Manufacturers.Where(x => x.CategoryId == SubCategoriesId).ToList();
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

        public IEnumerable<CarModels> GetModels()
        {
            IEnumerable<CarModels> models = _context.CarModels.ToList();
            return models;
        }
        public IEnumerable<CarModels> GetCarModels(int ManufacturerId)
        {
            
            IEnumerable<CarModels> model = _context.CarModels.Where(x => x.ManufacturerID == ManufacturerId).ToList();
            return model;
           
        }

        public IEnumerable<CarModels> GetScooterModels(int ManufacturerId)
        {
            IEnumerable<CarModels> model = _context.CarModels.Where(x => x.ManufacturerID == ManufacturerId).ToList();
            return model;

        }
        public IEnumerable<CarModels> GetMotorcycleModels(int ManufacturerId)
        {
            IEnumerable<CarModels> model = _context.CarModels.Where(x => x.ManufacturerID == ManufacturerId).ToList();
            return model;

        }
        public IEnumerable<CarModels> GetVanModels(int ManufacturerId)
        {
            IEnumerable<CarModels> model = _context.CarModels.Where(x => x.ManufacturerID == ManufacturerId).ToList();
            return model;

        }
    }
} 