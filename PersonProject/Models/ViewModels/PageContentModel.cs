using System;
using System.Collections.Generic;

namespace PersonProject.Models.ViewModels
{
    public class PageContentModel
    {
        public List<PersonModel> Person { get; set; }

        public PageContentModel()
        {
        }
        public PageContentModel(List<PersonModel> person)
        {
            Person = person;
        }
    }
}
