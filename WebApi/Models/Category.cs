using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Models
{
    [Table("Category")]
    public class Category
    {
        public short CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
