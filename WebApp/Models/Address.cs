using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        public string AddressName { get; set; }
        public Guid MemberId { get; set; }
        public int WardId { get; set; }
        public string? WardName { get; set; }
        public short DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public byte ProvinceId { get; set; }
        public string? ProvinceName { get; set; }
        [Required]
        [MinLength(9)]
        [MaxLength(16)]
        public string Phone { get; set; }
        public byte IsDefault { get; set; }
    }
}
