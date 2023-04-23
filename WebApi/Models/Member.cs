using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Member")]
    public class Member
    {
        [Column("MemberId")]
        public string? Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
