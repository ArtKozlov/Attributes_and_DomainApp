using System;

namespace Attributes
{
    // Should be applied to classes only.
    [AttributeUsage(AttributeTargets.Class)]
    public class InstantiateUserAttribute : Attribute
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }

        public InstantiateUserAttribute(int id, string firstName, string lastName)
        {
            Id = id;
            Firstname = firstName;
            LastName = lastName;
        }

        public InstantiateUserAttribute(string firstName, string lastName)
        {
            Firstname = firstName;
            LastName = lastName;
        }
        public InstantiateUserAttribute(int id, string lastName)
        {
            Id = id;
            LastName = lastName;
        }
    }
}
