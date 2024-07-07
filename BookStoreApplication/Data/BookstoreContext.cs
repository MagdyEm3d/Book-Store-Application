using BookStoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApplication.Data
{
    public class BookstoreContext:DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.Author_id);                
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


    }
}
