using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace StarbucksApi.DataAccessLayer.Entities
{
    public class Coffee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public virtual ICollection<Characteristic> Characteristics { get; set; }

        public Coffee()
        {
            Characteristics = new HashSet<Characteristic>(); 
        }
    }
}
