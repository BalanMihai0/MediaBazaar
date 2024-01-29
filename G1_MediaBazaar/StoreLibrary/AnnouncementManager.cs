using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
	public class AnnouncementManager
	{
		private IAnnouncementDataInterface _announcementDataInterface;

        public AnnouncementManager(IAnnouncementDataInterface a)
        {
            _announcementDataInterface = a;
        }

        public Announcement AddAnouncement(Announcement a)
        {
            return _announcementDataInterface.AddAnouncement(a);
        }

        public List<Announcement> GetAnnouncementsByPosterID(int posterID)
        {
            return _announcementDataInterface.GetAnnouncementsByPosterID(posterID);
        }

        public List<Announcement> GetAllAnnouncements()
        {
            return _announcementDataInterface.GetAllAnnouncements();
        }

        public bool RemoveAnnouncement(Announcement a)
        {
            return _announcementDataInterface.RemoveAnnouncement(a);
        }

        public bool EditAnnouncement(Announcement a)
        {
            return _announcementDataInterface.EditAnnouncement(a);
        }
    }
}
