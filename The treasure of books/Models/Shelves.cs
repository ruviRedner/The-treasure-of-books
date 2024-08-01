using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_treasure_of_books.Models
{
    public class Shelves
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="גובה המדף")]
        public int Height { get; set; }
        [Display(Name ="ספריה")]
        public Library? Libraryid { get; set; }
        [NotMapped]
        public int lid { get; set; }
        

       
    }
}
