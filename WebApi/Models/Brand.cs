using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Brand")]
    public class Brand
    {
        public short BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
