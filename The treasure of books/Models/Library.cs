using System.ComponentModel.DataAnnotations;

namespace The_treasure_of_books.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="שם הספריה")]
        public string LiberryName{ get; set; }
        [Display(Name = "זאנר")]
        public string genre { get; set; }
    }
}
