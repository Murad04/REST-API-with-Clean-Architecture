using CleanArchitectureAPi.Domain.Entities;

namespace CleanArchitectureAPi.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Users? GetUserByEmail(string email);
    Users? GetByNameandSurname(string firstName, string lastName);
    Users? GetByEmailandPassword(string email, string password);
    void Add(Users user);
}