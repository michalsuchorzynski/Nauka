namespace NaukaWebApi.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<PersonCompany> PersonCompanies { get; set; }
    }
}
