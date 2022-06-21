using Microsoft.EntityFrameworkCore;

using System.Diagnostics.CodeAnalysis;

namespace csharp_blog_backend.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Post> posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Posts");
        }
    }
}