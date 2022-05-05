using System;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }
        public string Country { get; set; }
        public virtual AddressViewModel Address { get; set; }
        public int AddressId { get; set; }
        public string LocationName { get; set; }
    }
}