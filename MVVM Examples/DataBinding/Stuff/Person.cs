using System.Collections.Generic;

namespace DataBinding.Stuff
{
    public class Person
    {
        private string _name;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }       

        public ICollection<string> Nicknames { get; set; }
    }
}