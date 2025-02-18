using System.ComponentModel.DataAnnotations;

namespace Mission6_KoltonGustin.Models
{
    public class Movie // table and columns in the database
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required] 
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }


    }
}
