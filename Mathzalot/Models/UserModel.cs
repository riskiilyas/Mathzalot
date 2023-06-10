using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mathzalot.Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public int Id {get; set;}
        public string Username {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public int Points {get; set;}

        //Foreign
        public int Rank {get; set;}

    }
}