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
        IEnumerable<AutoMotoModels> GetModels();
        IEnumerable<AutoMotoModels> GetCarModels(int ManufacturerId, int SubCategoriesId);
        IEnumerable<AutoMotoModels> GetMotorcycleModels(int ManufacturerId);
        IEnumerable<AutoMotoModels> GetVanModels(int ManufacturerId);
        IEnumerable<AutoMotoModels> GetScooterModels(int ManufacturerId);

    }
}
