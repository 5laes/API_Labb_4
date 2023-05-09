using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Labb_4.Models
{
    public class HobbieLink
    {
        [Key]
        public int Id { get; set; }

        public string Link { get; set; }

        public int PersonId { get; set; }

        public int HobbieId { get; set; }

        [JsonIgnore]
        public  Hobbie? Hobbie { get; set; }

        [JsonIgnore]
        public  Person? Person { get; set; }
    }
}
