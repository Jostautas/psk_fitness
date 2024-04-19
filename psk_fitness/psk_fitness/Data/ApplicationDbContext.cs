using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace psk_fitness.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicFriend> TopicFriends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuring the composite key for TopicFriend
            modelBuilder.Entity<TopicFriend>()
                .HasKey(tf => new { tf.TopicId, tf.ApplicationUserId });

            // Configuring the one-to-many relationship between ApplicationUsers and Topics
            modelBuilder.Entity<Topic>()
                .HasOne(t => t.ApplicationUser)
                .WithMany(au => au.Topics) // Assuming ApplicationUser has a Topics collection
                .HasForeignKey(t => t.ApplicationUserId);

            // Configuring the many-to-one relationship between TopicFriends and Topics
            modelBuilder.Entity<TopicFriend>()
                .HasOne(tf => tf.Topic)
                .WithMany(t => t.TopicFriends)
                .HasForeignKey(tf => tf.TopicId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}