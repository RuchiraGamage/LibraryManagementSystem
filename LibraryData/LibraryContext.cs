using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class LibraryContext : DbContext
    {
    public LibraryContext(DbContextOptions options) : base(options) { }
        //dbcontext use to refer database DBset use to refer a table inside it (some entity) for some crud operations
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Checkouts> Checkouts { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public DbSet<LibraryBranch> LibraryBranches { get; set; }
        public DbSet<BranchHours> BranchHours { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<LibraryAsset> LibraryAssets { get; set; }
        public DbSet<Hold> Holds { get; set; }


    }
}
