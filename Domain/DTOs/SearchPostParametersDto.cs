namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public string? Username { get;}
    public int? UserId { get;}
    public string? DescriptionContains { get;}
    public string? TitleContains { get;}

    public SearchPostParametersDto(string? username, int? userId, string? titleContains, string? descriptionContains)
    {
        Username = username;
        UserId = userId;
        DescriptionContains = descriptionContains;
        TitleContains = titleContains;
    }
}