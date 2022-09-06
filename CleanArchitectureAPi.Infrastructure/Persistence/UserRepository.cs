using CleanArchitectureAPi.Application.Common.Interfaces.Persistence;
using CleanArchitectureAPi.Domain.Entities;

namespace CleanArchitectureAPi.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<Users> _users = new();

    public void Add(Users user)
    {
        _users.Add(user);
    }

    public Users? GetByEmailandPassword(string email, string password)
    {
        return _users.SingleOrDefault(u => u.Email == email & u.Password == password);
    }

    public Users? GetByNameandSurname(string firstName, string lastName)
    {
        return _users.SingleOrDefault(u => u.FirstName == firstName & u.LastName == lastName);
    }

    public Users? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
