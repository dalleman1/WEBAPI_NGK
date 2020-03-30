using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI_NGK.DataLayer.Models
{
    public class Weatherinfo
    {
        public int weatherinfoId { get; set; }
        [Required]
        [Display(Name = "Date:")]
        public string date { get; set; }
        [Required]
        [Display(Name = "Time:")]
        public string clocktime { get; set; }
        [Required]
        [Display(Name = "Temperature (C):")]
        public int temperature { get; set; }
        [Required]
        [Display(Name = "Humidity (%)")]
        public string humidity { get; set; }
        [Required]
        [Display(Name = "Wind (m/s)")]
        public int airpressure { get; set; }
    }
}
