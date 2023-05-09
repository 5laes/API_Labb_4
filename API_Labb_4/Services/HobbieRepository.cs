using API_Labb_4.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Labb_4.Services
{
    public class HobbieRepository : IHobbieRepository
    {
        private APIDbContext _context;

        public HobbieRepository(APIDbContext context)
        {
            _context = context;
        }

        public HobbieLink AddHobbieToPerson(HobbieLink hobbieLink)
        {
            _context.HobbieLinks.Add(hobbieLink);
            _context.SaveChanges();
            return hobbieLink;
        }

        public List<Hobbie> GetHobbiesOfPerson(int personId)
        {
            return _context.HobbieLinks.Where(p => p.PersonId == personId).Select(h => h.Hobbie).ToList();
        }
    }
}
