﻿using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Models
{
    [Table("Carousel")]
    public class Carousel
    {
        public short CarouselId { get; set; }
        public string CategoryName { get; set; }
        public string CarouselUrl { get; set; }
    }
}
