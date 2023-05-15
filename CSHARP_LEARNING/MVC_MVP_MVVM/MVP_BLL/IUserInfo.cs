namespace MVP_BLL
{
    public interface IUserInfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ErrorMessage { get; set; }

        public bool ShowFormMessage { get; set; }

        public event EventHandler SaveAttempted;
    }
}