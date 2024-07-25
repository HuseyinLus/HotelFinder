using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelFinder.Entities
{
    public class Hotel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string? Name { get; set; }

        [StringLength(50)]
        [Required]
        public string? City { get; set; }

        [StringLength(50)]
        [Required]
        public string? Country { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
