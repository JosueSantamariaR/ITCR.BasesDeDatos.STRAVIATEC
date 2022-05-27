namespace Api_Stravia_Tec

{
    public class Athlete
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? name { get; set; }
        public string? lname1 { get; set; }
        public string? lname2 { get; set; }
        public string? birth_date { get; set; }
        public string current_age { get; set; }
        public string? nationality { get; set; }
        public string? photo { get; set; }

        public List<Activity>? Activities { get; set; }
        public int? ActivityId { get; set; }

    }
}
