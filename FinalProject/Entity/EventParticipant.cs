namespace FinalProject.Entity{
    public class EventParticipant{
        public int EventParticipantId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}