namespace Api_Stravia_Tec
{
    public class Activity
    {
        public int id { get; set; }
        public string date { get; set; }
        public string hour { get; set; }
        public string duration { get; set; }
        public string type { get; set; }
        public string mileage { get; set; }
        public string route { get; set; }
        public bool isChallengeRace { get; set; }   

        public List<Athlete>  Athletes { get; set; }
        public List<Route> Routes { get; set; }
        public List<Organizer> Organizers { get; set; }
        public List<Group> Group { get; set; }
        public List<Challenge> Challenges { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
