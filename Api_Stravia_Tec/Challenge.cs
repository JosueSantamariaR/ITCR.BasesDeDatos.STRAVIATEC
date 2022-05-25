namespace Api_Stravia_Tec
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string period { get; set; }
        public string type { get; set; }
        public bool isPrivate { get; set; }

        public List<Organizer> Organizers { get; set; }

    }
}
