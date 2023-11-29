using System.ComponentModel.DataAnnotations;

namespace EntertainmentDB.Models
{
    public class Show : Media
    {
        public string Synopsis { get; set; }
        [Required]
        public int NumberOfSeasons { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }



    }
}