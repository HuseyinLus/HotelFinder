using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Entities
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }

        [StringLength(50)]
        [Required]
        public string UserName { get; set; }

        [StringLength(50)]
        [Required]
        public string UserLastName { get; set; }

        [StringLength(50)]
        [Required]
        public string UserEmail { get; set; }

        [StringLength(50)]
        [Required]
        public string UserLocation { get; set; }
    }
}
