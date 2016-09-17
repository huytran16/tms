﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class createHouse
    {
        [Required]
        [StringLength(10, ErrorMessage ="The {0} must be at least {2} characters long.",MinimumLength =5)]
        [Display(Name = "HouseID")]
        public string HouseID { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Block")]
        public string Block { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Floor")]
        public string Floor { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "HouseName")]
        public string HouseName { get; set; }

       // [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Discription")]
        public string Discription { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Area")]
        public string Area { get; set; }

    }

   public class HouseModel
    {
        public List<string> BlockName { get; set; }
        public List<string> HouseName { get; set; }
    }
}