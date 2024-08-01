using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_treasure_of_books.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="שם הספר")]
        public string BookName { get; set; }
        [Display(Name ="ספר ז'אנר")]
        public string GenreBook { get; set; }
        [Display(Name ="גובה הספר")]
        public int BookHeight { get; set; }
        [Display(Name ="מדף")]
        public Shelves? Shelveid { get; set; }
        [NotMapped]
        public int shid {  get; set; }
    }
}
