using CleanArchitectureAPi.Application.Common.Interfaces.Persistence;
using CleanArchitectureAPi.Domain.Entities;

namespace CleanArchitectureAPi.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    // Creates a readonly list of users.
    private static readonly List<Users> _users = new();

    // Adds a user.
    public void Add(Users user)
    {
        _users.Add(user);
    }

    // Get a user by their email and password.
    public Users? GetByEmailandPassword(string email, string password)
    {
        return _users.SingleOrDefault(u => u.Email == email & u.Password == password);
    }

    // Gets a user by first name and last name.
    public Users? GetByNameandSurname(string firstName, string lastName)
    {
        return _users.SingleOrDefault(u => u.FirstName == firstName & u.LastName == lastName);
    }

    // Gets a user by their email address.
    public Users? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
