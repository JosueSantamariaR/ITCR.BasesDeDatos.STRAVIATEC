namespace Api_Stravia_Tec
{
    public class Report
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string lname1 { get; set; }
        public string lname2 { get; set; }
        public int age { get; set; }
        public string category { get; set; }
        public string registered_time { get; set; }

        public List<Organizer> Organizers  { get; set; }

    }
}
