using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
	public interface IAnnouncementDataInterface
	{
		Announcement AddAnouncement(Announcement a);

		List<Announcement> GetAnnouncementsByPosterID(int posterID);

		List<Announcement> GetAllAnnouncements();

		bool RemoveAnnouncement(Announcement a);

		bool EditAnnouncement(Announcement a);
	}
}
