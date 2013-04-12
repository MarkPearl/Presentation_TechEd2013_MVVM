using System.Windows;

namespace ViewFirstApproach
{
    public class MainViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public DelegateCommand DoSomething { get; set; }

        public MainViewModel()
        {
            DoSomething = new DelegateCommand(() => { MessageBox.Show(string.Format("Hello {0}", Name)); }, () => true);
        }
    }
}