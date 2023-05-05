namespace Domain.Models;

public class User
{
    public User(string name ,string password)
    {
        this.UserName = name;
        this.Password = password;
    }
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public ICollection<Post> Posts { get; set; }

    private User() { }

}