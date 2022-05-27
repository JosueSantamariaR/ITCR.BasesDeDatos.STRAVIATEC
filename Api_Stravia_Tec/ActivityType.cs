namespace Api_Stravia_Tec
{
    public class ActivityType
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<Activity>? Activities { get; set; }
        public List<Challenge>? Challenges { get; set; }
        public List<Race>? Race { get; set; }

    }
}
