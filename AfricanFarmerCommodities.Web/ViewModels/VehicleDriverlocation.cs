using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class VehicleDriverlocation
    {
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string VehicleRegistration { get; set; }
        public string Lattitude { get; set; }
        public string Longitude { get; set; }
        public bool UpdatePhoneNumber { get; set; } = false;
        public override bool Equals(object current)
        {
            return this.VehicleRegistration.ToLower().Equals((current as VehicleDriverlocation).VehicleRegistration.ToLower());
        }
        public override int GetHashCode()
        {
            return (int) Math.Pow(VehicleRegistration.Length * Lattitude.Length * Longitude.Length, 3);
        }
    }
}
