using PropertyMarketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMarketplace.ViewModels
{
    public class PropertyViewModel
    {
        public AdsBasicInfo AdsBasicInfo { get; set; }
        public Property Property { get; set; }
    }
}
