namespace CeiboTutorialClase2.Dto
{
    public class ViewUser
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";
    }
}
