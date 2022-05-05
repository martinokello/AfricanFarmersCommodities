using AfricanFarmerCommodities.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AfricanFarmersCommodities.Domain
{
    public class Commodity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommodityId { get; set; } = 0;

        public string CommodityName { get; set; }

        public string CommodityDescription { get; set; }

        public decimal CommodityUnitPrice { get; set; }

        public decimal NumberOfUnits { get; set; }
        public CommodityUnit CommodityUnit { get; set; }
        public Company Company{get;set;}
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public string Username { get; set; }
        [ForeignKey("CommodityUnit")]
        public int CommodityUnitId { get; set; }
        [ForeignKey("CommodityCategory")]
        public int CommodityCategoryId { get; set; }
        public CommodityCategory CommodityCategory { get; set; }
        [ForeignKey("Farmer")]
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
