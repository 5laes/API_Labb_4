using API_Labb_4.Models;

namespace API_Labb_4.Services
{
    public interface IHobbieRepository
    {
        List<Hobbie> GetHobbiesOfPerson(int personId);
        HobbieLink AddHobbieToPerson(HobbieLink hobbieLink);
    }
}
