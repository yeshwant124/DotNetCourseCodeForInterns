namespace DotNetAPIIntermediate.DTO
{
    public partial class UserForRegistrationDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public UserForRegistrationDTO()
        {
            if(Email == null) 
            {
                Email = string.Empty;
            }
            if (Password == null)
            {
                Password = string.Empty;
            }
            if (PasswordConfirm == null)
            {
                PasswordConfirm = string.Empty;
            }
        }
    }
}
