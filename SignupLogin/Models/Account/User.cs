using System.ComponentModel.DataAnnotations;

namespace SignupLogin.Models.Account
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public bool IActive { get; set; }
        public bool IsRemember { get; set; }

    }
}
