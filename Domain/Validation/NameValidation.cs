using System.Text.RegularExpressions;

namespace PicPayLite.Domain.Validation
{
    public class NameValidation
    {
        private readonly static Regex nameRx = new(@"^[a-zA-Z''-'\s]{5,14}$");
        private readonly static int nameMinLenght = 5;
        public static bool Validate(string name)
        {
            if (nameRx.IsMatch(name) is false)
                return false;
            
            if (name.Length < nameMinLenght)
                return false;

            return true;
        }
    }
}