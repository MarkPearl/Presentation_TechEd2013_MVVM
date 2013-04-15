namespace Converters
{
    public class MainViewModel : ViewModelBase
    {
        private int _rating;

        public DelegateCommand MoveRateUp { get; set; }
        public DelegateCommand MoveRateDown { get; set; }

        public MainViewModel()
        {
            MoveRateUp = new DelegateCommand(
                () => { Rating++; }, CanRateUp);

            MoveRateDown = new DelegateCommand(
                () => { Rating--; }, CanRateDown);                
        }

        private bool CanRateUp()
        {
            if (Rating > 2) return false;
            return true;
        }

        private bool CanRateDown()
        {
            if (Rating < 1) return false;
            return true;
        }

        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                OnPropertyChanged();

                MoveRateDown.UpdateCanExecuteState();
                MoveRateUp.UpdateCanExecuteState();
            }
        }
    }
}
