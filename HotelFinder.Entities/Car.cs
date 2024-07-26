using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Entities
{
    public class Car
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string CarModel { get; set; }

        [StringLength(50)]
        [Required]
        public string LicencePlate { get; set; }

        [StringLength(50)]
        [Required]
        public string ContactNumber { get; set; }
        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}
