namespace Domain.ObjectValues.ObjectValuesUser
{
    public class UserObjectName
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public UserObjectName(string firstname, string lastName)
        {
            FirstName = firstname;
            LastName = lastName;
        }

    }


}
