namespace StudentCounselling.Data
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string userName, string Password);
    }
}
