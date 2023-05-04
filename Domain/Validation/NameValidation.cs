using System.Text.RegularExpressions;

namespace PicPayLite.Domain.Validation
{
    public class NameValidation
    {
        private readonly static Regex nameRx = new(@"^[a-zA-Z'záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'-'\s]{3,50}$");
        private readonly static int nameMinLenght = 3;
        public static bool Validate(string name)
        {
            if (nameRx.IsMatch(name) is false)
                return false;

            return true;
        }
    }
}