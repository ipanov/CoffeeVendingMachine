using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace StarbucksCoffee.Api.DataAccessLayer.Entities
{
    [Table("Characteristic")]
    public class Characteristic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Coffee> Coffees { get; set; }
    }
}
