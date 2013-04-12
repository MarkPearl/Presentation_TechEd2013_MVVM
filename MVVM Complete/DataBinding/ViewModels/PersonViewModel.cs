using System.ComponentModel;
using DataBinding.Services;

namespace DataBinding.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private readonly IHomeAffairsIDValidatorService _homeAffairsIdValidatorService;

        private string _firstName;
        private string _idNumber;
        private bool _validIDNumber;

        private void Initialize()
        {
            ValidateIDNumberCommand = new DelegateCommand(
                () => IsValidIDNumber = _homeAffairsIdValidatorService.ValidateIDNumber(IDNumber),
                CanExecuteIDNumberValidation);
        }

        public PersonViewModel()
        {
            Initialize();
            _homeAffairsIdValidatorService = new HomeAffairsIDValidatorService();
        }

        public PersonViewModel(IHomeAffairsIDValidatorService homeAffairsIdValidatorService)
        {
            Initialize();
            _homeAffairsIdValidatorService = homeAffairsIdValidatorService;
        }

        public bool CanExecuteIDNumberValidation()
        {
            if (IDNumber == null) return false;
            if (IDNumber.Length <= 0) return false;
            return true;
        }

        public DelegateCommand ValidateIDNumberCommand { get; set; }

        public bool IsValidIDNumber
        {
            get { return _validIDNumber; }
            set
            {
                if (_validIDNumber != value)
                {
                    _validIDNumber = value;
                    OnPropertyChanged(this, new PropertyChangedEventArgs("IsValidIDNumber"));
                }
            }
        }

        public string IDNumber
        {
            get { return _idNumber; }
            set
            {
                if (_idNumber != value)
                {
                    _idNumber = value;
                    OnPropertyChanged(this, new PropertyChangedEventArgs("IDNumber"));
                    ValidateIDNumberCommand.UpdateCanExecuteState();
                }
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
                }
            }
        }
    }
}

