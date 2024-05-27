using Microsoft.AspNetCore.Identity;

namespace psk_fitness.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int? Height { get; set; }
        public double? Weight { get; set; }
        public int? Age { get; set; }
        public virtual ICollection<Topic>? Topics { get; set; }
        public virtual ICollection<Exercise>? Exercise { get; set; }

    }
}
