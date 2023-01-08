using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace StarbucksApi.DataAccessLayer.Entities
{
    public class Characteristic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Coffee> Coffees { get; set; }

        public Characteristic() 
        {
            Coffees = new HashSet<Coffee>();
        }
    }
}

