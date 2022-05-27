namespace Api_Stravia_Tec
{
    public class Organizer
    {
        public int Id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lName1 { get; set; }
        public string lName2 { get; set; }
        public string birth_date { get; set; }
        public int age { get; set; }
        public string nationality { get; set; }
        public string photo { get; set; }

        public List<Activity> Activities { get; set; }
        public List<Race> Races { get; set; }
        public List<Challenge> Challenges { get; set; }
        public List<Group> Groups { get; set; }
        public List<Category> Categories { get; set; }

    }
}
