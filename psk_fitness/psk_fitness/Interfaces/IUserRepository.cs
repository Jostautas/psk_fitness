using psk_fitness.Data;

namespace psk_fitness.Interfaces;

public interface IUserRepository
{
    Task<ApplicationUser> GetUserByIdAsync(string userEmail);
}