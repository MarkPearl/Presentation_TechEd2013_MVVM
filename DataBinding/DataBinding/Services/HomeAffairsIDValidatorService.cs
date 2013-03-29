namespace DataBinding.Services
{
    public interface IHomeAffairsIDValidatorService
    {
        bool ValidateIDNumber(string idNumber);
    }

    public class HomeAffairsIDValidatorService : IHomeAffairsIDValidatorService
    {
        public bool ValidateIDNumber(string idNumber)
        {
            if (idNumber == "123") return true;
            return false;
        }
    }
}