namespace EntertainmentDB.Models
{
    public class Production
    {
        public string Name { get; set; } = "";
        public string Origin { get; set; } = "";
        public virtual ICollection<Media>? Media { get; set; }
    }
}
