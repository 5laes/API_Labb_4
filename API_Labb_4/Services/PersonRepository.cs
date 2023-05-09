using API_Labb_4.Models;

namespace API_Labb_4.Services
{
    public class PersonRepository : IPersonRepository
    {
        private APIDbContext _context;

        public PersonRepository(APIDbContext context)
        {
            _context= context;
        }

        public Person AddPerson(Person newPerson)
        {
            _context.People.Add(newPerson);
            _context.SaveChanges();
            return newPerson;
        }

        public List<Person> GetAllPersons()
        {
            return _context.People.ToList();
        }

        public Person GetSinglePerson(int id)
        {
            return _context.People.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePerson(Person personToRemove)
        {
            _context.People.Remove(personToRemove);
            _context.SaveChanges();
        }

        public Person UpdatePerson(Person updatedPerson)
        {
            var oldPerson = _context.People.Find(updatedPerson.Id);
            if (oldPerson != null)
            {
                oldPerson.Name = updatedPerson.Name;
                oldPerson.PhoneNumber = updatedPerson.PhoneNumber;
                _context.People.Update(oldPerson);
                _context.SaveChanges();
            }
            return updatedPerson;
        }
    }
}
