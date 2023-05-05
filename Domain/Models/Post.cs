namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }

    public string Description { get; }

    public Post(User owner, string title, string description)
    {
        Owner = owner;
        Title = title;
        Description = description;
    }
    private Post() { }
}