using API_Labb_4.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Labb_4.Services
{
    public class HobbieLinkRepository : IHobbieLinkRepository
    {
        private APIDbContext _context;

        public HobbieLinkRepository(APIDbContext context)
        {
            _context = context;
        }

        public HobbieLink AddHobbieLinkToPerson(HobbieLink hobbieLink)
        {
            _context.HobbieLinks.Add(hobbieLink);
            _context.SaveChanges();
            return hobbieLink;
        }

        public List<string> GetHobbieLinksOfPerson(int personId)
        {
            return _context.HobbieLinks.Where(p => p.PersonId == personId).Select(x => x.Link).ToList();
        }
    }
}
