namespace NaukaWebApi.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
