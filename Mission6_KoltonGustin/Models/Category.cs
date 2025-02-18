using System.ComponentModel.DataAnnotations;

namespace Mission6_KoltonGustin.Models
{
    public class Category // category table with key of CategoryId
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
