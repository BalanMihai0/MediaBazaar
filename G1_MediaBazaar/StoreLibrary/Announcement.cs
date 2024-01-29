using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
	public class Announcement
	{
        public Announcement()
        {
            
        }

        public Announcement(int id, string title, string description, int posterId)
        {
            ID = id;
            Title = title;
            Description = description;
            PosterID = posterId;
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public int PosterID { get; set; }
    }
}
