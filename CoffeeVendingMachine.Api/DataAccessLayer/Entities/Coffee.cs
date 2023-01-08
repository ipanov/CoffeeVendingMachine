using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace StarbucksCoffee.Api.DataAccessLayer.Entities
{
    [Table("coffee")]
    public class Coffee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public ICollection<Characteristic> Characteristics { get; set; }
    }
}
