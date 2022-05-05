using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AfricanFarmersCommodities.Domain
{
    public class FoodHubStorage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodHubStorageId { get; set; } = 0;
        public FoodHub FoodHub { get; set; }
        [ForeignKey("FoodHub")]
        public int FoodHubId { get; set; }
        public string FoodHubStorageName { get; set; }
        public decimal DryStorageCapacity { get; set; }
        public decimal RefreigeratedStorageCapacity { get; set; }
        public decimal UsedDryStorageCapacity { get; set; }
        public decimal UsedRefreigeratedStorageCapacity { get; set; }
        public CommodityUnit CommodityUnit { get; set; }
        [ForeignKey("CommodityUnit")]
        public int CommodityUnitId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
