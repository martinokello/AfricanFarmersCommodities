using AfricanFarmerCommodities.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricanFarmersCommodities.Domain
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; } = 0;
        public bool InGoodCondition { get; set; }
        public string VehicleRegistration { get; set; }
        public VehicleCapacity VehicleCapacity { get; set; }
        [ForeignKey("VehicleCapacity")]
        public int VehicleCapacityId { get; set; }
        public Company Company { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public VehicleCategory VehicleCategory { get; set; }
        [ForeignKey("VehicleCategory")]
        public int VehicleCategoryId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }

}
