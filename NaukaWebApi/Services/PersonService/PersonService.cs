using Microsoft.EntityFrameworkCore;
using NaukaWebApi.Data;
using NaukaWebApi.Models;
using System;

namespace NaukaWebApi.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _context;

        public PersonService(DataContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            Person? person = await _context.People.FindAsync(id);
            if (person == null)
            {
                throw new Exception("Person not found");
            }
            return person;
        }

        public async Task CreateAsync(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            Person? existingPerson = await _context.People.FindAsync(person.Id);
            if (existingPerson == null)
            {
                throw new Exception("Person not found");
            }

            existingPerson.FirstName = person.FirstName;
            existingPerson.SecondName = person.SecondName;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person person)
        {
            var existingPerson = await _context.People.FindAsync(person.Id);
            if (existingPerson == null)
            {
                throw new Exception("Person not found");
            }

            _context.People.Remove(existingPerson);
            await _context.SaveChangesAsync();
        }
    }
}
