using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Commanding
{
    public class MainViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }                    
    }
}