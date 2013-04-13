using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBinding
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