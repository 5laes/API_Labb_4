using API_Labb_4.Models;

namespace API_Labb_4.Services
{
    public interface IPersonRepository
    {
        List<Person> GetAllPersons();
        Person GetSinglePerson(int id);
        Person AddPerson(Person person);
        Person UpdatePerson(Person person);
        void RemovePerson(Person person);
    }
}
