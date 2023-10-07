namespace Domain.ObjectValues
{
    public class UserObjectName
    {
        public string Name { get; set; }

        public string LastName { get; set; }
        public UserObjectName(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

    }


}
