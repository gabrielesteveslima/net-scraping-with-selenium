namespace SibSample.Application.Users
{
    using Configuration;
    using System.Collections.Generic;
    using Domain;

    public class UserContract : Contract<Bank>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public List<DocumentContract> Documents { get; set; }
    }
}