using System.Text.Json.Serialization;

namespace Api_Stravia_Tec
{
    public class Route
    {
        public int Id { get; set; }
        public string origin { get; set; }
        public string destiny { get; set; }
        [JsonIgnore]
        
        public Activity Activity { get; set; }
        public List<Organizer> Organizers { get; set; }
        public int ActivityId { get; set; }
    }
}
