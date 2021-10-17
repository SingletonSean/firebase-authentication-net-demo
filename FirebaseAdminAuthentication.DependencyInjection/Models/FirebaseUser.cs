namespace FirebaseAdminAuthentication.DependencyInjection.Models
{
    public class FirebaseUser
    {
        public string Id { get; }
        public string Email { get; }
        public string Username { get; }
        public bool EmailVerified { get; }

        public FirebaseUser(string id, string email, string username, bool emailVerified)
        {
            Id = id;
            Email = email;
            Username = username;
            EmailVerified = emailVerified;
        }
    }
}
