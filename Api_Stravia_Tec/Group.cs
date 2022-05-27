namespace Api_Stravia_Tec
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Administrator { get; set; }

        public List<Organizer>? Organizers { get; set; }
        public List<Activity>? Activities{ get; set; }

    }
}
