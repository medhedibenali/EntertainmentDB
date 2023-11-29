namespace EntertainmentDB.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string SeasonTitle { get; set; }
        public int numberOfEpiosdes { get; set; }
        public virtual Show Show { get; set; }
        public virtual ICollection<Episode> Episodes { get; set;}

    }
}