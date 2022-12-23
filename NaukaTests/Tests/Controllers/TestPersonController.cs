using Microsoft.AspNetCore.Mvc;
using Moq;
using NaukaTests.MockData;
using NaukaWebApi.Controllers;
using NaukaWebApi.Models;
using NaukaWebApi.Services.PersonService;

namespace NaukaTests.Tests.Controllers
{
    public class TestPersonController
    {
        [Fact]
        public async Task GetPeople_ShouldReturn200Status()
        {
            Mock<IPersonService> personService = new Mock<IPersonService>();
            personService.Setup(_ => _.GetAllAsync()).ReturnsAsync(PersonMockData.GetPeople());
            PersonController sut = new PersonController(personService.Object);

            var result = await sut.GetPeople();
            var okResult = result.Result as OkObjectResult;

            Assert.Equal(okResult?.StatusCode, 200 );
        }

        [Fact]
        public async Task Post_ShouldReturn200Status()
        {
            Mock<IPersonService> personService = new Mock<IPersonService>();
            Person newPerson = PersonMockData.NewPerson();
            PersonController sut = new PersonController(personService.Object);

            var result = await sut.Post(newPerson);
            var okResult = result.Result as NoContentResult;

            Assert.Equal(okResult?.StatusCode, 204);
            personService.Verify(_ => _.CreateAsync(newPerson), Times.Exactly(1));
        }
    }
}
