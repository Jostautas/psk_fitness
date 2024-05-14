using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using psk_fitness.Interfaces;

namespace psk_fitness.Repositories;

public class UserRepository(ApplicationDbContext _applicationDbContext) : IUserRepository
{
    public async Task<ApplicationUser> GetUserByIdAsync(string userEmail)
    {
        return await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail)
        ?? throw new Exception("User not found.");
    }
}
