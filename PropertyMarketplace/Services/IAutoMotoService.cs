using PropertyMarketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMarketplace.Services
{
    public interface IAutoMotoService
    {
        IEnumerable<Manufacturers> GetCarManufacturers();
        IEnumerable<Manufacturers> GetManufacturers(int SubCategoriesId);

        IEnumerable<Manufacturers> GetScooterManufacturers();
        IEnumerable<Manufacturers> GetMotorcycleManufacturers();
        IEnumerable<Manufacturers> GetVanManufacturers();
        IEnumerable<CarModels> GetModels();
        IEnumerable<CarModels> GetCarModels(int ManufacturerId);
        IEnumerable<CarModels> GetMotorcycleModels(int ManufacturerId);
        IEnumerable<CarModels> GetVanModels(int ManufacturerId);
        IEnumerable<CarModels> GetScooterModels(int ManufacturerId);

    }
}
