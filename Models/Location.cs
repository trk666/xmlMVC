using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace xmlMVC.Models
{
    public class Location
    {
        [Display(Name = "預報區域")]
        public string LocationName { get; set; }

        [Display(Name = "起始時間")]
        public string StartTime { get; set; }

        [Display(Name = "結束時間")]
        public string EndTime { get; set; }

        [Display(Name = "天氣現象")]
        public string Wx { get; set; }

        [Display(Name = "風向")]
        public string WindDir { get; set; }

        [Display(Name = "風速")]
        public string WindSpeed { get; set; }

        [Display(Name = "浪高")]
        public  string WaveHeight { get; set; }

        [Display(Name = "浪況")]
        public  string WaveType { get; set; }
    }
}