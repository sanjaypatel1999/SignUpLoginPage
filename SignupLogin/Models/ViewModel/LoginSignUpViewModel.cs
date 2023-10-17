namespace SignupLogin.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IActive { get; set; }
        public bool IsRemember { get; set; }
    }
}
