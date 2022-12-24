namespace NaukaWebApi.Models
{
    public class Passport
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
