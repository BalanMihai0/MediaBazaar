using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
    public class Location
    {
        private int locationId;
        private int floor;
        private int roomNumber;

        public Location (int locationId, int floor, int roomNumber)
        {
            this.locationId = locationId;
            this.floor = floor;
            this.roomNumber = roomNumber;
        }

        #region properties & validation

        public int LocationId
        {
            get { return locationId; }
            private set
            {
                if (value > 0)
                {
                    locationId = value;
                }
                else
                {
                    throw new ArgumentException("Location ID must be greater than 0.");
                }
            }
        }

        public int Floor 
        { 
            get { return floor; }
            set
            {
                floor = value;
            } 
        }

        public int RoomNumber 
        { 
            get { return RoomNumber; }
            set
            {
                roomNumber = value;
            }
        }
        #endregion

        public override string ToString()
        {
            return $"ID:{this.locationId},  Floor: {this.floor}, Room: {this.roomNumber}";
        }
    }
}
