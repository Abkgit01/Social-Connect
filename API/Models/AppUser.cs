namespace API.Models
{
    public class AppUser
    {
        #region Class Properties

        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        #endregion
    }
}
