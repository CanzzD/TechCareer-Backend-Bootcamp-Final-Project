namespace FinalProject.Entity{
    public class Event{
        public int EventId { get; set; }
        public string? EventTitle { get; set; }
        public string? EventDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int OrganizerId { get; set; }
        public User Organizer { get; set; }=null!;
        public List<EventParticipant> Participants { get; set; } = new List<EventParticipant>(); 
    }
}