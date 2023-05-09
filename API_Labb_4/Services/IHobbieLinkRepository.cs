using API_Labb_4.Models;

namespace API_Labb_4.Services
{
    public interface IHobbieLinkRepository
    {
        List<string> GetHobbieLinksOfPerson(int personId);
        HobbieLink AddHobbieLinkToPerson(HobbieLink hobbieLink);
    }
}
