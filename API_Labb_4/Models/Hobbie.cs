using System.ComponentModel.DataAnnotations;

namespace API_Labb_4.Models
{
    public class Hobbie
    {
        [Key]
        public int Id { get; set; }

        public string HobbieName { get; set; }

        public string Description { get; set; }

        public ICollection<HobbieLink> HobbieLinks { get; set; }
    }
}
