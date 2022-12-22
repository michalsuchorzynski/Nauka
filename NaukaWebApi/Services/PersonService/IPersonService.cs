using NaukaWebApi.Models;

namespace NaukaWebApi.Services.PersonService
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task CreateAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);
    }
}

