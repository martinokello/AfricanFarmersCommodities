﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AfricanFarmersCommodities.Domain
{
    public class FoodHub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodHubId { get; set; } = 0;
        public string FoodHubName { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
