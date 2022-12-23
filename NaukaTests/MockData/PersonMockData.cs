using NaukaWebApi.Models;

namespace NaukaTests.MockData
{
    internal class PersonMockData
    {
        public static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person
                {
                     Id = 1,
                     FirstName = "F1",
                     SecondName = "F1",
                },
                new Person
                {
                     Id = 2,
                     FirstName = "F2",
                     SecondName = "F2",
                },
                new Person
                {
                     Id = 3,
                     FirstName = "F3",
                     SecondName = "F3",
                }
            };
        }
        public static Person NewPerson()
        {
            return new Person
            {
                Id = 0,
                FirstName = "F0",
                SecondName = "F0",
            };
        }
    }
}
