using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Labb_4.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public ICollection<HobbieLink>? HobbieLinks { get; set; }
    }
}
