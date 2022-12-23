using Microsoft.EntityFrameworkCore;
using NaukaTests.MockData;
using NaukaWebApi.Data;
using NaukaWebApi.Models;
using NaukaWebApi.Services.PersonService;

namespace NaukaTests.Tests.Services
{
    public class TestPersonService : IDisposable
    {
        protected readonly DataContext _context;
        public TestPersonService()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new DataContext(options);

            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllAsync_ReturnPersonCollection()
        {
            _context.People.AddRange(PersonMockData.GetPeople());
            _context.SaveChanges();

            var sut = new PersonService(_context);

            var result = await sut.GetAllAsync();

            Assert.Equal(result.Count(), PersonMockData.GetPeople().Count);
        }

        [Fact]
        public async Task CreateAsync_AddNewPerson()
        {
            Person? newTodo = PersonMockData.NewPerson();
            _context.People.AddRange(PersonMockData.GetPeople());
            _context.SaveChanges();

            var sut = new PersonService(_context);

            await sut.CreateAsync(newTodo);

            int expectedRecordCount = (PersonMockData.GetPeople().Count() + 1);
            Assert.Equal(_context.People.Count(), expectedRecordCount);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
