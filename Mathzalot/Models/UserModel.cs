using System.ComponentModel.DataAnnotations;

namespace Mathzalot.Models
{
    public class UserModel
    {
        public int Id {get; set;}
        public string Username {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public int Points {get; set;}

        //Foreign
        public int Rank {get; set;}

    }
}