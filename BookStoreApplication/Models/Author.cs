using System.ComponentModel.DataAnnotations;

namespace BookStoreApplication.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }  
        public string AuthorBio {  get; set; }
        public DateTime AuthorDateOfBirth {  get; set; }
        public List<Book>? Books { get; set; }   
        

    }
}
