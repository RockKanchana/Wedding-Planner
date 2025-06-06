using Microsoft.EntityFrameworkCore;

namespace Wedding_Planner.Models.Entity
{
    public class WeddingPlannerDbContext : DbContext
    {
        public WeddingPlannerDbContext(DbContextOptions<WeddingPlannerDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<WeddingPlanner> WeddingPlanners { get; set; }
        public DbSet<Couple> Couples { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<WeddingChecklist> WeddingChecklists { get; set; }
        public DbSet<WeddingTimeline> WeddingTimelines { get; set; }
        public DbSet<Weddings> Weddings { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<VendorCategory> VendorCategories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorService> VendorServices { get; set; }
        public DbSet<VendorReview> VendorReviews { get; set; }
        public DbSet<WeddingVendor> WeddingVendors { get; set; }
        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Fluent API configuration can go here
        }
    }
}
