using System;
namespace PersonProject.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }

        public PersonModel()
        {
        }

        public PersonModel(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
        }
    }
}
