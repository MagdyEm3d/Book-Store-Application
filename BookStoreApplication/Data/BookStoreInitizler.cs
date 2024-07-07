using BookStoreApplication.Models;

namespace BookStoreApplication.Data
{
    public class BookStoreInitizler
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using var store = applicationBuilder.ApplicationServices.CreateScope();
            var context = store.ServiceProvider.GetService<BookstoreContext>();
            context.Database.EnsureCreated();
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(new List<Author>()
                {
                    new Author()
                    {
                        AuthorName = "Actor 1",
                        AuthorBio = "This is the Bio of the first actor",
                        AuthorDateOfBirth=new DateTime(2024,7,7),


                    },
                });
                context.SaveChanges();

            }
            if (!context.Books.Any())
{
    context.Books.AddRange(new List<Book>()
    {
        new Book()
        {
            BookTitle = "Book 1",
            BookPrice = 30,
            BookImgURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
            BookPublicationDate = DateTime.Now.AddDays(-10),
            Author_id = 1,
            BookGenre = Genre.Documentary
        },

    });
    context.SaveChanges();
}

        }

       
    }
}
