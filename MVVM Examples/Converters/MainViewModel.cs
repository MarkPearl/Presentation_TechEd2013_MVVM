using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Converters
{
    public class MainViewModel : ViewModelBase
    {
        private int _rating;

        public ICommand MoveRateUp { get; set; }
        public ICommand MoveRateDown { get; set; }

        public MainViewModel()
        {
            MoveRateUp = new DelegateCommand(() => { Rating++; }, () => true);
            MoveRateDown = new DelegateCommand(() => { Rating--; }, () => true);
        }

        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }
    }
}
