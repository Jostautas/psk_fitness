using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace psk_fitness.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicFriend> TopicFriends { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuring the composite key for TopicFriend
            modelBuilder.Entity<TopicFriend>()
                .HasKey(tf => new { tf.TopicId, tf.ApplicationUserId });

            // Configuring the one-to-many relationship between ApplicationUsers and Topics

            modelBuilder.Entity<Exercise>()
                .HasOne(t => t.ApplicationUser)
                .WithMany(au => au.Exercise) 
                .HasForeignKey(t => t.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Topic>()
                .HasOne(t => t.ApplicationUser)
                .WithMany(au => au.Topics) // Assuming ApplicationUser has a Topics collection
                .HasForeignKey(t => t.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TopicFriend>()
                .HasOne(tf => tf.Topic)
                .WithMany(t => t.TopicFriends)
                .HasForeignKey(tf => tf.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Workout>()
                .HasOne(w => w.Topic)
                .WithMany(t => t.Workouts)
                .HasForeignKey(w => w.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.ConcurrencyStamp).HasColumnType("TEXT");
            });
        }

    }
}