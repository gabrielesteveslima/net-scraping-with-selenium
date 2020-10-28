namespace SibSample.Application.Users
{
    using Configuration;
    using System.Collections.Generic;
    using Domain;
    using Domain.Users;

    public class UserContract : Contract<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public List<DocumentContract> Documents { get; set; }
    }
}