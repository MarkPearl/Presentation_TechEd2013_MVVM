namespace ViewFirstApproach
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel
        {
            get
            {
                return new MainViewModel {Name = "Mark"};
            }
        }
    }
}