namespace Task50_9
{
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }

        public Employee(string name, string position, string office)
        {
            Name = name;
            Position = position;
            Office = office;
        }
    }
}
