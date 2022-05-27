namespace Api_Stravia_Tec
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string date { get; set; }
        public string route { get; set; }
        public bool isPrivate { get; set; }
        public int cost { get; set; }
        public string bank_accounts { get; set; }

        // **** status sólo puede ser: inscrita, en_progreso, completado ****
        public string status { get; set; }

        public List<Organizer>? Organizers { get; set; }
        public ActivityType? activityType { get; set; }
        public Category? category { get; set; }

    }
}
