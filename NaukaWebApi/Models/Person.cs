namespace NaukaWebApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;

        public virtual Passport Passport { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<PersonCompany> PersonCompanies { get; set; }
    }
}
