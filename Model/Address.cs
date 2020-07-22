using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace msa_p1_data.Model
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }

        
        [MaxLength(1000)]
        public string streetNumber { get; set; }

        [MaxLength(1000)]
        public string street { get; set; }

        [Required, MaxLength(1000)]
        public string suburb { get; set; }

        [Required, MaxLength(1000)]
        public string city { get; set; }

        [Required, MaxLength(1000)]
        public string postcode { get; set; }

        [Required, MaxLength(1000)]
        public string country { get; set; }

        
        public DateTime timeCreated { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        //public Student Student { get; set; }

    }
}
