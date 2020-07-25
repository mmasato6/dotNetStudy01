using Microsoft.EntityFrameworkCore;

namespace DiarySample.Dao
{
    public class DiarySampleDbContext : DbContext
    {
        public DiarySampleDbContext(DbContextOptions<DiarySampleDbContext> options) : base(options) { }
        public DbSet<Diary> Diaries { get; set; }
    }
}
