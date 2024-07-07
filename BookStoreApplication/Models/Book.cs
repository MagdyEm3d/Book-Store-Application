using BookStoreApplication.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApplication.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookTitle { get; set; }   
        public double BookPrice {  get; set; }
        public string BookImgURL {  get; set; }
        public DateTime BookPublicationDate {  get; set; }
        public Genre BookGenre { get; set; }
        public int Author_id { get; set; }
        [ForeignKey("Author_id")]
        public Author? Author { get; set; }




    }
}
