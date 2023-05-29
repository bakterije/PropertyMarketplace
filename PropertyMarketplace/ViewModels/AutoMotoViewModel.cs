using PropertyMarketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMarketplace.ViewModels
{
    public class AutoMotoViewModel
    {
        public AdsBasicInfo AdsBasicInfo { get; set; }
        public AutoMoto AutoMoto { get; set; }
        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
    }
}
