using DataBinding.ViewModels;

namespace DataBinding
{
    public class ViewModelLocator
    {
        public PersonViewModel PersonViewModel
        {
            get
            {
                return new PersonViewModel { FirstName = "First Name Set" };
            }
        }
    }
}