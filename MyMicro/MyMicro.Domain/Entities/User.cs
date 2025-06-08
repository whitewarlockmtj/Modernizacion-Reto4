namespace MyMicro.Domain.Entities;

public class User
{
    public User(string name, string email)
    {
        if (!email.Contains("@"))
        {
            throw new ArgumentException("Email Inv�lido.", nameof(email));
        }
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}