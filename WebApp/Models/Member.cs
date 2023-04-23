using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Member")]
    public class Member
    {

        [Column("MemberId")]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        //1 Account => 1 AccessToken
        public string? AccessToken { get; set; }
        [NotMapped]
        public List<Member> Customers { get; set; }

    }
}
