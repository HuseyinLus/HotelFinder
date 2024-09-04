using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Entities
{
    public class Register
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string? Name { get; set; }

        [StringLength(50)]
        [Required]
        public string? LastName { get; set; }

        [StringLength(50)]
        [Required]
        public string? Username { get; set; }

        [StringLength(50)]
        [Required]
        public string? Password { get; set; }

        [StringLength(40)]
        [Required]
        public string? Email { get; set; }

        [StringLength(50)]
        [Required]
        public string?  Location { get; set; }
    }
}
