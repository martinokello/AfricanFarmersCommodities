using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class FoodHubViewModel
    {
        public int FoodHubId { get; set; }
        public string FoodHubName { get; set; }
        public string Description { get; set; }
        public LocationViewModel Location { get; set; }
        public int LocationId { get; set; }
    }
}
