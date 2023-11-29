namespace EntertainmentDB.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int Duration { get; set; }
        public virtual Season Season { get; set; }

    }
}