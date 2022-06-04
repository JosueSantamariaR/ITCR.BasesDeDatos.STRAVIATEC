namespace Api_Stravia_Tec

{
    public class Athlete
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? fname { get; set; }
        public string? lname { get; set; }
        public string? category { get; set; }
        public string? birth_date { get; set; }
        public int current_age { get; set; }
        public string? nationality { get; set; }
        public string? photo { get; set; }

        public List<Activity>? Activities { get; set; }
        public int? ActivityId { get; set; }

    }
}
