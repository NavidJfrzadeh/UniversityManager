using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Entities;
using UniversityManager.Utilities;

namespace UniversityManager.Services
{
    public class RegisterServises
    {
        GenericRepository<Person> _personRepo;
        List<Person> _personList;

        public RegisterServises(string personfilePath)
        {
            _personRepo = new GenericRepository<Person>(personfilePath);
            _personList = _personRepo.GetAll();
        }

        public Person Login(string Name,string Password)
        {
            return _personList.FirstOrDefault(x => x.name == Name && x.password == Password);
        }

        public void Register(Person newPerson)
        {
            if(_personList.Any(x=>x.id==newPerson.id))
            {
                Console.WriteLine($"{newPerson.name} has already taken");
            }
            else
            {
                _personList.Add(newPerson);
                Console.WriteLine("\nRegister successful...");
                _personRepo.SaveChanges();
            }
        }
    }
}
