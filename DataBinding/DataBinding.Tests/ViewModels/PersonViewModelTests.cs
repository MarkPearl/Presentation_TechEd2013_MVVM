using DataBinding.Services;
using DataBinding.ViewModels;
using NUnit.Framework;

namespace DataBinding.Tests.ViewModels
{
    [TestFixture]
    public class PersonViewModelTests
    {

        [Test]
        public void ShouldExecute_WhenIDNumverIsNotEmpty()
        {
            var sut = new PersonViewModel();
            sut.IDNumber = "Not Empty";
            var result = sut.CanExecuteIDNumberValidation();

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ShouldNotExecute_WhenIDNumverIsEmpty()
        {
            var sut = new PersonViewModel();
            sut.IDNumber = string.Empty;
            var result = sut.CanExecuteIDNumberValidation();

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ShouldBeValidIDNumber_WhenIDNumberValid()
        {
            var homeAffairsIDValidatorServiceTestDouble = new HomeAffairsIDValidatorServiceTestDouble(true);
            var sut = new PersonViewModel(homeAffairsIDValidatorServiceTestDouble);

            sut.IDNumber = string.Empty;
            sut.ValidateIDNumberCommand.Execute(null);
    
            Assert.That(sut.IsValidIDNumber, Is.EqualTo(true));
        }
    }

    public class HomeAffairsIDValidatorServiceTestDouble : IHomeAffairsIDValidatorService
    {
        private readonly bool _overrideValidation;

        public HomeAffairsIDValidatorServiceTestDouble(bool overrideValidation)
        {
            _overrideValidation = overrideValidation;
        }

        public bool ValidateIDNumber(string idNumber)
        {
            return _overrideValidation;
        }
    }
}