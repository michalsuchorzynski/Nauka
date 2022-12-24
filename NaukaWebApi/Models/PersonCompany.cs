namespace NaukaWebApi.Models
{
    public class PersonCompany
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
