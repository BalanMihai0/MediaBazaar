namespace G1_MediaBazaar_Web.DTO
{
    public class EventsOfAvailability
    {
        public string? start { get; set; }
        public string? end { get; set; }
        
        public EventsOfAvailability( string start, string end)
        {
            this.start = start;
            this.end = end;
        }
        public override string ToString()
        {
            return start+" "+end;
        }
    }
}
