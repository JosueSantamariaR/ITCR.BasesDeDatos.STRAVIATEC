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
        public string category { get; set; }

        public List<Organizer> Organizers { get; set; }

    }
}
