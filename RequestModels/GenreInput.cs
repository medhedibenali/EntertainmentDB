using EntertainmentDB.Models;

namespace EntertainmentDB.RequestModels
{
	public abstract class PersonInput
	{
		public string Name { get; set; } = "";
		public ICollection<Guid>? Medias { get; set; }

	}
}