public class LoginDTO
{
    private string username;
    private string password;

    public LoginDTO(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }

    public string Username
    {
        get { return this.username; }
        private set { this.username = value; }
    }

    public string Password
    {
        get { return this.password; }
        private set { this.password = value; }
    }
}